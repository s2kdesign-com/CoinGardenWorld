
using CoinGardenWorld.DownstreamSignalRExtensions.HubClients;
using CoinGardenWorld.DownstreamSignalRExtensions.Providers;
using CoinGardenWorld.SignalRClientsExtensions.Configurations;
using CoinGardenWorld.SignalRClientsExtensions.Extensions;
using CoinGardenWorld.SignalRClientsExtensions.SignalR;
using CoinGardenWorld.SignalRClientsExtensions.SignalR.HubClients;
using CoinGardenWorldMobileApp.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGardenWorld.DownstreamSignalRExtensions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDownstreamSignalRClientsExtensions(this IServiceCollection services)
        {

            services.AddOptions<SignalRClientsSettings>("SignalRClients");

            // Add SignalR Hubs

            // IAccessTokenProvider is not registered in blazor server so we can override it here 
            services.AddScoped(typeof(BlazorSignalRTokenProvider<>));

            services.AddScoped<NotificationsHubDownstreamClient>();

            services.AddScoped<ChatHubDownstreamClient>();

            return services;
        }
    }


}
