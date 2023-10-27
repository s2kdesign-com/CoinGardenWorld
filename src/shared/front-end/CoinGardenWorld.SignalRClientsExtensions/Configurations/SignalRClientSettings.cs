
namespace CoinGardenWorld.SignalRClientsExtensions.Configurations {
    public class SignalRClientsSettings
    {
        public Dictionary<string, SignalRClient>? SignalRClients { get; set; }
    }

    public class SignalRClient
    {
        public string Client_Url { get; set; }
        public List<string> Client_Scopes { get; set; }
    }
}
