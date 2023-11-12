using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Azure.SignalR.Management;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers.Public
{

    /// <summary>
    /// SignalR Controller for negotiating with Azure SignalR Management service  https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet
    /// </summary>
    [Route("api")]
    [ApiController]
    [EnableRateLimiting("Fixed")]
    public class NegotiateController : ControllerBase
    {
        private const string EnableDetailedErrors = "EnableDetailedErrors";
        private readonly ServiceHubContext _notificationsHubContext;
        private readonly ServiceHubContext _chatHubContext;
        private readonly bool _enableDetailedErrors;

        public NegotiateController(IHubContextStore store, IConfiguration configuration)
        {
            _chatHubContext = store.ChatHubContext;
            _notificationsHubContext = store.NotificationsHubContext;
            _enableDetailedErrors = configuration.GetValue(EnableDetailedErrors, false);
        }

        // TODO: This controller was used to negotiate the connection with Azure SignalR Management Service
        //[HttpPost("NotificationsHub/negotiate")]
        //public Task<ActionResult> NotificationsHubNegotiate()
        //{
        //    return NegotiateBase(_notificationsHubContext);
        //}

        ////This API is not used. Just demonstrate a way to have multiple hubs.
        //[HttpPost("chathub/negotiate")]
        //public Task<ActionResult> ChatHubNegotiate()
        //{
        //    return NegotiateBase( _chatHubContext);
        //}

        //private async Task<ActionResult> NegotiateBase(ServiceHubContext serviceHubContext)
        //{

        //    var negotiateResponse = await serviceHubContext.NegotiateAsync(new()
        //    {
        //        EnableDetailedErrors = _enableDetailedErrors
        //    });

        //    return new JsonResult(new Dictionary<string, string>()
        //    {
        //        { "url", negotiateResponse.Url },
        //        { "accessToken", negotiateResponse.AccessToken }
        //    });
        //}
    }
}
