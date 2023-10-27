using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiSiteClients
{
    public class MobileApiSiteAuthorizedAzureFunctionClient : HttpClientBase<MobileApiSiteAuthorizedAzureFunctionClient, string>
    {
        public override string ApiKey => "CGW.MobileSite.Api";
        public override bool HttpClientIsAuthorized => true;


        public MobileApiSiteAuthorizedAzureFunctionClient(ILogger<MobileApiSiteAuthorizedAzureFunctionClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
