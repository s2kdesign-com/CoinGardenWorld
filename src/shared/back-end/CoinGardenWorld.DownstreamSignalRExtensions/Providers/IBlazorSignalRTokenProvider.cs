using CoinGardenWorld.SignalRClientsExtensions.SignalR;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.DownstreamSignalRExtensions.Providers
{
    public interface IBlazorSignalRTokenProvider : IAccessTokenProvider 
    {
    }
}
