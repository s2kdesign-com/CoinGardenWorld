namespace CoinGardenWorld.HttpClientsExtensions
{
    public interface IHttpClientBase<M> 
    {
        HttpClient HttpClient {  get; }

        Task<bool> UserIsAuthenticated();

        string BaseAddress
        {
            get;
        }
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
