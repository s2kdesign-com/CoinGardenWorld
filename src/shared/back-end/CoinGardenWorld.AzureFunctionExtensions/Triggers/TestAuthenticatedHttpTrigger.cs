using System.Net;
using System.Security.Claims;
using CoinGardenWorld.AzureFunctionExtensions.Providers;
using CoinGardenWorld.AzureFunctionExtensions.SecurityFlows;
using CoinGardenWorld.AzureFunctionExtensions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Core;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.OpenApi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace CoinGardenWorld.Api {
    public class TestAuthenticatedHttpTrigger {
        private readonly ILogger _logger;

        private readonly AuthenticationProvider _authentication;
        private static string[] roles =
        {
            // TODO: Find what are this roles 
            //"Data.Read", "Data.ReadWrite"
        };

        public TestAuthenticatedHttpTrigger(ILoggerFactory loggerFactory, AuthenticationProvider authentication) {
            _logger = loggerFactory.CreateLogger<TestAuthenticatedHttpTrigger>();

            _authentication = authentication;
        }

        [Function(nameof(TestAuthenticatedHttpTrigger.TestAuthenticatedEndpoint))]
        [OpenApiOperation(
            operationId: "testAuthenticationEndpoint"
            , tags: new[] { "authentication" }
            , Summary = "Returns success if valid bearer token", Description = "Validates the user bearer to token against azure b2c.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("CoinGardenWorld_Auth", SecuritySchemeType.OAuth2, Flows = typeof(CgwAuthFlow))]
        public async Task<HttpResponseData> TestAuthenticatedEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req) {

            _logger.LogInformation("TestAuthenticatedEndpoint HTTP trigger function processed a request.");


            var principal = await _authentication.AuthenticateAsync(req.FunctionContext, req);
            if (principal == null) return _authentication.ReplyUnauthorized(req);

            var microsoftGraphToken = new BaseBearerTokenAuthenticationProvider(new TokenProvider(req, _authentication,
                new [] {"openid", "offline_access" }));

            var microsoftGraph = new GraphServiceClient(microsoftGraphToken);

            // TODO:  MICROSOFT GRAPH Error: Assertion failed signature validation. [Reason - The key was not found.
            //var inbox = await microsoftGraph.Me.GetAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var userName = principal.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            response.WriteString($"{userName} - Welcome to Azure Functions!");

            return response;
        }
    }
}
