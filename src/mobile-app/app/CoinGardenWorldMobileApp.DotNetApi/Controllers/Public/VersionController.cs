using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection;
using System.Security.Principal;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers.Public
{
    [Route("api/[controller]")]
    public class VersionController : BasePublicController
    {

        // GET: api/Version
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        public ActionResult<string> Get()
        {
            Version version = Assembly.GetExecutingAssembly()?.GetName().Version ?? new Version(1, 0, 0);
            return Ok(new DefaultResponse { Message = version.ToString() });
        }
        // GET: api/AuthorizedVersion
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(DefaultResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("/api/[controller]/[action]")]
        public ActionResult<string> GetAuthorized()
        {

            var userName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            return Ok(new DefaultResponse { Message = userName + " - Welcome to GardenAPP Mobile API!" });
        }

        public class DefaultResponse
        {
            public string Message { get; set; }
        }
    }
}
