using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Tags("OData")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
   // [Authorize()]
    public class QueryableController : ODataController
    {
        private readonly UnitOfWork<Account> _unitOfWorkAccounts;
        private readonly UnitOfWork<Flower> _unitOfWorkFlowers;
        private readonly UnitOfWork<Post> _unitOfWorkPosts;

        public QueryableController(
            UnitOfWork<Account> unitOfWorkAccounts,
            UnitOfWork<Flower> unitOfWorkFlowers,
            UnitOfWork<Post> unitOfWorkPosts
            )
        {
            _unitOfWorkAccounts = unitOfWorkAccounts;
            _unitOfWorkFlowers = unitOfWorkFlowers;
            _unitOfWorkPosts = unitOfWorkPosts;
        }
        // GET: api/Posts
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [Route("odata/PostsOData")]
        [ProducesResponseType(typeof(IEnumerable<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Post> PostsOData()
        {
            return _unitOfWorkPosts.Repository.List();
        }



        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [Route("odata/AccountsOData")]
        [ProducesResponseType(typeof(IEnumerable<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Account> AccountsOData()
        {
            var isAuthenticated = this.HttpContext.User.Identity?.IsAuthenticated ?? false;
            if(!isAuthenticated )
            {
                // TODO: Filter the result only for public accounts
                return _unitOfWorkAccounts.Repository.List();
            }
            return _unitOfWorkAccounts.Repository.List();
        }


        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [Route("odata/FlowersOData")]
        [ProducesResponseType(typeof(IEnumerable<Flower>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Flower> FlowersOData()
        {
            return _unitOfWorkFlowers.Repository.List();
        }
    }
}
