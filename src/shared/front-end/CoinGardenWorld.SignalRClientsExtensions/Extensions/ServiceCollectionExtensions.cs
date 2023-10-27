
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using CoinGardenWorld.SignalRClientsExtensions.SignalR;
using CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients;
using CoinGardenWorldMobileApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.SignalRClientsExtensions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalRClientsExtensions(this IServiceCollection services)
        {

            services.AddOptions<SignalRClientsSettings>("SignalRClients");

            // Add SignalR Hubs
            services.AddScoped<ChatHub>();
            services.AddScoped<NotificationsHub>();

            return services;
        }
    }


}
