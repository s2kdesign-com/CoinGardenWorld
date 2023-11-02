using CoinGardenWorld.DownstreamApiExtensions.MobileApiClients;
using CoinGardenWorld.HttpClientsExtensions.Configurations;
using CoinGardenWorld.HttpClientsExtensions.DelegatingHandlers;
using CoinGardenWorld.HttpClientsExtensions.Infrastructure;
using CoinGardenWorld.HttpClientsExtensions.MetaverseSiteApiClients;
using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using CoinGardenWorld.HttpClientsExtensions.MobileApiSiteClients;
using CoinGardenWorldMobileApp.Models;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace CoinGardenWorld.HttpClientsExtensions.Extensions
{
    // TODO: Same as CoinGardenWorld.Theme.Extensions.WebAssemblyHostBuilderExtension 
    // TODO: Move this one to external nuget and remove the other one 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDownStreamApiExtensions(this IServiceCollection services, ExternalApisSettings settings, string baseAddress, EnvironmentType environmentType)
        {
            if (settings.ExternalApis != null)
            {
                Console.WriteLine("ExternalApis Detected");
                services.AddOptions<ExternalApisSettings>("ExternalApis");

                foreach (var externalApisSetting in settings.ExternalApis)
                {

                    // TODO: Authorized HttpClient NOT SUPPORTED in BLAZOR WASM
                    services.AddDownstreamApi(externalApisSetting.Key, options =>
                    {
                        options.BaseUrl = externalApisSetting.Value.Api_Url;
                        options.Scopes = externalApisSetting.Value.Api_Scopes;
                    });

                }

            }
            else
            {
                services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            }


            services.AddSingleton<BlazorServerTokens>();


            services.AddScoped<DownstreamApiExtensions.GardenBotMessageApiClients.VersionDownstreamApi>();
            services.AddScoped<DownstreamApiExtensions.MobileApiClients.MobileApiAuthorizedDownstreamApi>();

            return services;
        }

    }


}
