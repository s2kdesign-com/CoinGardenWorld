using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.Authorization
{
    public class UserAccount : RemoteUserAccount
    {
        [JsonPropertyName("groups")]
        public string[] Groups { get; set; } = default!;

        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = default!;
    }

}
