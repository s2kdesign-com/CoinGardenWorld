using CoinGardenWorldMobileApp.DotNetApi.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.SignalR.Management;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{

    /// <summary>
    /// SignalR Controller for negotiating with Azure SignalR Management service  https://learn.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet
    /// </summary>
    [Route("api")]
    [ApiController]
    public class NegotiateController : ControllerBase
    {
        private const string EnableDetailedErrors = "EnableDetailedErrors";
        private readonly ServiceHubContext _messageHubContext;
        private readonly ServiceHubContext _chatHubContext;
        private readonly bool _enableDetailedErrors;

        public NegotiateController(IHubContextStore store, IConfiguration configuration)
        {
            _messageHubContext = store.MessageHubContext;
            _chatHubContext = store.ChatHubContext;
            _enableDetailedErrors = configuration.GetValue(EnableDetailedErrors, false);
        }

        [HttpPost("messagehub/negotiate")]
        public Task<ActionResult> MessageHubNegotiate()
        {
            return NegotiateBase( _messageHubContext);
        }

        //This API is not used. Just demonstrate a way to have multiple hubs.
        [HttpPost("chathub/negotiate")]
        public Task<ActionResult> ChatHubNegotiate()
        {
            return NegotiateBase( _chatHubContext);
        }

        private async Task<ActionResult> NegotiateBase(ServiceHubContext serviceHubContext)
        {

            var negotiateResponse = await serviceHubContext.NegotiateAsync(new()
            {
                EnableDetailedErrors = _enableDetailedErrors
            });

            return new JsonResult(new Dictionary<string, string>()
            {
                { "url", negotiateResponse.Url },
                { "accessToken", negotiateResponse.AccessToken }
            });
        }
    }
}
