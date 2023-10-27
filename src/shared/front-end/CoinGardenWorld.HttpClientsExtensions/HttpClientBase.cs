using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using Azure;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        // TODO: Authorized HttpClient NOT SUPPORTED in BLAZOR WASM
        // https://learn.microsoft.com/en-us/entra/identity-platform/scenario-web-app-call-api-app-configuration
      // private readonly IDownstreamApi _downstreamApi;
     
        protected HttpClient? _httpClient;

        public Uri? BaseAddress { get; set; }

        public virtual bool HttpClientIsAuthorized { get; } = false;

        public virtual string? ApiKey { get; } = null;

        protected HttpClientBase(ILogger<T> logger, IHttpClientFactory httpClientFactory//, IDownstreamApi downstreamApi
            )
        {


            _httpClientFactory = httpClientFactory;
            _logger = logger;


            Configure();
        }
        protected virtual void Configure()
        {

            //_downstreamApi = downstreamApi;
            string suffixUnauth = (HttpClientIsAuthorized) ? "_AuthenticationClient" : "";

            string apiName = (!string.IsNullOrEmpty(ApiKey)) ? $"{ApiKey}{suffixUnauth}" : $"{suffixUnauth}";

            _httpClient = _httpClientFactory.CreateClient($"{apiName}");
            BaseAddress = _httpClient.BaseAddress;
        }
        public string GetModelRelativePath()
        {
            var modelName = typeof(M).Name;

            // TODO: Every generated model from Mapster is ending with Dto, Add, Update, Merge
            if (!modelName.EndsWith("Dto"))
                return modelName;

            if (!modelName.EndsWith("Add"))
                return modelName;

            if (!modelName.EndsWith("Update"))
                return modelName;

            if (!modelName.EndsWith("Merge"))
                return modelName;

            return "api/" + modelName.Replace("Dto", "");
        }

        public virtual async Task<List<M>?> ListAsync()
        {
            try
            {

                if (HttpClientIsAuthorized && ApiKey != null)
                {
                    _logger.LogInformation("Called DownstreamApi - ListAsync/" + GetModelRelativePath());

                    // TODO: NOT supported in blazor wasm 
                    //var response = await _downstreamApi.CallApiForUserAsync<List<M>>(ApiKey, options =>
                    //{
                    //    options.RelativePath = GetModelRelativePath();
                    //});

                    //return response;
                    return await _httpClient.GetFromJsonAsync<List<M>>(GetModelRelativePath());
                }
                else
                {
                    _logger.LogInformation("Called HttpClient - ListAsync/" + GetModelRelativePath());

                    return await _httpClient.GetFromJsonAsync<List<M>>(GetModelRelativePath());
                }

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
                // If the Client is Authenticated use IDownstreamApi
                if (HttpClientIsAuthorized && ApiKey != null)
                {
                    _logger.LogInformation("Called DownstreamApi - GetAsync/" + GetModelRelativePath());

                    // TODO: NOT supported in blazor wasm 
                    //var response = await _downstreamApi.CallApiForUserAsync(ApiKey, options =>
                    //{
                    //    options.RelativePath = GetModelRelativePath();
                    //});

                    // return response;
                    return await _httpClient.GetAsync(GetModelRelativePath());
                }
                else
                {
                    _logger.LogInformation("Called HttpClient - GetAsync/" + GetModelRelativePath());
                    // If the Client is not Authenticated use HttpClient
                    return await _httpClient.GetAsync(GetModelRelativePath());

                }
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
                // If the Client is Authenticated use IDownstreamApi
                if (HttpClientIsAuthorized && ApiKey != null)
                {
                    _logger.LogInformation("Called DownstreamApi - GetAsync/" + relativeUrl);
                    //var response = await _downstreamApi.CallApiForUserAsync(ApiKey, options =>
                    //{
                    //    options.RelativePath = relativeUrl;
                    //});

                    //return response;

                    return await _httpClient.GetAsync(relativeUrl);
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
