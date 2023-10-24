using CoinGardenWorld.HttpClientsExtensions.Configurations;
using CoinGardenWorld.HttpClientsExtensions.DelegatingHandlers;
using CoinGardenWorld.HttpClientsExtensions.Infrastructure;
using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using CoinGardenWorldMobileApp.Models;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.HttpClientsExtensions.Extensions
{
    // TODO: Same as CoinGardenWorld.Theme.Extensions.WebAssemblyHostBuilderExtension 
    // TODO: Move this one to external nuget and remove the other one 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMobileApiHttpClients(this IServiceCollection services, ExternalApisSettings settings, string baseAddress, EnvironmentType environmentType)
        {
            if (settings.ExternalApis != null)
            {
                Console.WriteLine("ExternalApis Detected");

                services.AddOptions<ExternalApisSettings>("ExternalApis");

                foreach (var externalApisSetting in settings.ExternalApis)
                {
                    services.AddHttpClient($"{externalApisSetting.Key}.NoAuthenticationClient",
                        client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url));


                    // AuthorizationMessageHandler is not injected in blazor server, if you try to inject it the IAccessTokenProvider will blow, no cigar there
                    services.AddSingleton<BlazorServerTokenProvider>();
                    services.AddScoped<BlazorServerAuthorizationMessageHandler>();

                    if (environmentType != EnvironmentType.ASPNET)
                    {
                        services.AddHttpClient(externalApisSetting.Key,
                                client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url))
                            .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
                                .ConfigureHandler(
                                    authorizedUrls: new[] { externalApisSetting.Value.Api_Url },
                                    scopes: externalApisSetting.Value.Api_Scopes));
                    }else
                    {
                        services.AddHttpClient(externalApisSetting.Key,
                                client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url))
                            .AddHttpMessageHandler(sp => sp.GetRequiredService<BlazorServerAuthorizationMessageHandler>().ConfigureHandler(
                                authorizedUrls: new[] { externalApisSetting.Value.Api_Url },
                                scopes: externalApisSetting.Value.Api_Scopes));
                    }

                }

                // Default API 
                services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CGW.Api.NoAuthenticationClient"));
            }
            else
            {

                services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            }


            // Add HttpClients  
            // TODO: This should be Singleton but AuthenticationStateProvider is scoped so we can not create singletons 
            services.AddScoped<IHttpClientBase<AccountHttpClient, AccountDto>, AccountHttpClient>();
            services.AddScoped<IHttpClientBase<VersionHttpClient, string>, VersionHttpClient>();
            services.AddScoped<IHttpClientBase<VersionAuthorizedHttpClient, string>, VersionAuthorizedHttpClient>();
            return services;
        }



        public static IServiceCollection AddBotApiHttpClients(this IServiceCollection services, ExternalApisSettings settings, string baseAddress)
        {
            if (settings.ExternalApis != null)
            {
            }
            else
            {

                services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            }

            return services;
        }
    }


}
