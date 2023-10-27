using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.SignalRClientsExtensions.Providers
{
    public class BlazorServerTokenProvider : IAccessTokenProvider
    {
        public BlazorServerTokenProvider()
        {
            // TODO: Add IAuthorizationHeaderProvider

        }
        public ValueTask<AccessTokenResult> RequestAccessToken()
        {
            return ValueTask.FromResult(new AccessTokenResult(AccessTokenResultStatus.Success, new AccessToken(), ""));
        }

        public ValueTask<AccessTokenResult> RequestAccessToken(AccessTokenRequestOptions options)
        {
            return ValueTask.FromResult(new AccessTokenResult(AccessTokenResultStatus.Success, new AccessToken(), ""));
        }
    }
}
