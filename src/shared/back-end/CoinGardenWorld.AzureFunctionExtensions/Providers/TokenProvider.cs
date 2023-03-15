using Microsoft.Kiota.Abstractions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Http;

namespace CoinGardenWorld.AzureFunctionExtensions.Providers {
    public class TokenProvider : IAccessTokenProvider
    {
        private readonly HttpRequestData _req;
        private readonly AuthenticationProvider _authentication;
        private readonly string[] _scopes;

        public TokenProvider(HttpRequestData req, AuthenticationProvider authentication, string[] scopes)
        {
            _req = req;
            _authentication = authentication;
            _scopes = scopes;
        }
        public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
            CancellationToken cancellationToken = default) {
            // get the token and return it
            var token = await _authentication.GetAccessTokenForUserAsync(_req, _scopes);
            return await Task.FromResult(token);
        }

        public AllowedHostsValidator AllowedHostsValidator { get; }
    }
}
