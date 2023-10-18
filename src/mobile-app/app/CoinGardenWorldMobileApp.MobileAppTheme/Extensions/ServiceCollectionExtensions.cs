
using Blazored.LocalStorage;
using CoinGardenWorldMobileApp.MobileAppTheme;
using CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace CoinGardenWorld.Theme.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMobileAppTheme(this IServiceCollection services, EnvironmentType environmentType)
        {
            if (environmentType == EnvironmentType.Mobile)
                services.AddSingleton<IHybridStorage, MauiPreferencesStore>();
            else
            {
                services.AddSingleton<IHybridStorage, BlazorLocalStorage>();
                // Blazored.LocalStorage
                services.AddBlazoredLocalStorageAsSingleton();
            }
            services.AddPWAUpdater();
            return services;
        }
    }
}
