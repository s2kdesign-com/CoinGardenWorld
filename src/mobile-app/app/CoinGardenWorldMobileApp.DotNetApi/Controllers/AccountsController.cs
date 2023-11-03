using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Authorization;
using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using System.Linq;
using Microsoft.AspNetCore.OData.Query;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize()]
    // TODO: Add ApiVersion in the header
    public class AccountController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Accounts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AccountList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<AccountList> GetAccounts()
        {
            //  Before Odata
            //var accountsQuery =  _unitOfWork.AccountRepository.List(
            //    orderBy: q => q.OrderBy(d => d.CreatedOn)
            //    );

            return _unitOfWork.AccountRepository.List().Select(AccountMapper.ProjectToList);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> GetAccount(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            ;
            if (account == null)
            {
                return NotFound();
            }

            return account.AdaptToDto();
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAccount(Guid id, AccountMerge account)
        {
            var entity = await _unitOfWork.AccountRepository
                .GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            account.AdaptTo(entity);

            try
            {
                 _unitOfWork.AccountRepository.Update(entity);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    // TODO: Throw or log the exception?
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountAdd account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accountAdded = _unitOfWork.AccountRepository.Insert(account.AdaptToAccount());
                    await _unitOfWork.SaveAsync();
                    return CreatedAtAction("GetAccount", new { id = accountAdded.Id }, accountAdded);
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

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            await _unitOfWork.AccountRepository.DeleteAsync(account);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private async Task<bool> AccountExists(Guid id)
        {
            return await _unitOfWork.AccountRepository.ExistAsync(id);
        }
    }
}
