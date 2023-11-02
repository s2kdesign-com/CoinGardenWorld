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
    public class TopRatedController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public TopRatedController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/flowers
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<FlowerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<FlowerDto> GetPublicFlowers()
        {
            return _unitOfWork.FlowerRepository.List().Select(FlowerMapper.ProjectToDto);
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/posts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PostDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<PostDto> GetPublicPosts()
        {
            return _unitOfWork.PostRepository.List().Select(PostMapper.ProjectToDto);
        }

        // TODO: Filter public posts from most viewed accounts
        // GET: api/accounts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<AccountDto> GetPublicAccounts()
        {
            return _unitOfWork.AccountRepository.List().Select(AccountMapper.ProjectToDto);
        }
    }
}
