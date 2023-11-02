using CoinGardenWorld.HttpClientsExtensions.MobileApiClients;
using CoinGardenWorld.HttpClientsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;

namespace CoinGardenWorld.DownstreamApiExtensions.MobileApiClients
{
    public class MobileApiAuthorizedDownstreamApi : DownstreamApiBase<MobileApiAuthorizedDownstreamApi, string>
    {

        public override string ApiKey => "CGW.Mobile.Api";

        public MobileApiAuthorizedDownstreamApi(IDownstreamApi downstreamApi, ILogger<MobileApiAuthorizedDownstreamApi> logger, IHttpClientFactory httpClientFactory) : base(downstreamApi, logger, httpClientFactory)
        {
        }
    }
}
