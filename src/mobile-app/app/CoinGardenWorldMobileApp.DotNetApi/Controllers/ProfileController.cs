using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.DerivedModels;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UnitOfWork<Account> _unitOfWorkAccount;
        private readonly UnitOfWork<AccountExternalLogins> _unitOfWorkExternalLogins;

        public ProfileController(UnitOfWork<Account> unitOfWorkAccount, UnitOfWork<AccountExternalLogins> unitOfWorkExternalLogins)
        {
            _unitOfWorkAccount = unitOfWorkAccount;
            _unitOfWorkExternalLogins = unitOfWorkExternalLogins;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProfileOnLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfileOnLogin>> OnLogin()
        {
            try
            {
                var preferredUsername = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                var emails = (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value!);

                var userObjectIdAzureAd = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
                var userIdentityProvider = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value;

                var request = new ProfileOnLoginRequest
                {
                    Account = new AccountAdd
                    {
                        Email = emails,
                        DisplayName = preferredUsername
                    },
                    ExternalLogins = new AccountExternalLoginsMerge
                    {
                        ObjectIdAzureAd = userObjectIdAzureAd,
                        IdentityProvider = userIdentityProvider,
                        DisplayName = preferredUsername,
                        // TODO: Get the picture from somewhere in the user principle claims

                    }
                };

                if (ModelState.IsValid)
                {
                    var accountFromDb = await _unitOfWorkAccount.Repository.List(a => a.Email == request.Account.Email).FirstOrDefaultAsync();

                    // User has existing account
                    if (accountFromDb == null)
                    {
                        accountFromDb = _unitOfWorkAccount.Repository.Insert(request.Account.AdaptToAccount());
                        await _unitOfWorkAccount.SaveAsync();
                    }

                    var externalLogin = await _unitOfWorkExternalLogins.Repository.List(e => e.AccountId == accountFromDb.Id && e.IdentityProvider == request.ExternalLogins.IdentityProvider).FirstOrDefaultAsync();

                    // User has existing external login
                    if (externalLogin != null)
                    {
                        return Ok(new ProfileOnLogin
                        {
                            AccountId = accountFromDb.Id,
                            IsFirstRegistration = false
                        });

                    }
                    else
                    {
                        var externalLoginRequest = new AccountExternalLogins();
                        request.ExternalLogins.AdaptTo(externalLoginRequest);
                        externalLoginRequest.AccountId = accountFromDb.Id;

                        var externalLoginAdded = _unitOfWorkExternalLogins.Repository.Insert(externalLoginRequest);

                        await _unitOfWorkExternalLogins.SaveAsync();

                        // User is new and this is first registration
                        return Ok(new ProfileOnLogin
                        {
                            AccountId = accountFromDb.Id,
                            IsFirstRegistration = true
                        });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Model is not valid!");

                }

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                // TODO: Throw or log the exception?
                throw;
            }

            return Problem();
        }

    }
}
