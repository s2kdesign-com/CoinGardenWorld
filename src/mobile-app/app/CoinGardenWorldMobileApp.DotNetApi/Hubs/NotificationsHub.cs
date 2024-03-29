﻿using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Primitives;
using SignalRSwaggerGen.Attributes;

namespace CoinGardenWorldMobileApp.DotNetApi.Hubs
{
    [SignalRHub(description: "SignalR Hub Used for broadcasting alert messages and notifications")]
    public class NotificationsHub : Hub
    {
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;
        private ServiceHubContext NotificationsHubContext => _hubContextStore.NotificationsHubContext;


        public NotificationsHub(ILoggerFactory loggerFactory)//, IHubContextStore hubContextStore)
        {

            _logger = loggerFactory.CreateLogger<NotificationsHub>();
           // _hubContextStore = hubContextStore;
        }

        public override Task OnConnectedAsync()
        {
	        var userId = Context.UserIdentifier;
	        var connectionId = Context.ConnectionId;
            StringValues userEmails = "";
            if(Context.GetHttpContext() != null)
                Context.GetHttpContext()?.Request.Headers.TryGetValue("user-emails", out userEmails);



	        _logger.LogInformation($"UserID: {userId}, UserEmails: {userEmails} ConnectionID: {connectionId} has connected to {nameof(NotificationsHub)}");
	        return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync([SignalRHidden] Exception? exception)
        {
	        var userId = Context.UserIdentifier;
	        var connectionId = Context.ConnectionId;

	        _logger.LogInformation($"UserID: {userId} ConnectionID: {connectionId} has disconnected from {nameof(NotificationsHub)}");

	        return base.OnDisconnectedAsync(exception);
        }
	}
}
