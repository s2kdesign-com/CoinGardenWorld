using CoinGardenWorld.SignalRClientsExtensions;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Abstractions;
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using CoinGardenWorld.SignalRClientsExtensions.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.DownstreamSignalRExtensions.Providers
{
    public class BlazorSignalRTokenProvider<T> : IBlazorSignalRTokenProvider
    {
        readonly IAuthorizationHeaderProvider _authorizationHeaderProvider;
        readonly ILogger<BlazorSignalRTokenProvider<T>> _logger;
        readonly IConfiguration _configuration;

        private readonly string _hubKey = "chathub";
        // Default scope
        private readonly List<string> scopes = new List<string> { "MobileApi.read" };

        public BlazorSignalRTokenProvider(IAuthorizationHeaderProvider authorizationHeaderProvider, IConfiguration configuration, ILogger<BlazorSignalRTokenProvider<T>> logger)
        {
            _authorizationHeaderProvider = authorizationHeaderProvider;
            _configuration = configuration;
            _logger = logger;

            _hubKey = typeof(T).Name.ToLower();

            var signalRClientSettings = new SignalRClientsSettings();
            _configuration.Bind(signalRClientSettings);
            if (signalRClientSettings.SignalRClients != null && signalRClientSettings.SignalRClients.ContainsKey(_hubKey))
            {
                scopes = signalRClientSettings.SignalRClients[_hubKey].Client_Scopes;
            }
        }
        public async ValueTask<AccessTokenResult> RequestAccessToken()
        {
            try
            {

                string accessToken = await _authorizationHeaderProvider.CreateAuthorizationHeaderForUserAsync(scopes);
                return new AccessTokenResult(AccessTokenResultStatus.Success, new AccessToken { Value = accessToken }, "");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new AccessTokenResult(AccessTokenResultStatus.RequiresRedirect, new AccessToken(), "");
        }

        public async ValueTask<AccessTokenResult> RequestAccessToken(AccessTokenRequestOptions options)
        {
            try
            {

                string accessToken = await _authorizationHeaderProvider.CreateAuthorizationHeaderForUserAsync(scopes);
                return new AccessTokenResult(AccessTokenResultStatus.Success, new AccessToken { Value = accessToken }, "");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new AccessTokenResult(AccessTokenResultStatus.RequiresRedirect, new AccessToken(), "");
        }
    }
}
