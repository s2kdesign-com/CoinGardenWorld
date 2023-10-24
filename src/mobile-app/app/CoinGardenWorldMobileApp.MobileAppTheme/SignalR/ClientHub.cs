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
using CoinGardenWorld.HttpClientsExtensions.Configurations;

namespace CoinGardenWorldMobileApp.MobileAppTheme.SignalR
{
    public abstract class ClientHub<T> : IClientHub<T> where T : ClientHub<T>
    {

        [Obsolete("I don`t remember why i put this when there is public bool IsHubConnected =>")]
        private bool hubConnected = false;

        [Obsolete("I don`t remember why i put this when there is public bool IsHubConnected =>")]
        public bool HubConnected
        {
            get => hubConnected;
            set
            {
                NotifyStateChanged?.Invoke();
                hubConnected = value;
            }
        }

        public virtual string _hubUrlSuffix { get; } = "";


        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly ExternalApisSettings _externalApiSettings;

        private System.Timers.Timer _signalRReconnectTimer = new System.Timers.Timer();

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
        private bool _isAuthenticated = false;

        protected ClientHub(IConfiguration configuration, ILogger<ClientHub<T>> logger, IAccessTokenProvider tokenProvider, AuthenticationStateProvider authenticationStateProvider)
        {
            _configuration = configuration;
            _logger = logger;
            _authStateProvider = authenticationStateProvider;
            _tokenProvider = tokenProvider;

            // Set timer of there is no connection
            _signalRReconnectTimer.Elapsed += new ElapsedEventHandler(SignalRReconnect);
            _signalRReconnectTimer.Interval = 5000;

            _externalApiSettings = _configuration.Get<ExternalApisSettings>();
            if (_externalApiSettings !=null &&  _externalApiSettings.ExternalApis != null)
            {
                _hubUrl = _externalApiSettings.ExternalApis.FirstOrDefault().Value.Api_Url + _hubUrlSuffix;
            }

            if (HubIsAuthorized)
            {
                _ = GetAuthenticationStateAsync();

                if (!_isAuthenticated)
                {
                    _logger.LogError("TODO: Hub is Initialized before Authentication for some reason?");
                    _signalRReconnectTimer.Start();
                    return;
                }
            }

            _ = InitializeHubBuilder(_hubUrl);

        }

        private async Task GetAuthenticationStateAsync()
        {
            _authenticationState = await _authStateProvider.GetAuthenticationStateAsync();
            if (_authenticationState.User.Identity == null)
            {
                // No identity
                _isAuthenticated =  false;
            }
            else if (_authenticationState.User.Identity.IsAuthenticated)
            {
                // WOW its authenticated
                _isAuthenticated = true;
            }
            else
            {
                // In Any case
                _isAuthenticated = false;
            }
        }

        private async void SignalRReconnect(object source, ElapsedEventArgs e)
        {
            if (HubIsAuthorized)
            {
                _ = GetAuthenticationStateAsync();

                if (!_isAuthenticated)
                {
                    return;
                }
            }
            await BuildHubConnection(_hubUrl);
            try
            {
                if (!IsHubConnected)
                {
                    await _hubConnection.StartAsync();
                    _signalRReconnectTimer.Stop();
                }
                else
                {
                    _signalRReconnectTimer.Stop();
                }
                HubConnected = true;
                _logger.LogInformation($"SignalR hub connection established at URL: {_hubUrl}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private async Task BuildHubConnection(string hubUrl)
        {

            var accessTokenResult = await _tokenProvider.RequestAccessToken();
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl, options =>
                {
                    // TODO: NOT WORKING
                    //opt.Headers.Add("user-emails", userEmails);

                    if (accessTokenResult.TryGetToken(out var token))
                    {
                        options.AccessTokenProvider = () => Task.FromResult(token.Value)!;
                      //  options.Headers.Add(ClaimTypes.Role, "FirstRole");

                    }
                })

                .WithAutomaticReconnect()
                .Build();
        }

        private async Task InitializeHubBuilder(string hubUrl)
        {
            await BuildHubConnection(hubUrl);

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
                // TODO: Not working and i dont know why
                _logger.LogWarning($"The connection of '{hubUrl}' is closed.");

                //StartTheTimer
                _signalRReconnectTimer.Enabled = true;

                HubConnected = false;

                //If you expect non-null exception, you need to turn on 'EnableDetailedErrors' option during client negotiation.
                if (ex != null)
                {
                    _logger.LogWarning($" Exception: {ex}");
                }

                return Task.CompletedTask;

            };

            if (!IsHubConnected)
            {
                try
                {
                    await _hubConnection.StartAsync();
                    HubConnected = true;
                    _logger.LogInformation($"The connection of '{hubUrl}' is started.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    // And start it
                    _signalRReconnectTimer.Enabled = true;
                }
            }
        }



        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();

                _signalRReconnectTimer.Dispose();
            }
        }
    }
}
