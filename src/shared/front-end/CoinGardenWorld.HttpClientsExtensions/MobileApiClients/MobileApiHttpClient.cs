using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class MobileApiHttpClient : HttpClientBase<MobileApiHttpClient, string>
    {
        public override string ApiKey => "CGW.Mobile.Api";

        public MobileApi MobileApi { get; private set; }

        public MobileApiHttpClient(ILogger<MobileApiHttpClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }

        protected override void Configure()
        {
            base.Configure();

            // We can always use the basic http client but this one is referenced in service connections and has all the models and endpoints configured 
            MobileApi = new MobileApi(BaseAddress.AbsoluteUri, _httpClient);
        }
    }
}
