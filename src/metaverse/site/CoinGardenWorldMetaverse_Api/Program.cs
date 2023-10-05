using CoinGardenWorld.AzureFunctionExtensions.Extensions;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureOpenApi()
    .ConfigureServices(services =>
    {
        // CoinGardenWorld.AzureFunctionExtensions
        services.AddCgwAzureFunctionExtensions();

    })
    .Build();

host.Run();