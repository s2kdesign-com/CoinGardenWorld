using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinGardenWorld.HttpClientsExtensions;

namespace CoinGardenWorld.DownstreamApiExtensions
{
    public interface IDownstreamApiBase<T> : IHttpClientBase<T>
    {
    }
}
