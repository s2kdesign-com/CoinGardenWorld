using System.Net;
using CoinGardenWorld.AzureFunctionExtensions.SecurityFlows;
using CoinGardenWorld.AzureFunctionExtensions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace CoinGardenWorldMobileApp_Api {
    public class MobileAppWebHttpTrigger {
        private readonly ILogger _logger;

        private static string[] roles =
        {
            // TODO: Find what are this roles 
            //"Data.Read", "Data.ReadWrite"
        };

        public MobileAppWebHttpTrigger(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<MobileAppWebHttpTrigger>();
        }

        [Function(nameof(MobileAppWebHttpTrigger.TestAuthenticatedEndpoint))]
        [OpenApiOperation(operationId: "testAuthenticationEndpoint", tags: new[] { "authentication" }, Summary = "Returns success if valid bearer token", Description = "Validates the user bearer to token against azure b2c.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("CoinGardenWorld_Auth", SecuritySchemeType.OAuth2, Flows = typeof(CgwAuthFlow))]
        public async Task<HttpResponseData> TestAuthenticatedEndpoint([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req) {

            var response = req.CreateResponse(HttpStatusCode.OK);

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Validate JWT Token
            var tokenValidator = new TokenValidator(_logger);
            var claimsPrincipal = await tokenValidator.ValidateTokenAsync(req);
            if (!tokenValidator.HasRightRolesAndScope(claimsPrincipal, "flowers.readbyurl"))
            {
                response = req.CreateResponse(HttpStatusCode.Unauthorized);
                return response;
            }
            // END Validate JWT Token

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
