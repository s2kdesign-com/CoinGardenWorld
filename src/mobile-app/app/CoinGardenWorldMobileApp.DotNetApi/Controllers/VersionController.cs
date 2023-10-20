using CoinGardenWorldMobileApp.DotNetApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {

        // GET: api/Version
        [HttpGet]
        public ActionResult<string> Get()
        {
            Version version = Assembly.GetExecutingAssembly()?.GetName().Version ?? new Version(1, 0, 0);
            return version.ToString();
        }
    }
}
