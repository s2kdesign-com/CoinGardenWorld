using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class MobileApiSiteAzureFunctionClient : HttpClientBase<MobileApiSiteAzureFunctionClient, string>
    {
        public override string ApiKey => "CGW.MobileSite.Api";
        public MobileApiSiteAzureFunctionClient(ILogger<MobileApiSiteAzureFunctionClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }
    }
}
