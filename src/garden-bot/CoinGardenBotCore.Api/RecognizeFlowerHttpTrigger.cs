using System.Collections.Generic;
using System.Net;
using CoinGardenBotCore_Api.Models.Requests;
using CoinGardenBotCore_Api.Models.Responses;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
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
        [OpenApiOperation(operationId: nameof(RecognizeFlowerHttpTrigger.RecognizeFlowerByName), tags: new[] { nameof(RecognizeFlowerByNameRequest) }, Summary = "Recognizes flowers by name", Description = "", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(RecognizeFlowerByNameRequest), Required = true, Description = "Recognize Flower By Name Request")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(RecognizeFlowerByNameResponse), Summary = "successful operation", Description = "successful operation")]
        public HttpResponseData RecognizeFlowerByName([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
