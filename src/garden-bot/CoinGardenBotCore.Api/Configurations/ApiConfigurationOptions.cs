using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenBotCore_Api.Configurations {
    public class ApiConfigurationOptions : DefaultOpenApiConfigurationOptions {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo() {
            Version = GetPackageVersion(),
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

        public static string GetPackageVersion() {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return version.ToString();
        }
    }
}
