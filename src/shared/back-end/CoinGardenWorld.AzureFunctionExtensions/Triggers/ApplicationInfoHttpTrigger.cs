using System.Collections.Generic;
using System.Net;
using System.Reflection;
using CoinGardenWorld.AzureFunctionExtensions.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CoinGardenWorld.AzureFunctionExtensions.Triggers {
    public class ApplicationInfoHttpTrigger {
        private readonly ILogger _logger;
        private readonly HealthCheckService _healthCheck;

        public ApplicationInfoHttpTrigger(ILoggerFactory loggerFactory, HealthCheckService healthCheck)
        {
            _logger = loggerFactory.CreateLogger<ApplicationInfoHttpTrigger>();
            _healthCheck = healthCheck;
        }

        [Function(nameof(ApplicationInfoHttpTrigger.Health))]
        [OpenApiOperation(operationId: "health", tags: new[] { "health" }, Summary = "Health check", Description = "This pings for health check.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(HealthReport), Summary = "Successful operation", Description = "Successful operation")]
        public async Task<HttpResponseData> Health(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "Health")] HttpRequestData req) {
            var response = req.CreateResponse(HttpStatusCode.OK);

            var healthStatus = await _healthCheck.CheckHealthAsync();
            
            await response.WriteAsJsonAsync(healthStatus).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(ApplicationInfoHttpTrigger.GetVersion))]
        [OpenApiOperation(operationId: "getVersion", tags: new[] { "version" }, Summary = "Gets the API Version", Description = "Used from Frond-end APPs to check if compatible.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Summary = "Successful operation", Description = "Successful operation")]
        public async Task<HttpResponseData> GetVersion(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "version")] HttpRequestData req) {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            // Send API Version
            Version version = ApiConfigurationOptions.GetPackageVersion();

            await response.WriteStringAsync(version.ToString()).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}
