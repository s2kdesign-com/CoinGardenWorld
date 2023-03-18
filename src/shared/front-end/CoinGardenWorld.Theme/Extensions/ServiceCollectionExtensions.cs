using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace CoinGardenWorld.Theme.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddCgwThemeExtensions(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Localization");

            // Toolbelt.Blazor.PWA.Updater 
            services.AddPWAUpdater();

            services.AddBlazoredLocalStorage();

            services.AddScoped(typeof(ThemeJsInterop));

            return services;
        }
    }
}
