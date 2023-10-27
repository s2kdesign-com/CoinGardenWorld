

namespace CoinGardenWorld.HttpClientsExtensions
{
    public interface IHttpClientBase<M>
    {
        Uri? BaseAddress
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
