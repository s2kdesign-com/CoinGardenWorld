using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.AzureFunctionExtensions.Services;
using Microsoft.Identity.Client;

namespace CoinGardenWorld.AzureFunctionExtensions.Providers {
    public class AuthenticationProvider
    {
        private readonly AzureAdJwtBearerValidation _azureAdJwtBearerValidation;
        private static IConfidentialClientApplication _application;

        public AuthenticationProvider(IConfiguration configuration,
            AzureAdJwtBearerValidation azureAdJwtBearerValidation)
        {
            var tenantId = configuration["AzureAd:TenantId"];
            var clientId = configuration["AzureAd:ClientId"];
            var instance = configuration["AzureAd:Instance"];
            var clientSecret = configuration["AzureAd:ClientSecret"];

            _azureAdJwtBearerValidation = azureAdJwtBearerValidation;
            if (_application == null)
            {
                _application = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithAuthority($"{instance}{tenantId}/v2.0/")
                    .WithClientSecret(clientSecret)
                    .Build();
            }
        }

        public async Task<ClaimsPrincipal> AuthenticateAsync(FunctionContext context, HttpRequestData req)
        {
            var logger = context.GetLogger("WorkerAuthentication");
            return await _azureAdJwtBearerValidation.ValidateTokenAsync(getAccessTokenFromHeaders(req), logger);
        }

        public async Task<ClaimsPrincipal> AuthenticateAsync(FunctionContext context, string token)
        {
            var logger = context.GetLogger("WorkerAuthentication");
            return await _azureAdJwtBearerValidation.ValidateTokenAsync(token, logger);
        }

        public async Task<string> GetAccessTokenForUserAsync(HttpRequestData req, IEnumerable<string> scopes,
            string? tenantId = null, string? userFlow = null)
        {
            var result = await _application
                .AcquireTokenOnBehalfOf(scopes, new UserAssertion(getAccessTokenFromHeaders(req))).ExecuteAsync();

            return result.AccessToken;
        }

        public HttpResponseData ReplyUnauthorized(HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.Unauthorized);

            return response;
        }

        public HttpResponseData ReplyForbidden(HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.Forbidden);

            return response;
        }

        private string getAccessTokenFromHeaders(HttpRequestData req)
        {
            var token = req.Headers.Where(x => x.Key == "Authorization").First().Value.First()
                .Substring("Bearer ".Length);

            return token;
        }
    }
}
