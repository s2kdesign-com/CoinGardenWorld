
namespace CoinGardenWorld.Theme.Configurations {
    public class ExternalApisSettings {
        public Dictionary<string, ExternalApiSettings> ExternalApis { get; set; }
    }

    public class ExternalApiSettings
    {
        public string Api_Url { get; set; }
        public List<string> Api_Scopes { get; set; }
    }
}
