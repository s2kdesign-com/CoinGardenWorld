## Back-end extensions CoinGarden.World 

### How to use it
Reference CoinGardenWorld.AzureFunctionExtensions In your azure function and open Program.cs and change it like this:
```c#

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
    .ConfigureOpenApi()
    .ConfigureServices(services =>
    {
        services.AddCgwAzureFunctionExtensions();
    })
    .Build();
host.Run();
```
### Done