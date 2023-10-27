using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MetaverseSiteApiClients
{
    public class MetaverseAzureFunctionClient : HttpClientBase<MetaverseAzureFunctionClient, string>
    {
        public override string ApiKey => "CGW.Metaverse.Api";

        public MetaverseAzureFunctionClient(ILogger<MetaverseAzureFunctionClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
