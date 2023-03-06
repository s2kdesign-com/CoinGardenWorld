using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Microsoft.Extensions.Options;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace CoinGardenWorld.BingSearch {
    public class AzureWebSearch {
        private readonly WebSearchClient _client;
        private readonly HttpClient _httpClient;
        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string RESPONSE_FILTER_PARAMETER = "&responseFilter="; //"Only these values are allowed: Webpages,Images,Videos,News,SpellSuggestions,entities,places,RelatedSearches,Computation,TimeZone,Translations"
        private const string COUNT_PARAMETER = "&count=";
        private const string OFFSET_PARAMETER = "&offset=";
        private const string FRESHNESS_PARAMETER = "&freshness=";
        private const string SAFE_SEARCH_PARAMETER = "&safeSearch=";
        private const string TEXT_DECORATIONS_PARAMETER = "&textDecorations=";
        private const string TEXT_FORMAT_PARAMETER = "&textFormat=";
        private const string ANSWER_COUNT = "&answerCount=";
        private const string PROMOTE = "&promote=";

        private readonly string _endpoint = Environment.GetEnvironmentVariable("AzureSearchSettings__Endpoint")??"";
        private  readonly string _subscriptionKey = Environment.GetEnvironmentVariable("AzureSearchSettings__SubscriptionKey")??"";

        public AzureWebSearch()
        {
            _httpClient = new HttpClient()
            {
                 BaseAddress = new Uri(_endpoint)
            };
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            // TODO: Not working, always returns 404
            //_client = new WebSearchClient(new ApiKeyServiceClientCredentials(_subscriptionKey))
            //{
            //    Endpoint = _endpoint 
            //} ;
        }


        public async Task<SearchResponse> SearchByTextAsync(string text, int countPages = 1, string language = "en-us") {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("SEARCHING WEB FOR TEXT");
            Console.WriteLine();

            var queryString = QUERY_PARAMETER + Uri.EscapeDataString(text);
            queryString += MKT_PARAMETER + language;
            queryString += RESPONSE_FILTER_PARAMETER + "Webpages";
            queryString += COUNT_PARAMETER + countPages;

            var response = await _httpClient.GetAsync("/v7.0/search" + queryString);

            SearchResponse results = JsonConvert.DeserializeObject<SearchResponse>(await response.Content.ReadAsStringAsync());

            //IList<string> responseFilterstrings = new List<string>() { "Webpages" };

            try
            {

                //results = await _client.Web.SearchAsync(query: text, responseFilter: responseFilterstrings);

                Console.WriteLine(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return results;

        }
    }
}