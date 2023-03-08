using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Azure.Functions.Worker.Http;

namespace CoinGardenWorld.AzureFunctionExtensions.Services
{

    public class TokenValidator
    {
        private ILogger log;
        private string token;
        private const string scopeType = @"http://schemas.microsoft.com/identity/claims/scope";

        public string Token
        {
            get { return token; }
            private set { token = value; }
        }

        public TokenValidator( ILogger logger)
        {
            log = logger;
        }

        public void GetJwtFromHeader(HttpRequestData req)
        {
            if (req.Headers.TryGetValues("Authorization", out var authHeaders)) {

                var authorizationHeader = authHeaders.First();
                string[] parts = authorizationHeader?.ToString().Split(null) ?? new string[0];
                Token = (parts.Length == 2 && parts[0].Equals("Bearer")) ? parts[1] : string.Empty;
            }
        }

        public async Task<ClaimsPrincipal> ValidateTokenAsync(HttpRequestData req)
        {
            GetJwtFromHeader(req);
            if (string.IsNullOrEmpty(Token))
            {
                return null;
            }
            
            var jwtHandler = new JwtSecurityTokenHandler();
            var ConfigManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                new Uri(new Uri(Environment.GetEnvironmentVariable("AzureAd__Authority") ??""), "v2.0/.well-known/openid-configuration").ToString(),
                new OpenIdConnectConfigurationRetriever());
            var OIDconfig = await ConfigManager.GetConfigurationAsync();

            var tokenValidator = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidAudiences = new string[] { Environment.GetEnvironmentVariable("AzureAd__ClientId") ??"" },
                ValidateAudience = Boolean.Parse(Environment.GetEnvironmentVariable("AzureAd__ValidateAudience") ??"true") ,
                IssuerSigningKeys = OIDconfig.SigningKeys,
                ValidIssuer = OIDconfig.Issuer
            };

            try
            {
                SecurityToken securityToken;
                var claimsPrincipal = tokenValidator.ValidateToken(token, validationParameters, out securityToken);
                return claimsPrincipal;
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }

            return null;
        }

        public bool HasRightRolesAndScope(ClaimsPrincipal claimsPrincipal, string scopeName, string[] roles = null)
        {
            bool isInRole = false;
            if (claimsPrincipal == null)
            {
                return false;
            }

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    if (claimsPrincipal.IsInRole(role))
                    {
                        isInRole = true;
                    }
                }
                if (!isInRole) {
                    return false;
                }
            }


            var scopeClaim = claimsPrincipal.HasClaim(x => x.Type == scopeType)
                ? claimsPrincipal.Claims.First(x => x.Type == scopeType).Value
                : string.Empty;

            if (string.IsNullOrEmpty(scopeClaim))
            {
                return false;
            }

            if (!scopeClaim.Contains(scopeName, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}
