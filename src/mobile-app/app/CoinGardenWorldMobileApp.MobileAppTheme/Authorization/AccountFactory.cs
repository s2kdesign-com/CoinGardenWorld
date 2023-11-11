using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using System.Net.Http.Json;
using CoinGardenWorld.HttpClientsExtensions;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Authorization
{
    public class AccountFactory : AccountClaimsPrincipalFactory<UserAccount>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountFactory(IAccessTokenProviderAccessor accessor, IHttpClientFactory httpClientFactory)
            : base(accessor)
        {
            _httpClientFactory = httpClientFactory;
        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(UserAccount account, RemoteAuthenticationUserOptions options)
        {            
            ClaimsPrincipal initialUser = await base.CreateUserAsync(account, options);

            if (initialUser?.Identity?.IsAuthenticated ?? false)
            {
                try
                {

                    // TODO: Change the mobile api key to not magic string
                    var httpClient = _httpClientFactory.CreateClient("CGW.Mobile.Api_AuthenticationClient");

                    var response = await httpClient.GetAsync("api/profile/getroles");
                    if(response.IsSuccessStatusCode)
                    {

                        var userIdentity = (ClaimsIdentity)initialUser.Identity;

                        var roles = await response.Content.ReadFromJsonAsync<AccountRole[]>();

                        if (roles != null && roles.Any())
                        {
                            await Console.Out.WriteLineAsync("Currently Assigned Roles: " + String.Join(',', roles.Select(r => r.RoleName)));

                            foreach (var accountRole in roles)
                            {
                                userIdentity.AddClaim(new Claim(ClaimTypes.Role, accountRole.RoleName));
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return initialUser ?? new ClaimsPrincipal();
        }
    }
}
