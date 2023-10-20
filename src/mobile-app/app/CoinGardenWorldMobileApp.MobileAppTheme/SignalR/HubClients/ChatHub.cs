using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoinGardenWorldMobileApp.MobileAppTheme.Configurations;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.NetworkInformation;
using System.Timers;

namespace CoinGardenWorldMobileApp.MobileAppTheme.SignalR.HubClients
{
    public class ChatHub : ClientHub<ChatHub>
    {
        public override string _hubUrlSuffix => "/chathub/";

        public ChatHub(IConfiguration configuration, ILogger<ChatHub> logger ) : base(configuration, logger)
        {
        }

    }
}
