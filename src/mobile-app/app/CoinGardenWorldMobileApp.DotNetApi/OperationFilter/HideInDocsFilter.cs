using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoinGardenWorldMobileApp.DotNetApi.OperationFilter
{
    public class HideInDocsFilter : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //var pathsToRemove = swaggerDoc.Paths
            //    .Where(pathItem => !pathItem.Key.Contains("api/"))
            //    .ToList();
            var pathsToRemove = swaggerDoc.Paths
                .Where(pathItem => pathItem.Key.Contains("$metadata"))
                .ToList();
            foreach (var item in pathsToRemove)
            {
                swaggerDoc.Paths.Remove(item.Key);
            }
        }
    }
}
