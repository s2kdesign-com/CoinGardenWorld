using System.Globalization;
using System.Security.Claims;
using BlazorApplicationInsights;
using Blazored.LocalStorage;
using CoinGardenWorld.AzureStorageClientsExtensions;
using CoinGardenWorld.Constants;
using CoinGardenWorld.HttpClientsExtensions;
using CoinGardenWorld.HttpClientsExtensions.Configurations;
using CoinGardenWorld.HttpClientsExtensions.Extensions;
using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using CoinGardenWorld.SignalRClientsExtensions.Extensions;
using CoinGardenWorldMobileApp.Maui.Authorization;
using CoinGardenWorldMobileApp.MobileAppTheme.Authorization;
using CoinGardenWorldMobileApp.MobileAppTheme.Components.Toasts;
using CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage;
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


            // Add CoinGardenWorld.HttpClientsExtensions  
            var externalApisSettings = new ExternalApisSettings();
            configuration.Bind(externalApisSettings);

            var hostEnvironment = serviceProvider.GetRequiredService<IWebAssemblyHostEnvironment>();
            services.AddMobileApiHttpClients(externalApisSettings, hostEnvironment.BaseAddress, environmentType);

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

                    if (externalApisSettings.ExternalApis != null && externalApisSettings.ExternalApis != null)
                    {
                        foreach (var externalApisSetting in externalApisSettings.ExternalApis)
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

            // CoinGardenWorld.AzureStorageClientsExtensions
            services.AddScoped<IBlobStorageService, BlobStorageService>();

            // CoinGardenWorld.SignalRClientsExtensions
            services.AddSignalRClientsExtensions(environmentType);

            // Add Toast Component
            services.AddScoped<ToastService>();

            return services;
        }
    }


}
