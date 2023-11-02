using Azure;
using CoinGardenWorld.AzureAI;
using CoinGardenWorld.BingSearch;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class FlowerRecognitionController : ControllerBase
    {
        private readonly ILogger<FlowerRecognitionController> _logger;


        private readonly AzureComputerVision _azureComputerVision;
        private readonly AzureWebSearch _azureWebSearch;

        public FlowerRecognitionController(ILogger<FlowerRecognitionController> logger,
            AzureComputerVision azureComputerVision,
            AzureWebSearch azureWebSearch
            )
        {
            _logger = logger;
            _azureComputerVision = azureComputerVision;
            _azureWebSearch = azureWebSearch;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IEnumerable<ImageAnalysis>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ImageAnalysis>>> ByPictures(IFormFile[] files)
        {
            try
            {
                var imageAnalysisResult = new List<ImageAnalysis>();
                foreach (var item in files)
                {
                    _logger.LogInformation("file uploaded : " + item.FileName);
                    ImageAnalysis imageVisionResults = await _azureComputerVision.AnalyzeImageInStreamAsync(item.OpenReadStream());
                    imageAnalysisResult.Add(imageVisionResults);
                }
                return Ok(imageAnalysisResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(SearchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SearchResponse>> ByName(string name)
        {
            try
            {

                SearchResponse webSearchResult = await _azureWebSearch.SearchByTextAsync(name);
                return Ok(webSearchResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(SearchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ImageAnalysis>> ByUrl(string url)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    var imageStream = await client.GetStreamAsync(url);
                    var imageVisionResults = await _azureComputerVision.AnalyzeImageInStreamAsync(imageStream);

                    return Ok(imageVisionResults);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
