using CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CoinGardenWorld.DownstreamSignalRExtensions.Providers;

namespace CoinGardenWorld.DownstreamSignalRExtensions.HubClients
{
    public class ChatHubDownstreamClient : ChatHub
    {
        public ChatHubDownstreamClient(IConfiguration configuration, ILogger<ChatHub> logger, BlazorSignalRTokenProvider<ChatHub> tokenProvider, AuthenticationStateProvider authenticationStateProvider) : base(configuration, logger, tokenProvider, authenticationStateProvider)
        {
        }
    }
}
