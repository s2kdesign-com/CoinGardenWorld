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
        public event Action<string> OnUserConnected;

        public bool IsHubConnected => _hubConnections.ContainsKey(HubKey) && _hubConnections[HubKey]?.State == HubConnectionState.Connected;

        protected static Dictionary<string, HubConnection> _hubConnections = new Dictionary<string, HubConnection>();

        public HubConnection? HubConnection
        {
            get
            {

                if (!_hubConnections.ContainsKey(HubKey))
                    return null;

                return _hubConnections[HubKey];
            }
            set
            {
                if (_hubConnections.ContainsKey(HubKey))
                    _hubConnections[HubKey] = value;
                else
                    _hubConnections.Add(HubKey, value);
            }
        }

        public virtual string HubKey { get; } = "";
        public virtual bool HubIsAuthorized { get; }

        private static Dictionary<string, AccessToken> accessTokens = new Dictionary<string, AccessToken>();

        public AccessToken? AccessToken {
            get
            {

                if (!accessTokens.ContainsKey(HubKey))
                    return null;

                return accessTokens[HubKey];
            }
            set
            {
                if (accessTokens.ContainsKey(HubKey))
                    accessTokens[HubKey] = value;
                else
                    accessTokens.Add(HubKey, value);
            }
        }

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

            StartHub();
        }

        private async void AuthStateChanged(Task<AuthenticationState> task)
        {
            var state = task.Result;
            var userAuthenticated = (state.User.Identity != null && state.User.Identity.IsAuthenticated);
            try
            {
                if (HubIsAuthorized && userAuthenticated)
                {
                    if (HubConnection != null)
                    {

                        await GetToken();


                        await HubConnection.StartAsync();

                        _logger.LogInformation($"SignalR Authenticated hub connection after login established at URL: {_hubUrl}");
                        HubConnected = true;
                    }
                    else
                    {
                        await InitializeHubBuilder();

                        await HubConnection.StartAsync();
                        _logger.LogInformation($"SignalR Authenticated hub connection after login is created and established at URL: {_hubUrl}");
                        HubConnected = true;

                    }
                }
                else if (HubIsAuthorized && !userAuthenticated)
                {
                    // If the User is not authenticated and HubIsAuthorized we stop the hub
                    _logger.LogInformation($"SignalR Authenticated hub connection is stopped after logout at URL: {_hubUrl}");
                    HubConnected = false;
                    if (HubConnection != null)
                        await HubConnection.StopAsync();
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

        private async void StartHub()
        {
            try
            {
                // Create new hub 
                await InitializeHubBuilder();


                if (HubIsAuthorized)
                {
                    var authenticationState = await _authStateProvider.GetAuthenticationStateAsync();
                    var userIsAuthenticated = authenticationState.User.Identity != null && authenticationState.User.Identity.IsAuthenticated;

                    if (HubConnection != null && !IsHubConnected && userIsAuthenticated)
                    {
                        await HubConnection.StartAsync();
                        HubConnected = true;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is started.");


                    }
                    else if (HubConnection != null && IsHubConnected && !userIsAuthenticated)
                    {
                        // Stop this madness, the user is not logged in but try to connect to authorized hub
                        await HubConnection.StopAsync();
                        HubConnected = false;
                        _logger.LogInformation($"SignalR Authenticated connection for '{HubKey}' is stopped during initialization.");
                    }
                    else
                    {
                        // There is no hub to start so probably is initial load 
                        HubConnected = false;
                        _logger.LogWarning($"SignalR Authenticated connection for '{HubKey}' is not started.");
                    }
                }
                else
                {
                    if (HubConnection == null)
                    {
                        HubConnected = false;
                        _logger.LogError($"The connection of '{HubKey}' is missing in appsettings.json file.");
                    }
                    else
                    {
                        await HubConnection.StartAsync();
                        HubConnected = true;
                        _logger.LogInformation($"SignalR connection for '{HubKey}' is started.");

                    }

                }
            }
            catch (Exception ex)
            {

                HubConnected = false;
                _logger.LogError(ex.Message);

                if (HubConnection != null)
                {
                    _signalRReconnectTimer.Enabled = true;
                }
                // And start it if the hub is not authorized (we dont need to check 401 errors every 5 seconds)
                //if (!HubIsAuthorized)
                // {
                //  }
            }
        }

        private async Task GetToken()
        {
            try
            {
                var accessTokenResult = await _tokenProvider.RequestAccessToken();
                
                if (accessTokenResult.TryGetToken(out var accessToken))
                {
                    AccessToken = accessToken;

                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw;
            }

        }

        private async Task InitializeHubBuilder()
        {


            if (HubIsAuthorized)
            {

                var authenticationState = await _authStateProvider.GetAuthenticationStateAsync();

                // ONLY If User is authorized we create the hub (negotiate will fail with 401 if hub is created even not started)
                if (authenticationState.User.Identity != null && authenticationState.User.Identity.IsAuthenticated)
                {
                    // Needed for negotiation with the hub :(
                    await GetToken();

                    HubConnection = new HubConnectionBuilder()
                        .WithUrl(_hubUrl, options =>
                        {

                            options.AccessTokenProvider = () => Task.FromResult(AccessToken?.Value);
                            //  options.Headers.Add(ClaimTypes.Role, "FirstRole");
                        })
                        .WithAutomaticReconnect()
                        .Build();

                    await AddHubEvents();
                }
                else
                {
                    _logger.LogInformation($"SignalR connection for '{HubKey}' will be started after authorization.");
                }
            }
            else
            {
                if (HubConnection == null)
                {
                    // Create a regular hub if hub is not authorized 
                    HubConnection = new HubConnectionBuilder()
                        .WithUrl(_hubUrl)
                        .WithAutomaticReconnect()
                        .Build();


                    await  AddHubEvents();
                }
            }

        }

        protected virtual Task AddHubEvents()
        {
            if (HubConnection != null)
            {


                HubConnection.Reconnecting += ex =>
                {
                    _logger.LogWarning($"SignalR hub connection lost, trying to reconnect at URL: {_hubUrl}");

                    HubConnected = false;
                    return Task.CompletedTask;
                };
                HubConnection.Reconnected += ex =>
                {
                    _logger.LogInformation($"SignalR hub connection reconnected at URL: {_hubUrl}");

                    HubConnected = true;

                    return Task.CompletedTask;
                };
                HubConnection.Closed += ex =>
                {
                    _logger.LogWarning($"The connection of '{_hubUrl}' is closed.");
                    HubConnected = false;

                    //If you expect non-null exception, you need to turn on 'EnableDetailedErrors' option during client negotiation.
                    if (ex != null)
                        _logger.LogWarning($" Exception: {ex}");

                    //StartTheTimer
                    _signalRReconnectTimer.Enabled = true;
                    return Task.CompletedTask;
                };

                HubConnection.On<string>("UserConnected", (message) =>
                {

                    _logger.LogWarning($"UserConnected event triggered '{_hubUrl}'.");

                    OnUserConnected?.Invoke(message);

                });
            }

            return Task.CompletedTask;
        }


        private async void SignalRReconnect(object source, ElapsedEventArgs e)
        {
            _logger.LogWarning($"SignalR hub connection lost, trying to reconnect at URL: {_hubUrl} ");
            try
            {
                if (!IsHubConnected)
                {
                    // TODO:  So lets see if the token will appear after a while 
                    //await InitializeHubBuilder();

                    await HubConnection.StartAsync();
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

        //public async ValueTask DisposeAsync()
        //{
        //    if (HubConnection is not null)
        //    {
        //        await HubConnection.DisposeAsync();

        //    }
        //    HubConnected = false;
        //    _signalRReconnectTimer.Dispose();
        //}
    }
}
