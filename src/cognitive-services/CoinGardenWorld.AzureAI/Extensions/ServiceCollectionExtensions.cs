using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.AzureAI.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.AzureAI.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddAzureComputerVision(this IServiceCollection services)
        {

            services.AddSingleton<AzureComputerVision>();
            return services;
        }
    }
}
