using System.Collections.Generic;
using System.Net;
using System.Reflection;
using CoinGardenBotCore_Api.Models.DTO;
using CoinGardenBotCore_Api.Models.Requests;
using CoinGardenBotCore_Api.Models.Responses;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CoinGardenBotCore.Api
{
    public class ApplicationInfoHttpTrigger {
        private readonly ILogger _logger;

        public ApplicationInfoHttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ApplicationInfoHttpTrigger>();
        }

        [Function(nameof(ApplicationInfoHttpTrigger.Ping))]
        [OpenApiOperation(operationId: "ping", tags: new[] { "ping" }, Summary = "Pings for health check", Description = "This pings for health check.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Summary = "Successful operation", Description = "Successful operation")]
        public async Task<HttpResponseData> Ping(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "ping")] HttpRequestData req) {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteStringAsync("pong").ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(ApplicationInfoHttpTrigger.GetVersion))]
        [OpenApiOperation(operationId: "getVersion", tags: new[] { "version" }, Summary = "Gets the API Version", Description = "Used from Frond-end APPs to check if compatible.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Summary = "Successful operation", Description = "Successful operation")]
        public async Task<HttpResponseData> GetVersion(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "version")] HttpRequestData req) {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            await response.WriteStringAsync(version.ToString()).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}
