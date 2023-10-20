using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.SignalR
{
    public interface IClientHub<T> : IAsyncDisposable where T : ClientHub<T>
    {
        bool IsHubConnected
        {
            get;
        }

        event Action NotifyStateChanged;

        HubConnection HubConnection
        {
            get;
            set;
        }
    }
}
