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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FlowersController : ControllerBase
    {
        private readonly UnitOfWork<Flower> _unitOfWork;

        public FlowersController(UnitOfWork<Flower> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Flowers
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<FlowerList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<FlowerList> GetFlowers()
        {
            return _unitOfWork.Repository.List().Select(FlowerMapper.ProjectToList);
        }

        // GET: api/Flowers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FlowerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FlowerDto>> GetFlower(
            Guid id, 
            string includeProperties = "Garden,Account,Account.Roles")
        {
            var model = await _unitOfWork.Repository.GetByIdAsync(id, includeProperties);
            if (model == null)
            {
                return NotFound();
            }

            return model.AdaptToDto();
        }


        // PUT: api/Flowers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFlower(Guid id, FlowerMerge post)
        {
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
                if (!await FlowerExists(id))
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

        // POST: api/Flowers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(FlowerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FlowerDto>> PostFlower(FlowerAdd postAdd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entityAdded = _unitOfWork.Repository.Insert(postAdd.AdaptToFlower());
                    await _unitOfWork.SaveAsync();
                    return CreatedAtAction("GetFlower", new { id = entityAdded.Id }, entityAdded);
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

        // DELETE: api/Flowers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFlower(Guid id)
        {
            var entity = await _unitOfWork.Repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _unitOfWork.Repository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();

            return NoContent(); ;
        }

        private async Task<bool> FlowerExists(Guid id)
        {
            return await _unitOfWork.Repository.ExistAsync(id);
        }
    }
}
