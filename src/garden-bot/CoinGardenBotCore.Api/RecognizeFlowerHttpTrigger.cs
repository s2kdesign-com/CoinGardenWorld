using System.Collections.Generic;
using System.Net;
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
    public class RecognizeFlowerHttpTrigger {
        private readonly ILogger _logger;

        public RecognizeFlowerHttpTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RecognizeFlowerHttpTrigger>();
        }
        

        [Function(nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByName))]
        [OpenApiOperation(operationId: "findFlowersByName", tags: new[] { nameof(RecognizeFlowerByNameRequest) }, Summary = "Recognizes flowers by name", Description = "Multiple flower names can be provided with comma separated strings.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(RecognizeFlowerByNameRequest), Explode = true, Summary = "Flower Name", Description = "Name values that need to be considered for filter", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizeFlowerByNameRequest), Summary = "successful operation", Description = "successful operation")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid flower name", Description = "Invalid flower name")]
        public async Task<HttpResponseData> RecognizeFlowerByName(
      [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "flower/findByName")] HttpRequestData req) {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var name = req.Query("name");
            var flowers = new List<RecognizedFlowerModel> { new RecognizedFlowerModel {  Name = name, Region = "Bulgaria", Probability = 99.5 } };
            await response.WriteAsJsonAsync(flowers).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

    }
}
