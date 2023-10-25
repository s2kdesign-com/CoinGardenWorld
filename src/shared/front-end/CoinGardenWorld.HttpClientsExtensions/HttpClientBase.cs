using System.Net.Http.Json;
using CoinGardenWorld.HttpClientsExtensions.Configurations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions
{
    public abstract class HttpClientBase<T, M> : IHttpClientBase<M> where T : IHttpClientBase<M>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly AuthenticationStateProvider _authStateProvider;



        private readonly HttpClient _httpClient;

        public HttpClient HttpClient
        {
            get { return _httpClient; }
        }

        public string BaseAddress { get; set; } = "https://localhost:7000";

        public string ApiUrl { get; set; } = "#";
        public virtual bool HttpClientIsAuthorized { get; }

        public virtual string ApiKey { get; }

        protected HttpClientBase(ILogger<T> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;

            var externalApis = _configuration.Get<ExternalApisSettings>() ?? new();

            if (externalApis.ExternalApis != null && externalApis.ExternalApis.Any())
            {
                if (!string.IsNullOrEmpty(ApiKey))
                {

                    var externalApi = externalApis.ExternalApis.FirstOrDefault(a => a.Key == ApiKey);
                    ApiUrl = new Uri(new Uri(externalApi.Value.Api_Url), "/api").AbsoluteUri + "/";
                    // There is multiple Apis                     
                    if (HttpClientIsAuthorized)
                    {
                        _httpClient = _httpClientFactory.CreateClient($"{ApiKey}");
                        BaseAddress = _httpClient.BaseAddress.AbsoluteUri;
                    }
                    else
                    {
                        _httpClient = _httpClientFactory.CreateClient($"{ApiKey}.NoAuthenticationClient");
                        BaseAddress = _httpClient.BaseAddress.AbsoluteUri;

                    }
                }
                else
                {
                    // Only one API or the ApiKey was not specified in the client
                    var externalApi = externalApis.ExternalApis.FirstOrDefault();
                    ApiUrl = new Uri(new Uri(externalApi.Value.Api_Url), "/api").AbsoluteUri + "/";
                    if (HttpClientIsAuthorized)
                    {
                        _httpClient = _httpClientFactory.CreateClient($"{externalApi.Key}");
                    }
                    else
                    {
                        _httpClient = _httpClientFactory.CreateClient($"{externalApi.Key}.NoAuthenticationClient");
                    }
                }

            }
        }

        public async Task<bool> UserIsAuthenticated()
        {
            var _authenticationState = await _authStateProvider.GetAuthenticationStateAsync();
            if (_authenticationState.User.Identity == null)
            {
                // No identity
                return false;
            }
            else if (_authenticationState.User.Identity.IsAuthenticated)
            {
                // WOW its authenticated
                return true;
            }
            else
            {
                // In Any case
                return false;
            }
        }
        private string GetApiControllerUrl()
        {
            var modelName = typeof(M).Name;

            // TODO: Every generated model from Mapster is ending with Dto
            if (!modelName.EndsWith("Dto"))
                return new Uri(ApiUrl) + modelName;

            return ApiUrl + modelName.Replace("Dto", "");
        }

        public async Task<List<M>?> ListAsync()
        {

            if (HttpClientIsAuthorized && !await UserIsAuthenticated())
            {
                _logger.LogError($"User is not Authenticated to call: " + GetApiControllerUrl());
                return null;
            }

            try
            {
                return await _httpClient.GetFromJsonAsync<List<M>>(GetApiControllerUrl());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return new List<M>();
        }

        public async Task<HttpResponseMessage> GetAsync()
        {

            if (HttpClientIsAuthorized && !await UserIsAuthenticated())
            {
                _logger.LogError($"User is not Authenticated to call: " + GetApiControllerUrl());
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.Unauthorized };
            }

            try
            {
                return await _httpClient.GetAsync(GetApiControllerUrl());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.InternalServerError };
        }

        public async Task<HttpResponseMessage> GetAsync(string relativeUrl)
        {

            if (HttpClientIsAuthorized && !await UserIsAuthenticated())
            {
                _logger.LogError($"User is not Authenticated to call: " + HttpClient.BaseAddress + relativeUrl);
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.Unauthorized };
            }

            try
            {
                return await _httpClient.GetAsync(relativeUrl);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.InternalServerError };
        }
    }
}
