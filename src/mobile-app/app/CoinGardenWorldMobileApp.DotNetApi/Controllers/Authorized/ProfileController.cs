using Azure.Core;
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

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers.Authorized
{
    [Route("api/[controller]/[action]")]
    public class ProfileController : BaseAuthorizedController
    {
        private readonly UnitOfWork<Role> _unitOfWorkRoles;
        private readonly UnitOfWork<Badge> _unitOfWorkBadges;
        private readonly UnitOfWork<AccountExternalLogins> _unitOfWorkExternalLogins;

        public ProfileController(
            UnitOfWork<Account> unitOfWorkAccount,
            UnitOfWork<AccountExternalLogins> unitOfWorkExternalLogins
            , UnitOfWork<Role> unitOfWorkRoles
            , UnitOfWork<Badge> unitOfWorkBadges) : base(unitOfWorkAccount)
        {
            _unitOfWorkExternalLogins = unitOfWorkExternalLogins;
            _unitOfWorkRoles = unitOfWorkRoles;
            _unitOfWorkBadges = unitOfWorkBadges;
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

                var model = new ProfileOnLoginRequest
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
                    var accountFromDb = await UnitOfWorkAccount.Repository.List(a => a.Email == model.Account.Email).FirstOrDefaultAsync();

                    // User has existing account
                    if (accountFromDb == null)
                    {
                        // TODO: Move magic strings for roles
                        var role = await _unitOfWorkRoles.Repository.List( e => e.Name == "Standard User").FirstOrDefaultAsync();
                        model.Account.Roles = new List<AccountRoleAdd>
                        {
                            new AccountRoleAdd
                            {
                                RoleId = role.Id,
                                RoleName = role.Name,
                                AssignedOn = DateTime.UtcNow
                            }
                        };

                        // TODO: Move magic strings for roles
                        var badge = await _unitOfWorkBadges.Repository.List(b => b.Name == "Recruit Rosebud (Upon Registration)").FirstOrDefaultAsync();
                        model.Account.Badges = new List<AccountBadgeAdd>
                        {
                            new AccountBadgeAdd
                            {
                                BadgeId = badge.Id,
                                BadgeName = badge.Name,
                                BadgeColor = badge.Color,
                                BadgeIcon = badge.Icon,
                                EarnedOn = DateTime.UtcNow
                            }
                        };

                        accountFromDb = UnitOfWorkAccount.Repository.Insert(model.Account.AdaptToAccount());
                        await UnitOfWorkAccount.SaveAsync();
                    }

                    var externalLogin = await _unitOfWorkExternalLogins.Repository.List(e => e.AccountId == accountFromDb.Id && e.IdentityProvider == model.ExternalLogins.IdentityProvider).FirstOrDefaultAsync();

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
                        model.ExternalLogins.AdaptTo(externalLoginRequest);
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

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AccountRole[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AccountRole>>> GetRoles()
        {
            var email = (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value!);

            var accountFromDb = await UnitOfWorkAccount.Repository.List(a => a.Email == email).FirstOrDefaultAsync();

            if(accountFromDb != null)
            {
                return Ok(accountFromDb?.Roles?.ToList());

            }

            return BadRequest("There is no existing roles for email: " + email);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(AccountBadge[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AccountBadge>>> GetBadges()
        {
            var email = (HttpContext.User.Claims.FirstOrDefault(c => c.Type == "emails")?.Value!);

            var accountFromDb = await UnitOfWorkAccount.Repository.List(a => a.Email == email).FirstOrDefaultAsync();

            if (accountFromDb != null)
            {
                return Ok(accountFromDb?.Badges?.ToList());

            }

            return BadRequest("There is no existing roles for email: " + email);
        }
    }
}
