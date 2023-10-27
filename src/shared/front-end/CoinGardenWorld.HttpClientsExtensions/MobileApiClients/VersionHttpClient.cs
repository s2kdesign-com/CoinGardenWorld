using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class VersionHttpClient : HttpClientBase<VersionHttpClient, string>
    {
        public override string ApiKey => "CGW.Mobile.Api";

        public VersionHttpClient(ILogger<VersionHttpClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
