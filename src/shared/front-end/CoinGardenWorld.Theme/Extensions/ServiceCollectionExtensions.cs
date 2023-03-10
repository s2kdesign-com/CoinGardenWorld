using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.Theme.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddCgwThemeExtensions(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Localization");
            return services;
        }
    }
}
