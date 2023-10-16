using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using SignalRSwaggerGen.Attributes;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [SignalRHub(description: "SignalR Hub Used for Chat communication")]
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext BroadcastHubContext => _hubContextStore.ChatHubContext;


        public ChatHub(ILoggerFactory loggerFactory, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<ChatHub>();
            _hubContextStore = hubContextStore;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;

            _logger.LogInformation($"UserID: {userId} ConnectionID: {connectionId} has connected to ChatHub");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;

            _logger.LogInformation($"UserID: {userId} ConnectionID: {connectionId} has disconnected from ChatHub");

            return base.OnDisconnectedAsync(exception);
        }
    }
}
