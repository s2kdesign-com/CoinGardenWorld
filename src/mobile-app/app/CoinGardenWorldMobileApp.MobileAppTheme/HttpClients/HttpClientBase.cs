﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorldMobileApp.MobileAppTheme.Configurations;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Components.Authorization;

namespace CoinGardenWorldMobileApp.MobileAppTheme.HttpClients
{
    public abstract class HttpClientBase<T, M> : IHttpClientBase<T, M> where T : HttpClientBase<T, M>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly AuthenticationStateProvider _authStateProvider;

        public readonly HttpClient HttpClient;
        public string ApiUrl { get; set; } = "#";
        public virtual bool HttpClientIsAuthorized { get; }

        protected HttpClientBase(ILogger<T> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;   

            var externalApis = _configuration.Get<ExternalApisSettings>()??new ();

            if (externalApis.ExternalApis != null && externalApis.ExternalApis.Any())
            {
                var externalApi = externalApis.ExternalApis.FirstOrDefault();

                ApiUrl = new Uri(new Uri(externalApi.Value.Api_Url), "/api").AbsoluteUri + "/" ;

                if (HttpClientIsAuthorized)
                {
                    HttpClient = _httpClientFactory.CreateClient($"{externalApi.Key}");

                }
                else
                {
                    HttpClient = _httpClientFactory.CreateClient($"{externalApi.Key}.NoAuthenticationClient");
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
                return await HttpClient.GetFromJsonAsync<List<M>>(GetApiControllerUrl());
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
                return  await HttpClient.GetAsync(GetApiControllerUrl());
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
                return await HttpClient.GetAsync(relativeUrl);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.InternalServerError };
        }
    }
}
