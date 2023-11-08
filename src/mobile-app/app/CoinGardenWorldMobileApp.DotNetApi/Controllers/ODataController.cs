using CoinGardenWorldMobileApp.DotNetApi.DataAccessLayer;
using CoinGardenWorldMobileApp.Models.Entities;
using Hangfire.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Identity.Web.Resource;

namespace CoinGardenWorldMobileApp.DotNetApi.Controllers
{
    [Tags("OData")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    [Authorize()]
    public class ODataControllerBase: ODataController
    {
        private readonly UnitOfWork<Account> _unitOfWorkAccounts;
        private readonly UnitOfWork<Flower> _unitOfWorkFlowers;
        private readonly UnitOfWork<Post> _unitOfWorkPosts;

        public ODataControllerBase(
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
        [Route("odata/Posts")]
        [ProducesResponseType(typeof(IEnumerable<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Post> GetPosts()
        {
            return _unitOfWorkPosts.Repository.List();
        }


        [HttpGet]
        [EnableQuery]
        [Route("odata/Accounts")]
        [ProducesResponseType(typeof(IEnumerable<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Account> GetAccountsOdata()
        {
            return _unitOfWorkAccounts.Repository.List();
        }


        [HttpGet]
        [EnableQuery]
        [Route("odata/Flowers")]
        [ProducesResponseType(typeof(IEnumerable<Flower>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IQueryable<Flower> GetFlowers()
        {
            return _unitOfWorkFlowers.Repository.List();
        }
    }
}
