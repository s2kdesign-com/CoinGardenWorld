using Microsoft.Identity.Client;

namespace CoinGardenWorldMobileApp.Maui.Authorization
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult?> AcquireTokenSilentAsync();
        public Task<AuthenticationResult?> AcquireTokenInteractiveAsync();
    }
}