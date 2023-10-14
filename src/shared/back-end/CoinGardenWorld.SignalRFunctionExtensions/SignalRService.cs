using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.SignalR.Management;

namespace CoinGardenWorld.SignalRFunctionExtensions;

public interface IHubContextStore
{
    ServiceHubContext MessageHubContext { get; }

    // Demostrate how to use multiple hubs
    ServiceHubContext SecondHubContext { get; }
}

public class SignalRService : IHostedService, IHubContextStore
{
    private const string MessageHub = "chathub";
    private const string SecondHub = "SecondHub";
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public ServiceHubContext MessageHubContext { get; private set; }
    public ServiceHubContext SecondHubContext { get; private set; }

    public SignalRService(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

     async Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        var connectionString = _configuration["AzureSignalRConnectionString"];

        using var serviceManager = new ServiceManagerBuilder()
            .WithOptions(o => o.ConnectionString = connectionString)
            .WithLoggerFactory(_loggerFactory)
            .BuildServiceManager();
        MessageHubContext = await serviceManager.CreateHubContextAsync(MessageHub, cancellationToken);
        SecondHubContext = await serviceManager.CreateHubContextAsync(SecondHub, cancellationToken);
    }

    Task IHostedService.StopAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(Dispose(MessageHubContext), Dispose(SecondHubContext));
    }

    private static Task Dispose(ServiceHubContext hubContext)
    {
        if (hubContext == null)
        {
            return Task.CompletedTask;
        }
        return hubContext.DisposeAsync();
    }
}