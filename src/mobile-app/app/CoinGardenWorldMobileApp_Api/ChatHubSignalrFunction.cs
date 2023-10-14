using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core.Serialization;
using CoinGardenWorld.SignalRFunctionExtensions;
using CoinGardenWorld.SignalRFunctionExtensions.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorldMobileApp_Api
{
    public class ChatHubSignalRFunction 
    {

        private static readonly ObjectSerializer JsonObjectSerializer = new JsonObjectSerializer(new(JsonSerializerDefaults.Web));
        private readonly ILogger _logger;
        private readonly IHubContextStore _hubContextStore;

        private const string hubName = "chathub";
        private ServiceHubContext MessageHubContext => _hubContextStore.MessageHubContext;

        public ChatHubSignalRFunction(ILoggerFactory loggerFactory, IHubContextStore hubContextStore)
        {
            _logger = loggerFactory.CreateLogger<ChatHubSignalRFunction>();
            _hubContextStore = hubContextStore;
        }

        // <snippet_on_connected>
        [Function(hubName +"/" + nameof(OnConnected))]
        public Task OnConnected(
            [SignalRTrigger("chathub", "connections", "connected")]
                SignalRInvocationContext invocationContext, FunctionContext functionContext)
        {
            var logger = functionContext.GetLogger(nameof(OnConnected));
            logger.LogInformation("Connection {connectionId} is connected", invocationContext.ConnectionId);

            invocationContext.Headers.TryGetValue("Authorization", out var auth);
            return MessageHubContext.Clients.All.SendAsync("newConnection", new NewConnection(invocationContext.ConnectionId, auth));
        }
        // </snippet_on_connected>

        // <snippet_on_disconnected>
        [Function(hubName + "/" + nameof(OnDisconnected))]
        public void OnDisconnected(
            [SignalRTrigger("chathub", "connections", "disconnected")]
                SignalRInvocationContext invocationContext, FunctionContext functionContext)
        {
            var logger = functionContext.GetLogger(nameof(OnDisconnected));
            logger.LogInformation("Connection {connectionId} is disconnected. Error: {error}", invocationContext.ConnectionId, invocationContext.Error);
        }
        // </snippet_on_disconnected>

        // <snippet_on_message>
        [Function(hubName + "/" + nameof(OnClientMessage))]
        public void OnClientMessage(
            [SignalRTrigger("chathub", "messages", "sendMessage", "content")]
                SignalRInvocationContext invocationContext, string content, FunctionContext functionContext)
        {
            var logger = functionContext.GetLogger(nameof(OnClientMessage));
            logger.LogInformation("Connection {connectionId} sent a message. Message content: {content}", invocationContext.ConnectionId, content);
        }
        // </snippet_on_message>


        [Function(hubName + "/" + "negotiate")]
        public async Task<SignalRConnectionInfo> Negotiate([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var negotiateResponse = await MessageHubContext.NegotiateAsync();
            //var negotiateResponse = await MessageHubContext.NegotiateAsync(new() { UserId = req.Headers.GetValues("userId").FirstOrDefault() });
           // var response = req.CreateResponse();
            // We need to make sure the response JSON naming is camelCase, otherwise SignalR client can't recognize it.
            //await response.WriteAsJsonAsync(negotiateResponse, JsonObjectSerializer);

            return new SignalRConnectionInfo
           {
               AccessToken = negotiateResponse.AccessToken,
               Url = negotiateResponse.Url
           };
        }


        //// When you have multiple SignalR service instances and you want to customize the rule that route a client
        //// <snippet_negotiate_multiple_endpoint>
        //public static readonly JsonSerializerOptions SerializerOptions = new()
        //{
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //};
        //[Function(nameof(NegotiateWithMultipleEndpoints))]
        //public static string NegotiateWithMultipleEndpoints(
        //    [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestData req,
        //    [SignalRNegotiationInput("chatHub", "AzureSignalRConnectionString")] SignalRNegotiationContext negotiationContext)
        //{
        //    // Customize your rule here
        //    var connectionInfo = negotiationContext.Endpoints[0].ConnectionInfo;
        //    // The SignalR client respects the camel case response only.
        //    return JsonSerializer.Serialize(connectionInfo, SerializerOptions);
        //}
        //// </snippet_negotiate_multiple_endpoint>
        


        [Function(hubName + "/" + "Broadcast")]
        public Task Broadcast(
        [SignalRTrigger("chathub", "messages", "broadcast", "message")] SignalRInvocationContext invocationContext, string message)
        {
            return MessageHubContext.Clients.All.SendAsync("newMessage", new NewMessage(invocationContext, message));
        }

        [Function(hubName + "/" + "SendToGroup")]
        public Task SendToGroup([SignalRTrigger("chathub", "messages", "SendToGroup", "groupName", "message")] SignalRInvocationContext invocationContext, string groupName, string message)
        {
            return MessageHubContext.Clients.Group(groupName).SendAsync("newMessage", new NewMessage(invocationContext, message));
        }

        [Function(hubName + "/" + "SendToUser")]
        public Task SendToUser([SignalRTrigger("chathub", "messages", "SendToUser", "userName", "message")] SignalRInvocationContext invocationContext, string userName, string message)
        {
            return MessageHubContext.Clients.User(userName).SendAsync("newMessage", new NewMessage(invocationContext, message));

        }

        [Function(hubName + "/" + "SendToConnection")]
        public Task SendToConnection([SignalRTrigger("chathub", "messages", "SendToConnection", "connectionId", "message")] SignalRInvocationContext invocationContext, string connectionId, string message)
        {
            return MessageHubContext.Clients.Client(connectionId).SendAsync("newMessage", new NewMessage(invocationContext, message));
        }

        [Function(hubName + "/" + "JoinGroup")]
        [SignalROutput(HubName = "chathub")]
        public Task JoinGroup([SignalRTrigger("chathub", "messages", "JoinGroup", "connectionId", "groupName")] SignalRInvocationContext invocationContext, string connectionId, string groupName)
        {
            return MessageHubContext.Groups.AddToGroupAsync(connectionId, groupName);
        }

        [Function(hubName + "/" + "LeaveGroup")]
        [SignalROutput(HubName = "chathub")]
        public Task LeaveGroup([SignalRTrigger("chathub", "messages", "LeaveGroup", "connectionId", "groupName")] SignalRInvocationContext invocationContext, string connectionId, string groupName)
        {
            return MessageHubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
        }

        [Function(hubName + "/" + "JoinUserToGroup")]
        [SignalROutput(HubName = "chathub")]
        public Task JoinUserToGroup([SignalRTrigger("chathub", "messages", "JoinUserToGroup", "userName", "groupName")] SignalRInvocationContext invocationContext, string userName, string groupName)
        {
            return MessageHubContext.UserGroups.AddToGroupAsync(userName, groupName);
        }

        [Function(hubName + "/" + "LeaveUserFromGroup")]
        [SignalROutput(HubName = "chathub")]
        public Task LeaveUserFromGroup([SignalRTrigger("chathub", "messages", "LeaveUserFromGroup", "userName", "groupName")] SignalRInvocationContext invocationContext, string userName, string groupName)
        {
            return MessageHubContext.UserGroups.RemoveFromGroupAsync(userName, groupName);
        }
    }

}