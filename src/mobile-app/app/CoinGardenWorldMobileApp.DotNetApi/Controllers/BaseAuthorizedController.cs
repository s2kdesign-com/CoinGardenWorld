using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using System.Net.Mime;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    [EnableRateLimiting("Fixed")]
    // TODO: [RestrictDomain("localhost", "example.com")] // values must be constants https://stackoverflow.com/questions/67845087/how-do-you-restrict-requests-so-they-only-work-if-it-is-accessed-by-a-specific-d
    public class BaseAuthorizedController : ControllerBase
    {

        protected readonly UnitOfWork<Account> UnitOfWorkAccount;

        public BaseAuthorizedController(
            UnitOfWork<Account> unitOfWorkAccount)
        {

            UnitOfWorkAccount = unitOfWorkAccount;
        }

        protected async Task<Guid> GetUserId()
        {

            var email = (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value!);

            var accountFromDb = await UnitOfWorkAccount.Repository.List(a => a.Email == email).FirstOrDefaultAsync();

            return accountFromDb?.Id ?? Guid.Empty;
        }

        protected async Task<bool> IsAccountInRole(string roleName)
        {

            var email = (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value!);

            var accountFromDb = await UnitOfWorkAccount.Repository.List(a => a.Email == email).FirstOrDefaultAsync();

            if(accountFromDb != null)
            {
                if(accountFromDb.Roles != null && accountFromDb.Roles.Any(r => r.RoleName == roleName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
