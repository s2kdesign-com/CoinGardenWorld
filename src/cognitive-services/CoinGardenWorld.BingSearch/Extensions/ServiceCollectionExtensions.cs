using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.BingSearch;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.AzureAI.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddAzureWebSearch(this IServiceCollection services)
        {

            services.AddSingleton<AzureWebSearch>();
            return services;
        }
    }
}
