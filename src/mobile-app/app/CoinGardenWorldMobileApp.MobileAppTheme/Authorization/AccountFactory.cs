using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Authorization
{
    public class AccountFactory : AccountClaimsPrincipalFactory<UserAccount>
    {
        public AccountFactory(IAccessTokenProviderAccessor accessor)
            : base(accessor)
        {

        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(UserAccount account, RemoteAuthenticationUserOptions options)
        {

            ClaimsPrincipal initialUser = await base.CreateUserAsync(account, options);

            if (initialUser?.Identity?.IsAuthenticated ?? false)
            {
                var userIdentity = (ClaimsIdentity)initialUser.Identity;

                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Garden Guru"));
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Plant Maestro"));
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, "Flora Pioneer"));
            }

            return initialUser ?? new ClaimsPrincipal();
        }
    }
}
