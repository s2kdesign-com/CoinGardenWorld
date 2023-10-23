using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.AzureStorageExtensions.Configuration
{
    public class AzureStorageConfiguration
    {
        public string Blob { get; set; }
        public string Queue { get; set; }
        public string Files { get; set; }
    }

}
