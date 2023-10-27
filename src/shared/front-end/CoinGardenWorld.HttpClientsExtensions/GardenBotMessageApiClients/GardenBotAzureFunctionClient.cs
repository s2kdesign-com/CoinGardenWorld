using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MetaverseSiteApiClients
{
    public class GardenBotAzureFunctionClient : HttpClientBase<GardenBotAzureFunctionClient, string>
    {
        public override string ApiKey => "CGW.GardenBot.MessagingApi";

        public GardenBotAzureFunctionClient(ILogger<GardenBotAzureFunctionClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
