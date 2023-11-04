using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.DerivedModels;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<ProfileOnLogin>> OnLogin(ProfileOnLoginRequest request)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var accountFromDb = await _unitOfWorkAccount.Repository.List(a => a.Email == request.Account.Email).FirstOrDefaultAsync();

                    if (accountFromDb == null)
                    {
                        accountFromDb = _unitOfWorkAccount.Repository.Insert(request.Account.AdaptToAccount());
                        await _unitOfWorkAccount.SaveAsync();


                    }

                    var externalLogin = await _unitOfWorkExternalLogins.Repository.List(e => e.AccountId == accountFromDb.Id && e.IdentityProvider == request.ExternalLogins.IdentityProvider).FirstOrDefaultAsync();

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
