using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Client;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class MobileApiAuthorizedHttpClient : HttpClientBase<MobileApiAuthorizedHttpClient, string>
    {
        public override string ApiKey => "CGW.Mobile.Api";
        public override bool HttpClientIsAuthorized => true;

        public MobileApi MobileApi { get; private set; }
        public Default.Container MobileApiOData { get; private set; }

        private IAccessTokenProvider _accessTokenProvider {  get; set; }

        private AccessToken? _token { get; set; }

        public MobileApiAuthorizedHttpClient(IAccessTokenProvider accessTokenProvider,  ILogger<MobileApiAuthorizedHttpClient> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
            _accessTokenProvider = accessTokenProvider;
        }

        protected override async void Configure()
        {
            base.Configure();

            // We can always use the basic http client but this one is referenced in service connections and has all the models and endpoints configured 
            MobileApi = new MobileApi(BaseAddress.AbsoluteUri, _httpClient);

            var odataUri = new Uri(BaseAddress, "odata");

            MobileApiOData = new Default.Container(odataUri);
            MobileApiOData.BuildingRequest += MobileApiOData_BuildingRequest;
            MobileApiOData.HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;

        }

        private async void MobileApiOData_BuildingRequest(object? sender, BuildingRequestEventArgs e)
        {
            var tokenRequest = await _accessTokenProvider.RequestAccessToken();
            if(tokenRequest != null && tokenRequest.TryGetToken(out var token))
            {
                e.Headers.Add("Authorization", token.Value);
            }
        }
    }
}
