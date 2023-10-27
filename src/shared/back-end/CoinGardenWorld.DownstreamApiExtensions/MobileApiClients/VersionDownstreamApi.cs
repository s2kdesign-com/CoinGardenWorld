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
    public class VersionDownstreamApi : DownstreamApiBase<VersionDownstreamApi, string>
    {

        public override string ApiKey => "CGW.Mobile.Api";

        public VersionDownstreamApi(IDownstreamApi downstreamApi, ILogger<VersionDownstreamApi> logger, IHttpClientFactory httpClientFactory) : base(downstreamApi, logger, httpClientFactory)
        {
        }
    }
}
