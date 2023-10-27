using CoinGardenWorld.HttpClientsExtensions.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.HttpClientsExtensions.DelegatingHandlers
{
    public class BlazorServerAuthorizationMessageHandler : DelegatingHandler, IDisposable
    {
        private readonly ILogger<BlazorServerAuthorizationMessageHandler> _logger;
        private readonly BlazorServerTokens _tokenProvider;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigation;
        private readonly AuthenticationStateChangedHandler _authenticationStateChangedHandler;

        private AccessTokenRequestOptions _tokenOptions;
        private AuthenticationHeaderValue _cachedHeader;
        private Uri[] _authorizedUris;
        private AccessToken? _lastToken;

        public BlazorServerAuthorizationMessageHandler(ILogger<BlazorServerAuthorizationMessageHandler> logger, BlazorServerTokens tokenProvider, AuthenticationStateProvider authStateProvider, NavigationManager navigation)
        {
            _logger = logger;
                _tokenProvider = tokenProvider;
            _authStateProvider = authStateProvider;
            _navigation = navigation;
            authStateProvider.AuthenticationStateChanged += _authenticationStateChangedHandler;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.Now;
            if (_authorizedUris == null)
            {
                throw new InvalidOperationException($"The '{nameof(BlazorServerAuthorizationMessageHandler)}' is not configured. " +
                                                    $"Call '{nameof(BlazorServerAuthorizationMessageHandler.ConfigureHandler)}' and provide a list of endpoint urls to attach the token to.");
            }
            if(_tokenProvider.AccessToken == null)
            {
                _lastToken = new AccessToken();
                throw new AccessTokenNotAvailableException(_navigation, new AccessTokenResult(AccessTokenResultStatus.RequiresRedirect, _lastToken, ""), _tokenOptions?.Scopes);
            }
            else
            {
                _lastToken = new AccessToken();
                _lastToken.Expires = DateTimeOffset.Now.AddHours(1);
                _lastToken.Value = _tokenProvider.AccessToken;
            }

            if (_authorizedUris.Any(uri => uri.IsBaseOf(request.RequestUri)))
            {
                if (_lastToken != null || now <= _lastToken.Expires.AddMinutes(-5))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.AccessToken);
                }
                else
                {
                    // TODO: Trigger redirect or challenge the request when the token is expired
                    _logger.LogError("Token Expired");
                    throw new AccessTokenNotAvailableException(_navigation, new AccessTokenResult(AccessTokenResultStatus.RequiresRedirect, _lastToken, ""), _tokenOptions?.Scopes);

                }
            }


            return await base.SendAsync(request, cancellationToken);
        }

        public BlazorServerAuthorizationMessageHandler ConfigureHandler(
            IEnumerable<string> authorizedUrls,
            IEnumerable<string> scopes = null,
            string? returnUrl = null)
        {
            if (_authorizedUris != null)
            {
                throw new InvalidOperationException("Handler already configured.");
            }

            if (authorizedUrls == null)
            {
                throw new ArgumentNullException(nameof(authorizedUrls));
            }

            var uris = authorizedUrls.Select(uri => new Uri(uri, UriKind.Absolute)).ToArray();
            if (uris.Length == 0)
            {
                throw new ArgumentException("At least one URL must be configured.", nameof(authorizedUrls));
            }

            _authorizedUris = uris;
            var scopesList = scopes?.ToArray();
            if (scopesList != null || returnUrl != null)
            {
                _tokenOptions = new AccessTokenRequestOptions
                {
                    Scopes = scopesList,
                    ReturnUrl = returnUrl
                };
            }

            return this;
        }

        void IDisposable.Dispose()
        {
            _authStateProvider.AuthenticationStateChanged -= _authenticationStateChangedHandler;
            
            Dispose(disposing: true);
        }
    }
}
