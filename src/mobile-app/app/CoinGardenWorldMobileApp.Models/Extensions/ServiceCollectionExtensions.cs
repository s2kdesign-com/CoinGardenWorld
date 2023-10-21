
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace CoinGardenWorldMobileApp.Models.Extensions
{
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddCgwModels(this IServiceCollection services)
        {
            services.AddMapster();
            return services;
        }
    }
}
