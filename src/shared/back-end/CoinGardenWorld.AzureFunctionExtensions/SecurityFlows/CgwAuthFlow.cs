using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CoinGardenWorld.AzureFunctionExtensions.SecurityFlows {
    public class CgwAuthFlow : OpenApiOAuthSecurityFlows
    {

        private readonly string _scopesUrlPrefix =Environment.GetEnvironmentVariable("AzureAd__ScopesPrefix") + Environment.GetEnvironmentVariable("AzureAd__ClientId");
        private readonly string _scopes =Environment.GetEnvironmentVariable("AzureAd__Scopes");
        public CgwAuthFlow()
        {
            var scopesFormated = _scopes.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var scopesList = new Dictionary<string, string>();
            foreach (var scope in scopesFormated)
            {
                scopesList.Add($"{_scopesUrlPrefix}/{scope.Split(':', StringSplitOptions.RemoveEmptyEntries)[0]}", scope.Split(':', StringSplitOptions.RemoveEmptyEntries)[1]);
            }

            this.Implicit = new OpenApiOAuthFlow() {
                
                AuthorizationUrl = new Uri(Environment.GetEnvironmentVariable("AzureAd__Authority") + "oauth2/v2.0/authorize"),
                TokenUrl = new Uri(Environment.GetEnvironmentVariable("AzureAd__Authority") + "oauth2/v2.0/token"),
                Scopes = scopesList
            };
        }

    
    }
}
