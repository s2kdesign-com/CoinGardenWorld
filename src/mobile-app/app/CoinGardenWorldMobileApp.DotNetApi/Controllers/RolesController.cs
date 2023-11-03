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

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public RolesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Roles
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<RoleList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<RoleList> GetRoles()
        {
            return _unitOfWork.RoleRepository.List().Select(RoleMapper.ProjectToList);
        }


        // GET: api/Roles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleDto>> GetRole(Guid id)
        {
            var model = await _unitOfWork.RoleRepository.GetByIdAsync(id);
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
            var entity = await _unitOfWork.RoleRepository
                .GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            post.AdaptTo(entity);

            try
            {
                _unitOfWork.RoleRepository.Update(entity);
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
            try
            {
                if (ModelState.IsValid)
                {
                    var entityAdded = _unitOfWork.RoleRepository.Insert(roleAdd.AdaptToRole());
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
            var entity = await _unitOfWork.RoleRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _unitOfWork.RoleRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();

            return NoContent(); ;
        }

        private async Task<bool> RoleExists(Guid id)
        {
            return await _unitOfWork.RoleRepository.ExistAsync(id);
        }
    }
}
