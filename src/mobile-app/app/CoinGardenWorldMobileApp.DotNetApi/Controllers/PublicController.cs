using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.MapperExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public PublicController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/flowers
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<FlowerList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<FlowerList> GetPublicFlowers()
        {
            return _unitOfWork.FlowerRepository.List().Select(FlowerMapper.ProjectToList);
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/posts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PostList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<PostList> GetPublicPosts()
        {
            return _unitOfWork.PostRepository.List().Select(PostMapper.ProjectToList);
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/accounts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AccountList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<AccountList> GetPublicAccounts()
        {
            return _unitOfWork.AccountRepository.List().Select(AccountMapper.ProjectToList);
        }


        // GET: api/Roles
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<RoleList>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<RoleList> GetPublicRoles()
        {
            return _unitOfWork.RoleRepository.List().Select(RoleMapper.ProjectToList);
        }
    }
}
