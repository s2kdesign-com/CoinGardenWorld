using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class VersionAuthorizedHttpClient : HttpClientBase<VersionAuthorizedHttpClient, string>
    {
        public override string ApiKey => "CGW.Mobile.Api";
        public override bool HttpClientIsAuthorized => true;

        public VersionAuthorizedHttpClient(ILogger<VersionAuthorizedHttpClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
