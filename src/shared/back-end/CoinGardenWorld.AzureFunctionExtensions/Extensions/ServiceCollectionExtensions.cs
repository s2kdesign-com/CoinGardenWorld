using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.AzureFunctionExtensions.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.AzureFunctionExtensions.Extensions {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddCgwAzureFunctionExtensions(this IServiceCollection services)
        {
            // Add SwaggerUI and OpenAPI documentation
            services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
            {
                var options = new ApiConfigurationOptions() {
                    Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                    IncludeRequestingHostName =
                        DefaultOpenApiConfigurationOptions.IsFunctionsRuntimeEnvironmentDevelopment(),
                    ForceHttps = DefaultOpenApiConfigurationOptions.IsHttpsForced(),
                    ForceHttp = DefaultOpenApiConfigurationOptions.IsHttpForced(),
                };

                return options;
            });
            
            return services;
        }
    }
}
