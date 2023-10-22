using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoinGardenWorldMobileApp.MobileAppTheme.HttpClients.MobileApiClients
{
    public class AccountHttpClient : HttpClientBase<AccountHttpClient, AccountDto>
    {
        public override bool HttpClientIsAuthorized => true;

        public AccountHttpClient(ILogger<AccountHttpClient> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration, AuthenticationStateProvider authStateProvider) : base(logger, httpClientFactory, configuration, authStateProvider)
        {
        }

    }
}
