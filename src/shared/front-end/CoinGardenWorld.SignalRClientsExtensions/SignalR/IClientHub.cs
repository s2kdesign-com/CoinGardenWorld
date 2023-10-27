using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.SignalRClientsExtensions.SignalR
{
    public interface IClientHub : IAsyncDisposable 
    {
        bool HubIsAuthorized
        {
            get;
        }

        bool IsHubConnected
        {
            get;
        }

        event Action NotifyStateChanged;

        HubConnection? HubConnection
        {
            get;
            set;
        }
    }
}
