
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients
{
    public class ChatHub : ClientHub
    {
        public override string HubKey => "chathub";

        public override bool HubIsAuthorized => true;


        public ChatHub(IConfiguration configuration, ILogger<ChatHub> logger, IAccessTokenProvider tokenProvider, AuthenticationStateProvider authenticationStateProvider) : base(configuration, logger, tokenProvider, authenticationStateProvider)
        {
        }


    }
}
