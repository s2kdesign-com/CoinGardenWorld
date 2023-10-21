using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorldMobileApp.MobileAppTheme.SignalR.HubClients
{
    public class NotificationsHub : ClientHub<NotificationsHub>
    {
        public override string _hubUrlSuffix => "/notificationshub/";
        public NotificationsHub(IConfiguration configuration, ILogger<NotificationsHub> logger, IAccessTokenProvider tokenProvider, AuthenticationStateProvider authenticationStateProvider) : base(configuration, logger, tokenProvider, authenticationStateProvider)
        {
		}
	}
}
