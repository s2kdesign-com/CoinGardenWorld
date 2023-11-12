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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Tags("Admin/Accounts")]
    [Route("api/Admin/[controller]")]
    // TODO: Add ApiVersion in the header
    public class AccountsController : BaseAuthorizedController
    {
        private readonly UnitOfWork<Account> _unitOfWork;

        public AccountsController(UnitOfWork<Account> unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //The IActionResult return type is appropriate when multiple ActionResult return types are possible in an action. The ActionResult types represent various HTTP status codes. 
        // GET: api/Accounts
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AccountList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AccountList>>> GetAccounts()
        {
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }
            return Ok(_unitOfWork.Repository.List().ToArray().Select(e => e.AdaptToList()));
        }


        // GET: api/Accounts/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties">
        /// Specifies related entities to include in the query results.The navigation property to be included is
        ///     specified starting with the type of entity being queried. Further
        ///     navigation properties to be included can be appended, separated by the '.' character.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        ///     See https://aka.ms/efcore-docs-load-related-data Loading related entities for more information
        ///     and examples.
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> GetAccount(Guid id, string includeProperties = "ExternalLogins")
        {
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            var account = await _unitOfWork.Repository.GetByIdAsync(id, includeProperties);
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
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            var entity = await _unitOfWork.Repository
                .GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            account.AdaptTo(entity);

            try
            {
                 _unitOfWork.Repository.Update(entity);
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
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var accountAdded = _unitOfWork.Repository.Insert(account.AdaptToAccount());
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
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            var account = await _unitOfWork.Repository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            await _unitOfWork.Repository.DeleteAsync(account);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private async Task<bool> AccountExists(Guid id)
        {
            return await _unitOfWork.Repository.ExistAsync(id);
        }
    }
}
