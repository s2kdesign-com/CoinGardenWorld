using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using SignalRSwaggerGen.Attributes;
using System.Security.Claims;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [Authorize]
    [SignalRHub(description: "SignalR Hub Used for Chat communication")]
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext BroadcastHubContext => _hubContextStore.ChatHubContext;


        public ChatHub(ILoggerFactory loggerFactory)//, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<ChatHub>();
            //_hubContextStore = hubContextStore;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;
            string email = Context.User.Claims.FirstOrDefault(c => c.Type == "emails").Value;

            foreach (var userClaim in Context.User.Claims)
            {
                Console.WriteLine(userClaim.Type + ":" + userClaim.Value);
            }

            if (!Context.User.IsInRole("Flora Pioneer"))
            {
                _logger.LogInformation("not in role :(");
            }
            else
            {
                _logger.LogInformation("Here we goooo :)");

            }

            _logger.LogInformation($"UserID: {userId} | UserEmail: {email} | ConnectionID: {connectionId} has connected to {nameof(ChatHub)}");
            return base.OnConnectedAsync();
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
