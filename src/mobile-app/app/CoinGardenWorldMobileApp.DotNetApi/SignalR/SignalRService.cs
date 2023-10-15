using Microsoft.Azure.SignalR.Management;

namespace CoinGardenWorldMobileApp.DotNetApi.SignalR
{
    public interface IHubContextStore
    {
        public ServiceHubContext MessageHubContext { get; }
        public ServiceHubContext ChatHubContext { get; }
    }

    public class SignalRService : IHostedService, IHubContextStore
    {
        private const string ChatHub = "ChatHub";
        private const string MessageHub = "MessageHub";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public ServiceHubContext MessageHubContext { get; private set; }
        public ServiceHubContext ChatHubContext { get; private set; }

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
            MessageHubContext = await serviceManager.CreateHubContextAsync(MessageHub, cancellationToken);
            ChatHubContext = await serviceManager.CreateHubContextAsync(ChatHub, cancellationToken);
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.WhenAll(Dispose(MessageHubContext), Dispose(ChatHubContext));
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
