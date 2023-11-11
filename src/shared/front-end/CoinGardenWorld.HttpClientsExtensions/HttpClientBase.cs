using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using CoinGardenWorld.HttpClientsExtensions.Configurations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
//using Microsoft.Identity.Abstractions;

namespace CoinGardenWorld.HttpClientsExtensions
{
    public abstract class HttpClientBase<T, M> : IHttpClientBase<M> where T : IHttpClientBase<M>
    {
        protected readonly IHttpClientFactory HttpClientFactory;
        private readonly ILogger _logger;

        // TODO: Authorized HttpClient NOT SUPPORTED in BLAZOR WASM
        // https://learn.microsoft.com/en-us/entra/identity-platform/scenario-web-app-call-api-app-configuration
        // private readonly IDownstreamApi _downstreamApi;

        protected HttpClient? _httpClient;
        protected HttpClient? _httpClientAuthorized;

        public Uri? BaseAddress { get; set; }

        public virtual string? ApiKey { get; } = null;

        protected HttpClientBase(ILogger<T> logger, IHttpClientFactory httpClientFactory//, IDownstreamApi downstreamApi
            )
        {
            HttpClientFactory = httpClientFactory;
            _logger = logger;

            Configure();
        }
        protected virtual void Configure()
        {
            //_downstreamApi = downstreamApi;
            _httpClient = HttpClientFactory.CreateClient($"{ApiKey}");
            _httpClientAuthorized = HttpClientFactory.CreateClient($"{ApiKey}_AuthenticationClient");
            BaseAddress = _httpClient.BaseAddress;
        }
        public string GetModelRelativePath()
        {
            var modelName = typeof(M).Name;

            // TODO: Every generated model from Mapster is ending with Dto, Add, Update, Merge
            var path = "api/";

            if (modelName.EndsWith("Dto"))
                path += modelName.Replace("Dto", "");
            else if (modelName.EndsWith("Add"))
                path += modelName.Replace("Add", "");
            else if (modelName.EndsWith("Update"))
                path += modelName.Replace("Update", "");
            else if (modelName.EndsWith("Merge"))
                path += modelName.Replace("Merge", "");
            else
                path += modelName;

            return path;
        }

        public virtual async Task<List<M>?> ListAsync()
        {
            try
            {

                _logger.LogInformation("Called HttpClient - ListAsync/" + GetModelRelativePath());

                return await _httpClient.GetFromJsonAsync<List<M>>(GetModelRelativePath());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return new List<M>();
        }

        public virtual async Task<HttpResponseMessage> GetAsync()
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            try
            {
                _logger.LogInformation("Called HttpClient - GetAsync/" + GetModelRelativePath());
                // If the Client is not Authenticated use HttpClient
                return await _httpClient.GetAsync(GetModelRelativePath());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                content = new StringContent(e.Message, Encoding.UTF8, "application/json");
            }

            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.InternalServerError, Content = content };
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string relativeUrl)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            try
            {
                _logger.LogInformation("Called HttpClient - GetAsync/" + relativeUrl);
                // If the Client is not Authenticated use HttpClient
                return await _httpClient.GetAsync(relativeUrl);
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
