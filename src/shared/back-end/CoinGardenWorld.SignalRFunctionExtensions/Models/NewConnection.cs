﻿
namespace CoinGardenWorld.SignalRFunctionExtensions.Models;


public class NewConnection
{
    public string ConnectionId { get; }

    public string Authentication { get; }

    public NewConnection(string connectionId, string auth)
    {
        ConnectionId = connectionId;
        Authentication = auth;
    }
}
