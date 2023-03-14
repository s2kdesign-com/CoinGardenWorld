using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;

namespace CoinGardenWorld.AzureFunctionExtensions.Services {
    public class AzureAdJwtBearerValidation {
        private IConfiguration _configuration;
        private const string scopeType = @"http://schemas.microsoft.com/identity/claims/scope";
        private static ConfigurationManager<OpenIdConnectConfiguration> _configurationManager;

        private string _wellKnownEndpoint = string.Empty;
        private string _audience = string.Empty;

        public AzureAdJwtBearerValidation(IConfiguration configuration) {
            _configuration = configuration;

            _audience = _configuration["AzureAd:ClientId"];
            _wellKnownEndpoint = $"{_configuration["AzureAd:Authority"]}/v2.0/.well-known/openid-configuration";
        }

        public async Task<ClaimsPrincipal> ValidateTokenAsync(string token, ILogger logger) {
            if (string.IsNullOrEmpty(token)) {
                return null;
            }

            var oidcWellknownEndpoints = await GetOidcWellKnownConfiguration(logger);

            IdentityModelEventSource.ShowPII = true;

            var tokenValidator = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters {

                ValidAudiences = new string[] { _audience },
                ValidateAudience = true,

                ValidateIssuer = true,
                ValidIssuers = new[] { oidcWellknownEndpoints.Issuer },

                IssuerSigningKeys = oidcWellknownEndpoints.SigningKeys,
                // Number of keys in TokenValidationParameters: '2'. 
                // Number of keys in Configuration: '0'.
                ValidateIssuerSigningKey = false,

                ValidateLifetime = true,
                RequireSignedTokens = false,
            };

            try {
                SecurityToken securityToken;
                var claimsPrincipal = tokenValidator.ValidateToken(token, validationParameters, out securityToken);

                return claimsPrincipal;
            }
            catch (Exception ex) {
                logger.LogError(ex.ToString());
            }

            return null;
        }

        private async Task<OpenIdConnectConfiguration> GetOidcWellKnownConfiguration(ILogger logger) {
            if (_configurationManager == null) {
                logger.LogDebug($"Get OIDC well known endpoints {_wellKnownEndpoint}");
                _configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(_wellKnownEndpoint, new OpenIdConnectConfigurationRetriever());
            }

            return await _configurationManager.GetConfigurationAsync();
        }

        public bool IsScopeValid(ClaimsPrincipal claimsPrincipal, string scopeName, ILogger logger) {
            if (claimsPrincipal == null) {
                logger.LogWarning($"Scope invalid {scopeName}");
                return false;
            }

            var scopeClaim = claimsPrincipal.HasClaim(x => x.Type == scopeType)
                ? claimsPrincipal.Claims.First(x => x.Type == scopeType).Value
                : string.Empty;

            if (string.IsNullOrEmpty(scopeClaim)) {
                logger.LogWarning($"Scope invalid {scopeName}");
                return false;
            }

            if (!scopeClaim.Equals(scopeName, StringComparison.OrdinalIgnoreCase)) {
                logger.LogWarning($"Scope invalid {scopeName}");
                return false;
            }

            logger.LogDebug($"Scope valid {scopeName}");
            return true;
        }
    }
}