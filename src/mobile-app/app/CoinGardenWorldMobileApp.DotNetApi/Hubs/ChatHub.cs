﻿using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using SignalRSwaggerGen.Attributes;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [SignalRHub(description: "SignalR Hub Used for Chat communication")]
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext BroadcastHubContext => _hubContextStore.ChatHubContext;


        public ChatHub(ILoggerFactory loggerFactory, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<ChatHub>();
            _hubContextStore = hubContextStore;
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;


            return base.OnConnectedAsync();
        }
    }
}