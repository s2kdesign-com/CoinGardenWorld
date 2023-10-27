using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MetaverseSiteApiClients
{
    public class MetaverseAuthorizedAzureFunctionClient : HttpClientBase<MetaverseAuthorizedAzureFunctionClient, string> 
    {
        public override string ApiKey => "CGW.Metaverse.Api";
        public override bool HttpClientIsAuthorized => true;


        public MetaverseAuthorizedAzureFunctionClient(ILogger<MetaverseAuthorizedAzureFunctionClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
