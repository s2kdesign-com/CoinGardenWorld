using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace CoinGardenWorldMobileApp.Maui.Authorization
{
    public class AuthenticationService : IAuthenticationService
    {
        // I recommend storing this in appsettings.json and grabbing it from IConfiguration instead
        private readonly IPublicClientApplication authenticationClient;
        private readonly string[] _scopes = new[] { "User.Read" };
        private readonly string _tenantId = "6a1cff20-8c30-408d-b1ac-2614c4766cf7";
        private readonly string _clientId = "dc8267ed-55c8-4537-8b34-b408d87b8a92";

        public AuthenticationService()
        {
            authenticationClient = PublicClientApplicationBuilder.Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId) // Only allow accounts in the tenant to authenticate
                .WithRedirectUri($"msal{_clientId}://auth")
                .Build();
        }

        public async Task<AuthenticationResult?> AcquireTokenSilentAsync()
        {
            var accounts = await authenticationClient.GetAccountsAsync();

            AuthenticationResult? result;
            try
            {
                result = await authenticationClient.AcquireTokenSilent(_scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                // Acquiring silently failed; need to acquire the token interactively
                result = await AcquireTokenInteractiveAsync();
            }

            return result;
        }

        public async Task<AuthenticationResult?> AcquireTokenInteractiveAsync()
        {
            if (authenticationClient == null)
                return null;

            AuthenticationResult result;
            try
            {
                result = await authenticationClient.AcquireTokenInteractive(_scopes)
                    .WithTenantId(_tenantId)
                    .ExecuteAsync()
                    .ConfigureAwait(false);

                return result;
            }
            catch (MsalClientException)
            {
                return null;
            }
        }
    }
}
