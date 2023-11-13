using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Identity.Web.Resource;
using System.Net.Mime;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [EnableRateLimiting("jwt")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class BasePublicController : ControllerBase
    {
    }
}
