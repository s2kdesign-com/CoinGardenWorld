using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.AzureFunctionExtensions.SecurityFlows {
    public class CgwAuthFlow : OpenApiOAuthSecurityFlows
    {
        private readonly string _scopesUrlPrefix = $"https://coingardenworld.onmicrosoft.com/{Environment.GetEnvironmentVariable("AzureADB2C__OpenID__ClientId")}";
        public CgwAuthFlow() {

            this.Implicit = new OpenApiOAuthFlow() {
                AuthorizationUrl = new Uri(new Uri(Environment.GetEnvironmentVariable("AzureADB2C__OpenID__Url") ?? ""), "oauth2/v2.0/authorize"),
                TokenUrl = new Uri(new Uri(Environment.GetEnvironmentVariable("AzureADB2C__OpenID__Url") ?? ""), "oauth2/v2.0/token"),
                Scopes = {
                {
                    $"{_scopesUrlPrefix}/flowers.readbyname", "Get Flowers by name"
                },
                {
                    $"{_scopesUrlPrefix}/flowers.readbypicture", "Get Flowers by picture"

                },
                {
                    $"{_scopesUrlPrefix}/flowers.readbyurl", "Get Flowers by Url"

                }
                }
            };
        }

    
    }
}
