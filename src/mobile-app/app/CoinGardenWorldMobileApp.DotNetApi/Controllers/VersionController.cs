using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {

        // GET: api/Version
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Get()
        {
            Version version = Assembly.GetExecutingAssembly()?.GetName().Version ?? new Version(1, 0, 0);
            return version.ToString();
        }
        // GET: api/AuthorizedVersion
        [HttpGet]
        [Authorize]
        [Route("/api/[controller]/[action]")]
        public ActionResult<string> GetAuthorized()
        {

            var userName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            return userName + " - Welcome to .Net Api!" ;
        }
    }
}
