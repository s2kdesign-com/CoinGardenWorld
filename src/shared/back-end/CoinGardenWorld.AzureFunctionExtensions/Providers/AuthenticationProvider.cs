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
            var clientSecret = configuration["AzureAd:ClientSecret"];

            _azureAdJwtBearerValidation = azureAdJwtBearerValidation;
            if (_application == null)
            {
                _application = ConfidentialClientApplicationBuilder.Create(clientId)
                    .WithAuthority($"https://login.microsoftonline.com/{tenantId}/v2.0/")
                    .WithClientSecret(clientSecret)
                    .Build();
            }
        }

        public async Task<ClaimsPrincipal?> AuthenticateAsync(FunctionContext context, HttpRequestData req)
        {
            var token = GetJwtFromHeader(req);
            if (string.IsNullOrEmpty(token))
                return null;

            var logger = context.GetLogger("WorkerAuthentication");
            return await _azureAdJwtBearerValidation.ValidateTokenAsync(token, logger);
        }

        public async Task<ClaimsPrincipal?> AuthenticateAsync(FunctionContext context, string token)
        {
            var logger = context.GetLogger("WorkerAuthentication");
            return await _azureAdJwtBearerValidation.ValidateTokenAsync(token, logger);
        }

        public async Task<string> GetAccessTokenForUserAsync(HttpRequestData req, IEnumerable<string> scopes,
            string? tenantId = null, string? userFlow = null)
        {
            var token = GetJwtFromHeader(req);
            if (string.IsNullOrEmpty(token))
                return "";

            var result = await _application
                .AcquireTokenOnBehalfOf(scopes, new UserAssertion(token)).ExecuteAsync();

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

        public string GetJwtFromHeader(HttpRequestData req) {
            if (req.Headers.TryGetValues("Authorization", out var authHeaders)) {

                var authorizationHeader = authHeaders.First();
                string[] parts = authorizationHeader?.ToString().Split(null) ?? new string[0];
                return (parts.Length == 2 && parts[0].Equals("Bearer")) ? parts[1] : string.Empty;
            }

            return "";
        }
    }
}
