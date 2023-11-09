using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.Entities;
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
        private readonly GenericRepository<Flower> _flowerRepository;
        private readonly GenericRepository<Post> _postRepository;
        private readonly GenericRepository<Account> _accountRepository;
        private readonly GenericRepository<Role> _roleRepository;

        public PublicController(GenericRepository<Flower> flowerRepository,
            GenericRepository<Post> postRepository,
            GenericRepository<Account> accountRepository,
            GenericRepository<Role> roleRepository
            )
        {
            _flowerRepository = flowerRepository;
            _postRepository = postRepository;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        //// TODO: Filter public posts from most viewed accounts
        //// GET: api/flowers
        //[HttpGet]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(IEnumerable<FlowerList>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IQueryable<FlowerList> GetPublicFlowers()
        //{
        //    return _flowerRepository.List().Select(FlowerMapper.ProjectToList);
        //}

        //// TODO: Filter public posts from most viewed accounts
        //// GET: api/posts
        //[HttpGet]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(IEnumerable<PostList>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IQueryable<PostList> GetPublicPosts()
        //{
        //    return _postRepository.List().Select(PostMapper.ProjectToList);
        //}

        //// TODO: Filter public posts from most viewed accounts
        //// GET: api/accounts
        //[HttpGet]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(IEnumerable<AccountList>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IQueryable<AccountList> GetPublicAccounts()
        //{
        //    return _accountRepository.List().Select(AccountMapper.ProjectToList);
        //}


        //// GET: api/Roles
        //[HttpGet]
        //[EnableQuery]
        //[Produces("application/json")]
        //[ProducesResponseType(typeof(IEnumerable<RoleList>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IQueryable<RoleList> GetPublicRoles()
        //{
        //    return _roleRepository.List().Select(RoleMapper.ProjectToList);
        //}
    }
}
