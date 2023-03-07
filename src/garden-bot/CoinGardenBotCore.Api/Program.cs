using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using System;
using System.Reflection;
using System.Threading.Tasks;
using CoinGardenWorld.AzureAI.Extensions;
using CoinGardenWorld.AzureAI.Configurations;
using CoinGardenWorld.AzureFunctionExtensions.Extensions;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureOpenApi()
    .ConfigureServices(services =>
    {
        // CoinGardenWorld.AzureFunctionExtensions
        services.AddCgwAzureFunctionExtensions();

        //CoinGardenWorld.AzureAI
        services.AddOptions<AzureAISettings>().BindConfiguration("AzureAISettings");
        services.AddAzureComputerVision();

        //CoinGardenWorld.BingSearch
        services.AddAzureWebSearch();
    })
    .Build();

host.Run();


