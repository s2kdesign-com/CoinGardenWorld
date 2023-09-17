using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CoinGardenBotCore.Triggers {
    public class ApplicationInfoHttpTrigger {
        private readonly ILogger<ApplicationInfoHttpTrigger> _logger;
        private readonly HealthCheckService _healthCheck;

        public ApplicationInfoHttpTrigger(ILogger<ApplicationInfoHttpTrigger> logger , HealthCheckService healthCheck)
        {
            _logger = logger;
            _healthCheck = healthCheck;
        }



        [FunctionName("getVersion")]
        public async Task<IActionResult> GetVersion([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "app/getVersion")] HttpRequest req)
        {
            return new OkObjectResult(Assembly.GetExecutingAssembly().GetName().Version);
        }

        [FunctionName("health")]
        public async Task<IActionResult> Health([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "app/health")] HttpRequest req)
        {

            var healthStatus = await _healthCheck.CheckHealthAsync();
            if (healthStatus.Status != HealthStatus.Healthy)
            {
                return new BadRequestObjectResult(healthStatus);
            }

            return new OkObjectResult(healthStatus);
        }


    }
}
