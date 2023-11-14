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
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers.Authorized
{
    [Route("api/[controller]")]
    public class PostsController : BaseAuthorizedController
    {
        private readonly UnitOfWork<Post> _unitOfWork;


        public PostsController(
            UnitOfWork<Account> unitOfWorkAccount, UnitOfWork<Post> unitOfWork) : base(unitOfWorkAccount)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Posts
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<PostList>> GetPosts()
        {
            return Ok(_unitOfWork.Repository.List().Select(e => e.AdaptToList()));
        }


        // GET: api/Posts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> GetPost(Guid id)
        {
            var model = await _unitOfWork.Repository.GetByIdAsync(id, "Account");
            if (model == null)
            {
                return NotFound();
            }

            return model.AdaptToDto();
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutPost(Guid id, PostMerge post)
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
                    postAdd.AccountId = await GetAccountId();
                    var entityAdded = _unitOfWork.Repository.Insert(postAdd.AdaptToPost());
                    await _unitOfWork.SaveAsync();
                    return CreatedAtAction("GetPost", new { id = entityAdded.Id }, entityAdded.AdaptToDto());
                }

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                // TODO: Throw or log the exception?
                throw;
            }

            ModelState.AddModelError("", "Model is not valid!");
            return Problem();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePost(Guid id)
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

        private async Task<bool> PostDtoExists(Guid id)
        {
            return await _unitOfWork.Repository.ExistAsync(id);
        }
    }
}
