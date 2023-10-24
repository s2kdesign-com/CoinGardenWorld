
namespace CoinGardenWorld.HttpClientsExtensions.Infrastructure
{
    public class BlazorServerTokenProvider
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? XsrfToken { get; set; }
    }
}
