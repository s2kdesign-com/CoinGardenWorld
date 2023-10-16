using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using SignalRSwaggerGen.Attributes;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [SignalRHub(description: "SignalR Hub Used for broadcasting alert messages and notifications")]
    public class BroadcastHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext BroadcastHubContext => _hubContextStore.BroadcastHubContext;


        public BroadcastHub(ILoggerFactory loggerFactory, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<BroadcastHub>();
            _hubContextStore = hubContextStore;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;

            
            return base.OnConnectedAsync();
        }
    }
}
