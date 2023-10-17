
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace CoinGardenWorld.Theme.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddMobileAppTheme(this IServiceCollection services)
        {

            services.AddPWAUpdater();
            return services;
        }
    }
}
