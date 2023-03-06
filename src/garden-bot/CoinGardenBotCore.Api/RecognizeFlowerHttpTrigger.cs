using System.Collections.Generic;
using System.Net;
using CoinGardenBotCore_Api.Models.DTO;
using CoinGardenBotCore_Api.Models.Requests;
using CoinGardenBotCore_Api.Models.Responses;
using CoinGardenWorld.AzureAI;
using HttpMultipartParser;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Localization;
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

        //RecognizeFlowerByName
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

        //RecognizeFlowerByPicture
        [Function(nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByPicture))]
        [OpenApiOperation(operationId: "uploadFile", tags: new[] { "flowers" }, Summary = "Uploads an image", Description = "This uploads an image.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "multipart/form-data", bodyType: typeof(RecognizeFlowerByPictureRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizedFlowerResponse), Summary = "successful operation", Description = "successful operation")]
        public async Task<HttpResponseData> RecognizeFlowerByPicture(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "flower/findByPicture")] HttpRequestData req) {

            _logger.LogInformation("Triggered RecognizeFlowerByPicture");

            // get form-body        
            var formBody = await MultipartFormDataParser.ParseAsync(req.Body);

            var response = req.CreateResponse(HttpStatusCode.OK);

            if (formBody == null || !formBody.Files.Any())
            {
                response = req.CreateResponse(HttpStatusCode.BadRequest);
                return await Task.FromResult(response).ConfigureAwait(false);
            }

            var imageVisionResults = await _azureComputerVision.AnalyzeImageInStreamAsync(formBody.Files[0].Data);
            await response.WriteAsJsonAsync(imageVisionResults).ConfigureAwait(false);
            return await Task.FromResult(response).ConfigureAwait(false);
        }

        //RecognizeFlowerByUrl
        [Function(nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByUrl))]
        [OpenApiOperation(operationId: "findFlowersByUrl", tags: new[] { "flowers" }, Summary = "Finds flowers by picture url", Description = "", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(RecognizeFlowerByUrlRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizedFlowerResponse), Summary = "successful operation", Description = "successful operation")]
        public async Task<HttpResponseData> RecognizeFlowerByUrl(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = "flower/findByUrl")] HttpRequestData req) {

            _logger.LogInformation("Triggered RecognizeFlowerByUrl");

            var requestBody = JsonConvert.DeserializeObject<List<RecognizeFlowerByUrlRequest>>(await req.ReadAsStringAsync());
            var response = req.CreateResponse(HttpStatusCode.OK);
            
            if (requestBody== null || !requestBody.Any())
            {
                response = req.CreateResponse(HttpStatusCode.BadRequest);
                return await Task.FromResult(response).ConfigureAwait(false);
            }

            using (var client = new HttpClient())
            {
                var imageStream = await client.GetStreamAsync(requestBody[0].contentUrl);
                var imageVisionResults = await _azureComputerVision.AnalyzeImageInStreamAsync(imageStream);

                await response.WriteAsJsonAsync(imageVisionResults).ConfigureAwait(false);

                return await Task.FromResult(response).ConfigureAwait(false);
            }

        }
    }
}
