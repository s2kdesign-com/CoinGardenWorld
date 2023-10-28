using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using CoinGardenWorld.SignalRClientsExtensions.Configurations;

namespace CoinGardenWorld.SignalRClientsExtensions.SignalR
{
    public abstract class ClientHub : IClientHub
    {
        // This Values are used to trigger NotifyStateChanged?.Invoke() event 
        private bool _hubConnected = false;

        private bool HubConnected
        {
            get => _hubConnected;
            set
            {

                _hubConnected = value;
                NotifyStateChanged?.Invoke();
            }
        }

        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly ILogger _logger;

        private readonly System.Timers.Timer _signalRReconnectTimer = new System.Timers.Timer();
        private readonly string _hubUrl = "";

        public event Action NotifyStateChanged;
        public bool IsHubConnected => _hubConnection?.State == HubConnectionState.Connected;

        private HubConnection? _hubConnection;

        public HubConnection? HubConnection
        {
            get { return _hubConnection; }
            set { _hubConnection = value; }
        }

        public virtual string HubKey { get; } = "";
        public virtual bool HubIsAuthorized { get; }

        protected ClientHub(IConfiguration configuration, ILogger<ClientHub> logger, IAccessTokenProvider tokenProvider, AuthenticationStateProvider authenticationStateProvider)
        {
            _logger = logger;
            _authStateProvider = authenticationStateProvider;
            _tokenProvider = tokenProvider;

            // Set timer of there is no connection for SignalR handshake
            _signalRReconnectTimer.Elapsed += new ElapsedEventHandler(SignalRReconnect);
            _signalRReconnectTimer.Interval = 5000;

            var signalRClientSettings = new SignalRClientsSettings();
            configuration.Bind(signalRClientSettings);

            if (signalRClientSettings.SignalRClients != null && signalRClientSettings.SignalRClients.ContainsKey(HubKey))
            {
                _hubUrl = signalRClientSettings.SignalRClients[HubKey].Client_Url;
            }
            else
            {
                if (HubKey == "chathub")
                    _hubUrl = "https://plant-api.azurewebsites.net/chathub";
                else if (HubKey == "notificationshub")
                    _hubUrl = "https://plant-api.azurewebsites.net/notificationshub";
                // TODO: Define hub for base address or just leave it to logError(appsettings.json is missing values like in the end of the initialization)?  
            }

            if (HubIsAuthorized)
            {
                _authStateProvider.AuthenticationStateChanged += AuthStateChanged;
            }

            StartHub(_hubUrl);

        }

        private async void AuthStateChanged(Task<AuthenticationState> task)
        {
            var state = task.Result;
            var userAuthenticated = (state.User.Identity != null && state.User.Identity.IsAuthenticated);
            try
            {
                if (HubIsAuthorized && userAuthenticated)
                {
                    if (_hubConnection != null)
                    {
                        await _hubConnection.StartAsync();

                        _logger.LogInformation($"SignalR Authenticated hub connection after login established at URL: {_hubUrl}");
                        HubConnected = true;
                    }
                    else
                    {
                        InitializeHubBuilder(_hubUrl);

                        await _hubConnection.StartAsync();
                        _logger.LogInformation($"SignalR Authenticated hub connection after login is created and established at URL: {_hubUrl}");
                        HubConnected = true;

                    }
                }
                else if (HubIsAuthorized && !userAuthenticated)
                {
                    // If the User is not authenticated and HubIsAuthorized we stop the hub
                    _logger.LogInformation($"SignalR Authenticated hub connection is stopped after logout at URL: {_hubUrl}");
                    HubConnected = false;
                    if (_hubConnection != null)
                        await _hubConnection.StopAsync();
                }
            }
            catch (Exception exception)
            {
                // Start Reconnect Timer
                _logger.LogError(exception.Message);

                HubConnected = false;
                _signalRReconnectTimer.Enabled = true;
            }
        }

        private async void StartHub(string hubUrl)
        {
            try
            {
                // Create new hub 
                InitializeHubBuilder(hubUrl);

                if (HubIsAuthorized)
                {
                    var authenticationState = await _authStateProvider.GetAuthenticationStateAsync();
                    if (_hubConnection != null && !IsHubConnected && authenticationState.User.Identity != null && authenticationState.User.Identity.IsAuthenticated)
                    {
                        await _hubConnection.StartAsync();
                        HubConnected = true;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is started.");
                    }
                    else if (_hubConnection != null && IsHubConnected)
                    {
                        // Stop this madness, the user is not logged in but try to connect to authorized hub
                        await _hubConnection.StopAsync();
                        HubConnected = false;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is stopped during initialization.");
                    }
                    else
                    {
                        // There is no hub to start so probably is initial load 
                        HubConnected = false;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is not started.");
                    }
                }
                else 
                {
                    if(_hubConnection == null)
                    {
                        HubConnected = false;
                        _logger.LogError($"The connection of '{HubKey}' is missing in appsettings.json file.");
                    }
                    else
                    {
                        await _hubConnection.StartAsync();
                        HubConnected = true;
                        _logger.LogInformation($"SignalR connection for '{HubKey}' is started.");
                    }

                }
            }
            catch (Exception ex)
            {

                HubConnected = false;
                _logger.LogError(ex.Message);

                // And start it if the hub is not authorized (we dont need to check 401 errors every 5 seconds)
                if (!HubIsAuthorized)
                {
                    _signalRReconnectTimer.Enabled = true;
                }
            }
        }

        private async Task<string?> GetToken()
        {
            try
            {
                var accessTokenResult = await _tokenProvider.RequestAccessToken();
                if (accessTokenResult.TryGetToken(out var accessToken))
                {
                    return accessToken.Value;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw;
            }
            // Close, but No Cigar
            return null;
        }

        private async void InitializeHubBuilder(string hubUrl)
        {
            if (HubIsAuthorized)
            {
                var authenticationState = await _authStateProvider.GetAuthenticationStateAsync();

                // ONLY If User is authorized we create the hub
                if (_hubConnection == null && authenticationState.User.Identity != null && authenticationState.User.Identity.IsAuthenticated)
                {
                    _hubConnection = new HubConnectionBuilder()
                        .WithUrl(hubUrl, options =>
                        {
                            if (HubIsAuthorized)
                            {
                                options.AccessTokenProvider = GetToken;
                                //  options.Headers.Add(ClaimTypes.Role, "FirstRole");

                            }
                        })
                        .WithAutomaticReconnect()
                        .Build();

                }
                else
                {
                    _logger.LogInformation($"SignalR connection for '{HubKey}' will be started after authorization.");
                }
            }
            else
            {
                // Create a regular hub if hub is not authorized 
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(hubUrl)
                    .WithAutomaticReconnect()
                    .Build();

            }


            if (_hubConnection != null)
            {

                _hubConnection.Reconnecting += ex =>
                {
                    _logger.LogWarning($"SignalR hub connection lost, trying to reconnect at URL: {hubUrl}");

                    HubConnected = false;
                    return Task.CompletedTask;
                };
                _hubConnection.Reconnected += ex =>
                {
                    _logger.LogInformation($"SignalR hub connection reconnected at URL: {hubUrl}");

                    HubConnected = true;

                    return Task.CompletedTask;
                };
                _hubConnection.Closed += ex =>
                {
                    _logger.LogWarning($"The connection of '{hubUrl}' is closed.");
                    HubConnected = false;

                    //If you expect non-null exception, you need to turn on 'EnableDetailedErrors' option during client negotiation.
                    if (ex != null)
                        _logger.LogWarning($" Exception: {ex}");

                    //StartTheTimer
                    _signalRReconnectTimer.Enabled = true;
                    return Task.CompletedTask;
                };

            }
        }

        private async void SignalRReconnect(object source, ElapsedEventArgs e)
        {
            try
            {
                if (!IsHubConnected)
                {
                    await _hubConnection.StartAsync();
                }
                // There is NO exception, hub is stared and we can stop the timer 
                _logger.LogInformation($"SignalR hub connection reconnected at URL: {_hubUrl}");
                HubConnected = true;
                _signalRReconnectTimer.Stop();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                HubConnected = false;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();

            }
            HubConnected = false;
            _signalRReconnectTimer.Dispose();
        }
    }
}
