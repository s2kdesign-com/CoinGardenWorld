
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using CoinGardenWorld.SignalRClientsExtensions.Providers;
using CoinGardenWorld.SignalRClientsExtensions.SignalR;
using CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients;
using CoinGardenWorldMobileApp.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.SignalRClientsExtensions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalRClientsExtensions(this IServiceCollection services, EnvironmentType environmentType)
        {

            services.AddOptions<SignalRClientsSettings>("SignalRClients");

            if(environmentType == EnvironmentType.ASPNET)
            {
                // IAccessTokenProvider is not registered in blazor server so we can change it to 
                  services.AddScoped<IAccessTokenProvider, BlazorServerTokenProvider>();

            }
            // Add SignalR Hubs
            services.AddScoped<ChatHub>();
            services.AddScoped<NotificationsHub>();

            return services;
        }
    }


}
