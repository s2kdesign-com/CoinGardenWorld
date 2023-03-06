using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.Net;
using CoinGardenWorld.AzureAI.Configurations;
using Microsoft.Extensions.Options;

namespace CoinGardenWorld.AzureAI {
    public class AzureComputerVision {
        private readonly ComputerVisionClient _client;

        public AzureComputerVision(IOptions<AzureAISettings> settings)
        {
            Console.WriteLine("Azure Cognitive Services Computer Vision - Started");
            Console.WriteLine();

            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(settings.Value.SubscriptionKey)) { Endpoint = settings.Value.Endpoint };
        }

        public async Task<ImageAnalysis> AnalyzeImageUrl(string imageUrl) {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("ANALYZE IMAGE - URL");
            Console.WriteLine();

            // Creating a list that defines the features to be extracted from the image. 

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Description,

            };

            // Analyze the URL image 
            ImageAnalysis results = await _client.AnalyzeImageAsync(imageUrl, visualFeatures: features);
            // Image tags and their confidence score
            Console.WriteLine("Tags:");
            foreach (var tag in results.Tags) {
                Console.WriteLine($"{tag.Name} {tag.Confidence}");
            }
            Console.WriteLine();


            return results;
        }
        public async Task<ImageAnalysis> AnalyzeImageInStreamAsync(Stream imageFile) {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("ANALYZE IMAGE - URL");
            Console.WriteLine();

            // Creating a list that defines the features to be extracted from the image. 

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Description,

            };
            // Analyze the URL image 
            ImageAnalysis results = await _client.AnalyzeImageInStreamAsync(imageFile, visualFeatures: features);
            // Image tags and their confidence score
            Console.WriteLine("Tags:");
            foreach (var tag in results.Tags) {
                Console.WriteLine($"{tag.Name} {tag.Confidence}");
            }
            Console.WriteLine();


            return results;
        }
    }
}