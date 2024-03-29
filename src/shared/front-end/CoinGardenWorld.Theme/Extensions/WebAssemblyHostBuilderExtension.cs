﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using CoinGardenWorld.Theme.Configurations;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;

namespace CoinGardenWorld.Theme.Extensions {
    public static class WebAssemblyHostBuilderExtension {

        public async static Task<WebAssemblyHostBuilder> AddCgwHttpClientExtensions(this WebAssemblyHostBuilder builder)
        {
            // Add External APIs Http clients 
            var settings = new ExternalApisSettings();
            builder.Configuration.Bind(settings);

            // Add External APIs Http clients 
            if (settings != null && settings.ExternalApis != null )
            {
                Console.WriteLine("ExternalApis Detected");
                builder.Services.AddOptions<ExternalApisSettings>("ExternalApis");

                foreach (var externalApisSetting in settings.ExternalApis)
                {
                    builder.Services.AddHttpClient($"{externalApisSetting.Key}.NoAuthenticationClient",
                        client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url));

                    builder.Services.AddHttpClient(externalApisSetting.Key,
                            client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url))
                        .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
                            .ConfigureHandler(
                                authorizedUrls: new[] { externalApisSetting.Value.Api_Url },
                                scopes: externalApisSetting.Value.Api_Scopes));

                }

                // Default API 
                builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CGW.Api.NoAuthenticationClient"));
            }
            else
            {

                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            }
            // END Add API Http clients 


            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

                if (settings.ExternalApis != null && settings.ExternalApis != null)
                    foreach (var externalApisSetting in settings.ExternalApis) {
                        foreach (var apiScope in externalApisSetting.Value.Api_Scopes) {
                            options.ProviderOptions.DefaultAccessTokenScopes.Add(apiScope);
                        }
                    }
            });

            return builder;
        }
    }

}
