using CoinGardenWorld.AzureFunctionExtensions.Extensions;
using CoinGardenWorld.SignalRFunctionExtensions;
using CoinGardenWorldMobileApp_Api;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureOpenApi()
    .ConfigureServices(services =>
    {
        // CoinGardenWorld.AzureFunctionExtensions
        services.AddCgwAzureFunctionExtensions();
        // Add Signalr
        services.AddSingleton<SignalRService>()
                .AddHostedService(sp => sp.GetRequiredService<SignalRService>())
                .AddSingleton<IHubContextStore>(sp => sp.GetRequiredService<SignalRService>());
    })
    .Build();

host.Run();