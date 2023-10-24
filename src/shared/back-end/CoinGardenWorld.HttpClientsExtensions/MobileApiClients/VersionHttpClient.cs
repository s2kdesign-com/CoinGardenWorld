using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class VersionHttpClient : HttpClientBase<VersionHttpClient, string>
    {
        public VersionHttpClient(ILogger<VersionHttpClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }
    }
}
