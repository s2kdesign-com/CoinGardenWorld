using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoinGardenWorldMobileApp.DotNetApi.Contexts;
using CoinGardenWorldMobileApp.Models.ViewModels;
using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using Microsoft.AspNetCore.OData.Query;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;


        public PostsController(UnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Posts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<PostDto> GetPosts()
        {
            return _unitOfWork.PostRepository.List().Select(PostMapper.ProjectToDto);
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/Posts
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<PostDto> GetPublicPosts()
        {
            return _unitOfWork.PostRepository.List().Select(PostMapper.ProjectToDto);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> GetPost(Guid id)
        {
            var model = await _unitOfWork.PostRepository.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return model.AdaptToDto();
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Guid id, PostMerge post)
        {
            var entity = await _unitOfWork.PostRepository
                .GetByIdAsync(id);

            post.AdaptTo(entity);

            try
            {
                _unitOfWork.PostRepository.Update(entity);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PostDtoExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(PostDto),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> PostPost(PostAdd postAdd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entityAdded = _unitOfWork.PostRepository.Insert(postAdd.AdaptToPost());
                    await _unitOfWork.SaveAsync();
                    return CreatedAtAction("GetPost", new { id = entityAdded.Id }, entityAdded);
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

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var entity = await _unitOfWork.PostRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _unitOfWork.PostRepository.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();

            return NoContent(); ;
        }

        private async Task<bool> PostDtoExists(Guid id)
        {
            return await _unitOfWork.PostRepository.ExistAsync(id);
        }
    }
}
