using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.AzureFunctionExtensions.Configurations {
    public class ApiConfigurationOptions : DefaultOpenApiConfigurationOptions {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo() {
            Version = GetPackageVersion().ToString(),
            Title = GetOpenApiDocTitle(),
            Description = GetOpenApiDocDescription(),
            TermsOfService = new Uri("https://coingarden.world/terms-and-conditions"),
            Contact = new OpenApiContact() {
                Name = "CoinGarden.World",
                Email = "admin@CoinGarden.World",
                Url = new Uri("http://coingarden.world"),
            },
            License = new OpenApiLicense() {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };

        public static Version GetPackageVersion() {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            return version;
        }
    }
}
