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
using CoinGardenWorldMobileApp.MobileAppTheme.Configurations;

namespace CoinGardenWorldMobileApp.MobileAppTheme.SignalR
{
    public class ClientHub<T> : IClientHub<T> where T : ClientHub<T>
    {
        public virtual string _hubUrlSuffix { get; } = "";


        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationStateProvider _authStateProvider;

        private System.Timers.Timer _signalRReconnectTimer = new System.Timers.Timer();

        private HubConnection? _hubConnection;

        public HubConnection HubConnection
        {
            get { return _hubConnection; }
            set { _hubConnection = value; }
        }


        public event Action NotifyStateChanged;

        private bool hubConnected = false;

        public bool HubConnected
        {
            get => hubConnected;
            set {
                NotifyStateChanged?.Invoke();
                hubConnected = value; 
            }
        }


        private readonly string _hubUrl = "";


        public ClientHub(IConfiguration configuration, ILogger<ClientHub<T>> logger)
        {
            _configuration = configuration;
            _logger = logger;
            //_authStateProvider = authenticationStateProvider;

            _signalRReconnectTimer.Elapsed += new ElapsedEventHandler(SignalRReconnect);
            _signalRReconnectTimer.Interval = 5000;

            var externalApisSettings = configuration.Get<ExternalApisSettings>();

            if (externalApisSettings != null && externalApisSettings.ExternalApis != null)
            {
                _hubUrl = externalApisSettings.ExternalApis.FirstOrDefault().Value.Api_Url + _hubUrlSuffix;

                _ = InitializeHubBuilder(_hubUrl);
            }
        }


        private async void SignalRReconnect(object source, ElapsedEventArgs e)
        {
            _logger.LogInformation($"Trying to reconnect to signalr hub at URL: {_hubUrl}");

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

        private async Task InitializeHubBuilder(string hubUrl)
        {


            //var authState = await _authStateProvider.GetAuthenticationStateAsync();
            //var userEmails = "";
            //if (authState.User.Identity != null && authState.User.Identity.IsAuthenticated)
            //{
            //    userEmails = authState.User.Claims.First(c => c.Type == "emails").Value;
            //}
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl, opt =>
                {
                    // TODO: NOT WORKING
                    //opt.Headers.Add("user-emails", userEmails);
                })
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.Reconnecting += ex =>
            {
                _logger.LogInformation($"SignalR hub connection lost, trying to reconnect at URL: {hubUrl}");

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
                _logger.LogInformation($"The connection of '{hubUrl}' is closed.");

                //StartTheTimer
                _signalRReconnectTimer.Enabled = true;

                HubConnected = false;

                //If you expect non-null exception, you need to turn on 'EnableDetailedErrors' option during client negotiation.
                if (ex != null)
                {
                    Console.Write($" Exception: {ex}");
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

        public bool IsHubConnected => 
             _hubConnection?.State == HubConnectionState.Connected;
        

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
