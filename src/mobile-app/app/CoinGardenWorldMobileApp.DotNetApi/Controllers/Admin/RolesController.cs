using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers.Admin
{
    [Tags("Admin/Roles")]
    [Route("api/Admin/[controller]")]
    public class RolesController : BaseAuthorizedController
    {
        private readonly UnitOfWork<Role> _unitOfWork;

        public RolesController(
            UnitOfWork<Account> unitOfWorkAccount, UnitOfWork<Role> unitOfWork) : base(unitOfWorkAccount)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Roles
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RoleList>>> GetRoles()
        {
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            return Ok(_unitOfWork.Repository.List().Select(e => e.AdaptToList()));
        }


        // GET: api/Roles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleDto>> GetRole(Guid id)
        {
            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }

            var model = await _unitOfWork.Repository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return model.AdaptToDto();
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutRole(Guid id, RoleMerge post)
        {

            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }


            // TODO: On Role Update check all users and update their current role 

            var entity = await _unitOfWork.Repository
                .GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            post.AdaptTo(entity);

            try
            {
                _unitOfWork.Repository.Update(entity);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleDto>> PostRole(RoleAdd roleAdd)
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
                    var entityAdded = _unitOfWork.Repository.Insert(roleAdd.AdaptToRole());
                    await _unitOfWork.SaveAsync();
                    return CreatedAtAction("GetRole", new { id = entityAdded.Id }, entityAdded);
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


        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRole(Guid id)
        {

            var isAdmin = await IsAccountInRole("Administrator");
            if (!isAdmin)
            {
                return BadRequest("Account is not Administrator");
            }


            var entity = await _unitOfWork.Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _unitOfWork.Repository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();

            return NoContent(); ;
        }

        private async Task<bool> RoleExists(Guid id)
        {
            return await _unitOfWork.Repository.ExistAsync(id);
        }
    }
}
