namespace CoinGardenWorld.HttpClientsExtensions
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
