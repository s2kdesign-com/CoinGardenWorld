
using Blazored.LocalStorage;
using CoinGardenWorldMobileApp.MobileAppTheme;
using CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Text.RegularExpressions;
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

            services.AddLocalization(options => options.ResourcesPath = "Localization");

            var serviceProvider = services.BuildServiceProvider();

            var localStorage = serviceProvider.GetService<IHybridStorage>();

            if (localStorage != null && localStorage.Exists(Constants.LANGUAGE_LOCAL_STORAGE_NAME))
            {

                var culture = localStorage.Get<string>(Constants.LANGUAGE_LOCAL_STORAGE_NAME);
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);
            }

            return services;
        }
    }
}
