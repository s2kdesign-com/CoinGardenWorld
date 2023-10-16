using Microsoft.Azure.SignalR.Management;

namespace CoinGardenWorldMobileApp.DotNetApi.SignalR
{
    public interface IHubContextStore
    {
        public ServiceHubContext ChatHubContext { get; }
        public ServiceHubContext BroadcastHubContext { get; }
    }

    public class SignalRService : IHostedService, IHubContextStore
    {
        private const string ChatHub = "ChatHub";
        private const string BroadcastHub = "BroadcastHub";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public ServiceHubContext ChatHubContext { get; private set; }
        public ServiceHubContext BroadcastHubContext { get; private set; }

        public SignalRService(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        async Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            using var serviceManager = new ServiceManagerBuilder()
                .WithConfiguration(_configuration)
                //or .WithOptions(o=>o.ConnectionString = _configuration["Azure:SignalR:ConnectionString"]
                .WithLoggerFactory(_loggerFactory)
                .BuildServiceManager();

            ChatHubContext = await serviceManager.CreateHubContextAsync(ChatHub, cancellationToken);
            BroadcastHubContext = await serviceManager.CreateHubContextAsync(BroadcastHub, cancellationToken);
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(Dispose(ChatHubContext), Dispose(BroadcastHubContext));
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
}
