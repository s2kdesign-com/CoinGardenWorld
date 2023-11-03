
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients
{
    public class NotificationsHub : ClientHub
    {
        public override string HubKey => "notificationshub";

        public NotificationsHub(IConfiguration configuration, ILogger<NotificationsHub> logger, IAccessTokenProvider tokenProvider, AuthenticationStateProvider authenticationStateProvider) : base(configuration, logger, tokenProvider, authenticationStateProvider)
        {
        }
    }
}
