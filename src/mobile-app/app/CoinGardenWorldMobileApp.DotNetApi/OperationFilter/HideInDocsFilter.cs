using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoinGardenWorldMobileApp.DotNetApi.OperationFilter
{
    public class HideInDocsFilter : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
#if !DEBUG
            var pathsToRemove = swaggerDoc.Paths
                .Where(pathItem => !pathItem.Key.Contains("api/"))
                .ToList();
#else

            var pathsToRemove = swaggerDoc.Paths
                .Where(pathItem => pathItem.Key.Contains("$metadata"))
                .ToList();
#endif

            foreach (var item in pathsToRemove)
            {
                swaggerDoc.Paths.Remove(item.Key);
            }
        }
    }
}
