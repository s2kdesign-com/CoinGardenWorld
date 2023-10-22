using System.Globalization;
using System.Security.Claims;
using BlazorApplicationInsights;
using Blazored.LocalStorage;
using CoinGardenWorldMobileApp.Maui.Authorization;
using CoinGardenWorldMobileApp.MobileAppTheme.Authorization;
using CoinGardenWorldMobileApp.MobileAppTheme.Configurations;
using CoinGardenWorldMobileApp.MobileAppTheme.HttpClients;
using CoinGardenWorldMobileApp.MobileAppTheme.HttpClients.MobileApiClients;
using CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage;
using CoinGardenWorldMobileApp.MobileAppTheme.SignalR;
using CoinGardenWorldMobileApp.MobileAppTheme.SignalR.HubClients;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Extensions
{
    // TODO: Same as CoinGardenWorld.Theme.Extensions.WebAssemblyHostBuilderExtension 
    // TODO: Move this one to external nuget and remove the other one 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMobileAppTheme(this IServiceCollection services, EnvironmentType environmentType, IConfigurationRoot configuration)
        {
            // TODO: Not working on blazor, never seen it once
            services.AddPWAUpdater();
                        
            services.AddLocalization(options => options.ResourcesPath = "Localization");


            #region LocalStorage

            // If Environment is Mobile
            if (environmentType == EnvironmentType.MOBILE)
            {
                services.AddSingleton<IHybridStorage, MauiPreferencesStore>();
            }
            else
            {
                services.AddSingleton<IHybridStorage, BlazorLocalStorage>();
                // Blazored.LocalStorage
                services.AddBlazoredLocalStorageAsSingleton();
            }

            var serviceProvider = services.BuildServiceProvider();

            var localStorage = serviceProvider.GetService<IHybridStorage>();

            if (localStorage != null && localStorage.Exists(Constants.LANGUAGE_LOCAL_STORAGE_NAME))
            {

                var culture = localStorage.Get<string>(Constants.LANGUAGE_LOCAL_STORAGE_NAME);
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
            }

            #endregion

            #region ApplicationInsights
            if (environmentType == EnvironmentType.BLAZOR)
            {
                services.AddBlazorApplicationInsights(async applicationInsights =>
                {
                    var telemetryItem = new TelemetryItem()
                    {
                        Tags = new Dictionary<string, object>()
                        {
                            { "ai.cloud.role", "SPA" },
                            { "ai.cloud.roleInstance", "GardenAPP" },
                        }
                    };

                    await applicationInsights.AddTelemetryInitializer(telemetryItem);
                });
                if (localStorage != null && configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"] != null)
                {
                    localStorage.SetString(Constants.APPLICATION_INSIGHTS_CONNECTION_STRING_LOCAL_STORAGE_NAME, configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"] ??"");
                }

            }

            #endregion


            #region HttpClients


            // Add External APIs Http clients 
            var settings = new ExternalApisSettings();
            configuration.Bind(settings);


            if (settings != null && settings.ExternalApis != null)
            {
                Console.WriteLine("ExternalApis Detected");
                services.AddOptions<ExternalApisSettings>("ExternalApis");

                foreach (var externalApisSetting in settings.ExternalApis)
                {
                    services.AddHttpClient($"{externalApisSetting.Key}.NoAuthenticationClient",
                        client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url));

                    services.AddHttpClient(externalApisSetting.Key,
                            client => client.BaseAddress = new Uri(externalApisSetting.Value.Api_Url))
                        .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
                            .ConfigureHandler(
                                authorizedUrls: new[] { externalApisSetting.Value.Api_Url },
                                scopes: externalApisSetting.Value.Api_Scopes));

                }

                // Default API 
                services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CGW.Api.NoAuthenticationClient"));
            }
            else
            {

                var hostEnvironment = serviceProvider.GetRequiredService<IWebAssemblyHostEnvironment>();
                services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(hostEnvironment.BaseAddress) });
            }

            // Add HttpClients 
            services.AddScoped<IHttpClientBase<AccountHttpClient, AccountDto>, AccountHttpClient>();
            services.AddScoped<IHttpClientBase<VersionHttpClient, string>, VersionHttpClient>();
            services.AddScoped<IHttpClientBase<VersionAuthorizedHttpClient, string>, VersionAuthorizedHttpClient>();

            #endregion


            #region Authentication

            if (environmentType == EnvironmentType.MOBILE)
            {

                services.AddAuthorizationCore();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();

            }
            else
            {
                services.AddMsalAuthentication<RemoteAuthenticationState, UserAccount>(options =>
                {
                    configuration.Bind("AzureAd", options.ProviderOptions.Authentication);

                    if (settings.ExternalApis != null && settings.ExternalApis != null)
                    {
                        foreach (var externalApisSetting in settings.ExternalApis)
                        {
                            foreach (var apiScope in externalApisSetting.Value.Api_Scopes)
                            {
                                options.ProviderOptions.DefaultAccessTokenScopes.Add(apiScope);
                            }
                        }
                    }
                }).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, UserAccount, AccountFactory>();
            }

            #endregion

            // Add SignalR Hubs
            services.AddScoped<IClientHub<ChatHub>, ChatHub>();
            services.AddScoped<IClientHub<NotificationsHub>, NotificationsHub>();

            return services;
        }
    }


}
