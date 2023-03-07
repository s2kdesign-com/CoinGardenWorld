using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.AzureFunctionExtensions.Configurations {
    public class HttpTriggerAuthorization : DefaultOpenApiHttpTriggerAuthorization 
    {
        public override async Task<OpenApiAuthorizationResult> AuthorizeAsync(IHttpRequestDataObject req) {
            var result = default(OpenApiAuthorizationResult);

            /* // ⬇️⬇️⬇️ This is a sample custom authorisation logic ⬇️⬇️⬇️
            var authtoken = (string)req.Headers["Authorization"];
            if (authtoken.IsNullOrWhiteSpace())
            {
                result = new OpenApiAuthorizationResult()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ContentType = "text/plain",
                    Payload = "Unauthorized",
                };
                return await Task.FromResult(result).ConfigureAwait(false);
            }
            if (authtoken.StartsWith("Bearer", ignoreCase: true, CultureInfo.InvariantCulture) == false)
            {
                result = new OpenApiAuthorizationResult()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ContentType = "text/plain",
                    Payload = "Invalid auth format",
                };
                return await Task.FromResult(result).ConfigureAwait(false);
            }
            var token = authtoken.Split(' ').Last();
            if (token != "secret")
            {
                result = new OpenApiAuthorizationResult()
                {
                    StatusCode = HttpStatusCode.Forbidden,
                    ContentType = "text/plain",
                    Payload = "Invalid auth token",
                };
                return await Task.FromResult(result).ConfigureAwait(false);
            }
            // ⬆️⬆️⬆️ This is a sample custom authorisation logic ⬆️⬆️⬆️ */

            return await Task.FromResult(result).ConfigureAwait(false);
        }
    }
}
