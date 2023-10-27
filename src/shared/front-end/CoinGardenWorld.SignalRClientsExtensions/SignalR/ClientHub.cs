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

        public bool HubConnected
        {
            get => _hubConnected;
            set
            {
                NotifyStateChanged?.Invoke();
                _hubConnected = value;
            }
        }

        public virtual string HubKey { get; } = "";


        private readonly ILogger _logger;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAccessTokenProvider _tokenProvider;

        private readonly System.Timers.Timer _signalRReconnectTimer = new System.Timers.Timer();

        private HubConnection? _hubConnection;

        public HubConnection? HubConnection
        {
            get { return _hubConnection; }
            set { _hubConnection = value; }
        }


        public event Action NotifyStateChanged;

        public virtual bool HubIsAuthorized { get; }

        public bool IsHubConnected =>
            _hubConnection?.State == HubConnectionState.Connected;

        private readonly string _hubUrl = "";
        private AuthenticationState _authenticationState;

        private AccessToken? _accessToken;

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
                // TODO: Define hub for base address or just leave it to logError(appsettings.json is missing values like in the end of the initialization)  
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
                    var accessTokenResult = await _tokenProvider.RequestAccessToken();
                    accessTokenResult.TryGetToken(out _accessToken);

                    await _hubConnection.StartAsync();

                    _logger.LogInformation($"SignalR Authenticated hub connection after login established at URL: {_hubUrl}");
                    HubConnected = true;

                }
                else if (HubIsAuthorized && !userAuthenticated)
                {
                    // If the User is not authenticated and HubIsAuthorized we stop the hub
                    _logger.LogInformation($"SignalR Authenticated hub connection is stopped after logout at URL: {_hubUrl}");
                    HubConnected = false;
                    _accessToken = null;
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


        private async void StartHub(string hubUrl)
        {
            try
            {
                // Create new hub 
                InitializeHubBuilder(hubUrl);

                if (HubIsAuthorized && _hubConnection != null)
                {
                    _authenticationState = await _authStateProvider.GetAuthenticationStateAsync();
                    if (_authenticationState.User.Identity != null && _authenticationState.User.Identity.IsAuthenticated)
                    {
                        var accessTokenResult = await _tokenProvider.RequestAccessToken();
                        accessTokenResult.TryGetToken(out _accessToken);


                        await _hubConnection.StartAsync();
                        HubConnected = true;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is started.");
                    }
                    else
                    {
                        // Stop this madness, the user is not logged in but try to connect the hub 
                        await _hubConnection.StopAsync();
                        HubConnected = false;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is stopped during initialization.");
                    }
                }
                else if (!HubIsAuthorized && _hubConnection != null)
                {
                    await _hubConnection.StartAsync();
                    HubConnected = true;
                    _logger.LogInformation($"SignalR connection for '{HubKey}' is started.");

                }
                else
                {
                    // for not authenticated users, we will wait for the AuthenticationStateChanged event and than initialize the hub
                    _logger.LogError($"The connection of '{HubKey}' is missing in appsettings.json file.");
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


        private async void InitializeHubBuilder(string hubUrl)
        {

            if (_hubConnection == null)
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(hubUrl, options =>
                    {
                        if (HubIsAuthorized)
                        {
                            options.AccessTokenProvider = () => Task.FromResult(_accessToken?.Value)!;
                            //  options.Headers.Add(ClaimTypes.Role, "FirstRole");

                        }
                    })
                    .WithAutomaticReconnect()
                    .Build();


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

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();

                HubConnected = false;
                _signalRReconnectTimer.Dispose();
            }
        }
    }
}
