using CoinGardenWorld.HttpClientsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;

namespace CoinGardenWorld.DownstreamApiExtensions
{
    public class DownstreamApiBase<T, M> : HttpClientBase<T, M>, IDownstreamApiBase<M> where T : HttpClientBase<T, M>
    {
        // TODO: Authorized HttpClient NOT SUPPORTED in BLAZOR WASM
        // https://learn.microsoft.com/en-us/entra/identity-platform/scenario-web-app-call-api-app-configuration
        private readonly IDownstreamApi _downstreamApi;
        private readonly ILogger<T> _logger;

        public bool HttpClientIsAuthorized => true;

        public DownstreamApiBase(IDownstreamApi downstreamApi, ILogger<T> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
            _downstreamApi = downstreamApi;
            _logger = logger;
        }


        protected override void Configure()
        {

            // TODO: Authorized HttpClient NOT SUPPORTED in BLAZOR WASM

            //base.Configure();
        }

        public override Task<List<M>?> ListAsync()
        {
            return base.ListAsync();
        }

        public override async Task<HttpResponseMessage> GetAsync(string relativeUrl)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            try
            {
                // If the Client is Authenticated use IDownstreamApi
                if (HttpClientIsAuthorized && ApiKey != null)
                {
                    _logger.LogInformation("Called DownstreamApi - GetAsync/" + relativeUrl);
                    var response = await _downstreamApi.CallApiForUserAsync(ApiKey, options =>
                    {
                        options.RelativePath = relativeUrl;
                    });

                    return response;
                }
                else
                {
                    _logger.LogInformation("Called HttpClient - GetAsync/" + relativeUrl);
                    // If the Client is not Authenticated use HttpClient
                    return await _httpClient.GetAsync(relativeUrl);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                content = new StringContent(e.Message, Encoding.UTF8, "application/json");
            }

            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.InternalServerError, Content = content };
        }
    }
}
