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
    public class VersionAuthorizedHttpClient : HttpClientBase<VersionAuthorizedHttpClient, string>
    {
        public override bool HttpClientIsAuthorized => true;

        public VersionAuthorizedHttpClient(ILogger<VersionAuthorizedHttpClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }
    }
}
