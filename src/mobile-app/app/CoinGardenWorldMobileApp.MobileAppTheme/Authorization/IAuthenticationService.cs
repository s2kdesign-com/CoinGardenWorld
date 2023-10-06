using Microsoft.Identity.Client;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Authorization
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult?> AcquireTokenSilentAsync();
        public Task<AuthenticationResult?> AcquireTokenInteractiveAsync();
    }
}