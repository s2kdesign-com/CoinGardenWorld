using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp_Api.Tests
{
    
    public class BaseTest
    {
        protected static string SignalRConnectionString = new ConfigurationBuilder()
            .AddJsonFile("appconfig.json", true)
            .AddJsonFile("appconfig.Development.json", true)
            .AddEnvironmentVariables()
            .Build()["AzureSignalRConnectionString"]??"";

    }
}
