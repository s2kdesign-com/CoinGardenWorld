using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MetaverseSiteApiClients
{
    public class GardenBotAuthorizedAzureFunctionClient : HttpClientBase<GardenBotAuthorizedAzureFunctionClient, string> 
    {
        public override string ApiKey => "CGW.GardenBot.MessagingApi";
        public override bool HttpClientIsAuthorized => true;

        public GardenBotAuthorizedAzureFunctionClient(ILogger<GardenBotAuthorizedAzureFunctionClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
    }
}
