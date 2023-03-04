using CoinGardenBotCore_Api.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using System;
using System.Reflection;
using System.Threading.Tasks;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureOpenApi()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
        {
            var options = new ApiConfigurationOptions()
            {
                Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                OpenApiVersion = DefaultOpenApiConfigurationOptions.GetOpenApiVersion(),
                IncludeRequestingHostName =
                    DefaultOpenApiConfigurationOptions.IsFunctionsRuntimeEnvironmentDevelopment(),
                ForceHttps = DefaultOpenApiConfigurationOptions.IsHttpsForced(),
                ForceHttp = DefaultOpenApiConfigurationOptions.IsHttpForced(),
            };

            return options;
        });


    })
    .Build();
host.Run();
