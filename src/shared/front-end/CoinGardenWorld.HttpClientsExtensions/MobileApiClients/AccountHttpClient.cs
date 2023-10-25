using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorld.HttpClientsExtensions.MobileApiClients
{
    public class AccountHttpClient : HttpClientBase<AccountHttpClient, AccountDto>
    {
        public override string ApiKey => "CGW.Mobile.Api";
        public override bool HttpClientIsAuthorized => true;

        public AccountHttpClient(ILogger<AccountHttpClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }

    }
}
