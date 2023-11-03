using Microsoft.AspNetCore.SignalR.Client;

namespace CoinGardenWorld.SignalRClientsExtensions.SignalR
{
    public interface IClientHub  
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
