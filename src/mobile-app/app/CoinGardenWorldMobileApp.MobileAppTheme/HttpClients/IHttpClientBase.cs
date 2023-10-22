using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.HttpClients
{
    public interface IHttpClientBase<T, M> where T : HttpClientBase<T, M>
    {
        Task<bool> UserIsAuthenticated();

        string ApiUrl
        {
            get;
        }

        bool HttpClientIsAuthorized
        {
            get;
        }

        Task<List<M>?> ListAsync();

        Task<HttpResponseMessage> GetAsync();
        Task<HttpResponseMessage> GetAsync(string relativeUrl);
    }
}
