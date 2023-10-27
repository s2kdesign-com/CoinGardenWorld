using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.NetworkInformation;
using System.Timers;
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using Microsoft.Extensions.Options;

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
