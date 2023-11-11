using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using SignalRSwaggerGen.Attributes;
using System.Security.Claims;
using System.Timers;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [Authorize]
    [SignalRHub(description: "SignalR Hub Used for Chat communication")]
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext BroadcastHubContext => _hubContextStore.ChatHubContext;
        private static string _connectionId;

        public event Action NotifyStateChanged;

        public ChatHub(ILoggerFactory loggerFactory)//, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<ChatHub>();
            //_hubContextStore = hubContextStore;
        }

        public async void AfterConnected()
        {
            string name = Context.User.Claims.FirstOrDefault(c => c.Type == "name").Value;

            _logger.LogInformation($"Sending UserConnected event to {name}");

            await Clients.Caller.SendAsync("UserConnected", name + " - Welcome to GardenAPP ChatHub SignalR!");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            _connectionId = Context.ConnectionId;

            var userId = Context.UserIdentifier;
            string email = Context.User.Claims.FirstOrDefault(c => c.Type == "emails").Value;
            string name = Context.User.Claims.FirstOrDefault(c => c.Type == "name").Value;

            foreach (var userClaim in Context.User.Claims)
            {
                Console.WriteLine(userClaim.Type + ":" + userClaim.Value);
            }

            if (!Context.User.IsInRole("Standard User"))
            {
                _logger.LogInformation("not in role :(");
            }
            else
            {
                _logger.LogInformation("Here we goooo :)");

            }

            _logger.LogInformation($"UserID: {userId} | UserEmail: {email} | ConnectionID: {_connectionId} has connected to {nameof(ChatHub)}");

        }
        public override Task OnDisconnectedAsync([SignalRHidden] Exception? exception)
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;

            _logger.LogInformation($"UserID: {userId} ConnectionID: {connectionId} has disconnected from  {nameof(ChatHub)}");

            return base.OnDisconnectedAsync(exception);
        }
    }
}
