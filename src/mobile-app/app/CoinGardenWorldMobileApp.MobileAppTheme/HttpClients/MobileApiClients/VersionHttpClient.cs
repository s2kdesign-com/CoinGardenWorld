using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorldMobileApp.MobileAppTheme.HttpClients.MobileApiClients
{
    public class VersionHttpClient : HttpClientBase<VersionHttpClient, string>
    {
        public VersionHttpClient(ILogger<VersionHttpClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }
    }
}
