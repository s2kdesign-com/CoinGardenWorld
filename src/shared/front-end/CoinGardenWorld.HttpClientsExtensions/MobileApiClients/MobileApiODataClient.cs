using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.HttpClientsExtensions.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Client;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class MobileApiODataClient : HttpClientBase<MobileApiODataClient, string>
    {
        public override string ApiKey => "CGW.Mobile.Api";

        public Default.Container MobileApiOData { get; private set; }
        public Default.Container MobileApiODataAuthorized { get; private set; }

        protected HttpClient? _httpClientAuthorized;

        public MobileApiODataClient(ILogger<MobileApiODataClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
            _httpClientAuthorized = HttpClientFactory.CreateClient($"{ApiKey}_AuthenticationClient");
        }

        protected override void Configure()
        {
            base.Configure();

            var odataUri = new Uri(BaseAddress, "odata");

            MobileApiOData = new Default.Container(odataUri);
            MobileApiOData.HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;
            MobileApiOData.Configurations.RequestPipeline.OnMessageCreating = OnMessageCreating;

            MobileApiODataAuthorized = new Default.Container(odataUri);
            MobileApiODataAuthorized.HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;
            MobileApiODataAuthorized.Configurations.RequestPipeline.OnMessageCreating = OnMessageCreatingAuthorized;

        }
        private CustomHttpClientRequestMessage OnMessageCreatingAuthorized(DataServiceClientRequestMessageArgs args)
        {

            var message = new CustomHttpClientRequestMessage(_httpClientAuthorized, args, MobileApiOData.Configurations);

            foreach (var header in args.Headers)
            {
                message.SetHeader(header.Key, header.Value);
            }
            return message;
        }
        private CustomHttpClientRequestMessage OnMessageCreating(DataServiceClientRequestMessageArgs args)
        {

            var message = new CustomHttpClientRequestMessage(_httpClient, args, MobileApiOData.Configurations);

            foreach (var header in args.Headers)
            {
                message.SetHeader(header.Key, header.Value);
            }
            return message;
        }
    }
}
