using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using CoinGardenWorld.HttpClientsExtensions;
using CoinGardenWorldMobileApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;
using System.Net.Http;
using AccountDto = CoinGardenWorldMobileApp.Models.ViewModels.AccountDto;

namespace CoinGardenWorld.DownstreamApiExtensions.MobileApiClients
{
    public class AccountDownstreamApi : DownstreamApiBase<AccountDownstreamApi, AccountDto>
    {
        public override string ApiKey => "CGW.Mobile.Api";
        public AccountDownstreamApi(IDownstreamApi downstreamApi, ILogger<AccountDownstreamApi> logger, IHttpClientFactory httpClientFactory) : base(downstreamApi, logger, httpClientFactory)
        {
        }
    }
}
