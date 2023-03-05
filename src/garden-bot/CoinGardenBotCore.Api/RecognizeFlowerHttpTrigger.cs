using System.Collections.Generic;
using System.Net;
using CoinGardenBotCore_Api.Models.DTO;
using CoinGardenBotCore_Api.Models.Requests;
using CoinGardenBotCore_Api.Models.Responses;
using CoinGardenWorld.AzureAI;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CoinGardenBotCore.Api {
    public class RecognizeFlowerHttpTrigger {
        private readonly ILogger _logger;
        private readonly AzureComputerVision _azureComputerVision;

        public RecognizeFlowerHttpTrigger(ILoggerFactory loggerFactory, AzureComputerVision azureComputerVision) {
            _logger = loggerFactory.CreateLogger<RecognizeFlowerHttpTrigger>();
            _azureComputerVision = azureComputerVision;
        }


        [Function(nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByName))]
        [OpenApiOperation(operationId: "findFlowersByName", tags: new[] { "flowers" }, Summary = "Recognizes flowers by name", Description = "Multiple flower names can be provided with comma separated strings.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(RecognizeFlowerByNameRequest), Explode = true, Summary = "Flower Name", Description = "Name values that need to be considered for filter", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizedFlowerResponse), Summary = "successful operation", Description = "successful operation")]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Invalid flower name", Description = "Invalid flower name")]
        public async Task<HttpResponseData> RecognizeFlowerByName(
      [HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "flower/findByName")] HttpRequestData req) {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var name = req.Query("name");
            var response = req.CreateResponse(HttpStatusCode.OK);
            if (string.IsNullOrEmpty(name)) {
                response = req.CreateResponse(HttpStatusCode.BadRequest);
                return await Task.FromResult(response).ConfigureAwait(false);
            }

            var flowers = new List<RecognizedFlowerModel> { new RecognizedFlowerModel { Name = name, Region = "Bulgaria", Probability = 99.5 } };
            await response.WriteAsJsonAsync(flowers).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }

        [Function(nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByPicture))]
        [OpenApiOperation(operationId: "uploadFile", tags: new[] { "flowers" }, Summary = "Uploads an image", Description = "This uploads an image.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "multipart/form-data", bodyType: typeof(RecognizeFlowerByPictureRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizedFlowerResponse), Summary = "successful operation", Description = "successful operation")]
        public async Task<HttpResponseData> RecognizeFlowerByPicture(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "flower/findByPicture")] HttpRequestData req) {

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var imageVisionResults = await _azureComputerVision.AnalyzeImageUrl(
                "https://img.freepik.com/free-photo/still-life-close-up-flower-indoors_23-2148965612.jpg");


            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(imageVisionResults).ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}
