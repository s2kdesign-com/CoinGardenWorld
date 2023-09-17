using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.AzureFunctionExtensions.Configurations;
using CoinGardenWorld.AzureFunctionExtensions.Providers;
using CoinGardenWorld.AzureFunctionExtensions.Services;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

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

            // Add JWT bearer and 
            services.AddScoped<AzureAdJwtBearerValidation>();
            services.AddScoped<AuthenticationProvider>();

            services.AddHealthChecks().AddCheck("self", () =>
                HealthCheckResult.Healthy("Build Version: " + Assembly.GetEntryAssembly()?.GetName().Version));

            return services;
        }
    }
}
