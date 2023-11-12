using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize]
    [Produces("application/json")]
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
    }
}
