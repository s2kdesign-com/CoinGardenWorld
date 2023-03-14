using System.Net;
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

namespace CoinGardenWorldMobileApp_Api {
    public class MobileAppWebHttpTrigger {
        private readonly ILogger _logger;

        private readonly AuthenticationProvider _authentication;
        private static string[] roles =
        {
            // TODO: Find what are this roles 
            //"Data.Read", "Data.ReadWrite"
        };

        public MobileAppWebHttpTrigger(ILoggerFactory loggerFactory, AuthenticationProvider authentication) {
            _logger = loggerFactory.CreateLogger<MobileAppWebHttpTrigger>();

            _authentication = authentication;
        }

        [Function(nameof(MobileAppWebHttpTrigger.TestAuthenticatedEndpoint))]
        [OpenApiOperation(operationId: "testAuthenticationEndpoint", tags: new[] { "authentication" }, Summary = "Returns success if valid bearer token", Description = "Validates the user bearer to token against azure b2c.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("CoinGardenWorld_Auth", SecuritySchemeType.OAuth2, Flows = typeof(CgwAuthFlow))]
        public async Task<HttpResponseData> TestAuthenticatedEndpoint([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req) {

            _logger.LogInformation("TestAuthenticatedEndpoint HTTP trigger function processed a request.");


            var principal = await _authentication.AuthenticateAsync(req.FunctionContext, req);
            if (principal == null) return _authentication.ReplyUnauthorized(req);

            //var token = await _authentication.GetAccessTokenForUserAsync(req, new string[] { "https://graph.microsoft.com/openid" });

            //var microsoftGraph = new GraphServiceClient(new BaseBearerTokenAuthenticationProvider(new TokenProvider(token)));
            //var name = principal.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").First().Value;
            //_logger.LogInformation($"User is {name}!");

            //var inbox = await microsoftGraph.Me.MailFolders["inbox"].GetAsync();
            //_logger.LogInformation($"{name} has {inbox.UnreadItemCount} unread e-mails!");

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
