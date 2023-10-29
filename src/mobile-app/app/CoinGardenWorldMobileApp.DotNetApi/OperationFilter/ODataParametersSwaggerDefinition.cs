using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CoinGardenWorldMobileApp.DotNetApi.OperationFilter
{
    /// <summary>
    /// Help your swagger show OData query options with example pre-fills
    /// </summary>
    public class ODataParametersSwaggerDefinition : IOperationFilter
    {
        private static readonly Type QueryableType = typeof(IQueryable);
        private static readonly OpenApiSchema stringSchema = new OpenApiSchema { Type = "string" };
        private static readonly OpenApiSchema intSchema = new OpenApiSchema { Type = "integer" };

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasNoParams = (operation.Parameters == null || operation.Parameters.Count == 0);
            var isQueryable = context.MethodInfo.ReturnType.GetInterfaces().Any(i => i == QueryableType);

            if (hasNoParams && isQueryable)
            {

                operation.Parameters = new List<OpenApiParameter>();
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$filter",
                    Description = "Filter the results using OData syntax.",
                   // Example = OpenApiAnyFactory.CreateFor(stringSchema, "ProductName eq 'YOGURT'"),
                    Required = false,
                    In = ParameterLocation.Query,
                    Schema = stringSchema

                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$select",
                    Description = "Trim the fields returned using OData syntax",
                    Example = OpenApiAnyFactory.CreateFromJson("{ 'Id':'string','ProductName':'string'}") ,
                    Required = false,
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema { Type = "string" }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$orderby",
                    Description = "Order the results using OData syntax.",
                  //  Example = OpenApiAnyFactory.CreateFor(stringSchema, "Price,ProductName ASC"),
                    Required = false,
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema { Type = "string" }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$skip",
                    Description = "The number of results to skip.",
                  //  Example = OpenApiAnyFactory.CreateFor(intSchema, 100),
                    Required = false,
                    In = ParameterLocation.Query,
                    Schema = intSchema
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "$top",
                    Description = "The number of results to return.",
                //    Example = OpenApiAnyFactory.CreateFor(intSchema, 50),
                    Required = false,
                    In = ParameterLocation.Query,
                    Schema = intSchema
                });


                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "$expand",
                    Description = "Expand functionality can be used to query related data. For example, to get the Course data for each Enrollment entity, include ?$expand=course",
                    Required = false,
                    In = ParameterLocation.Query,
                });
            }
        }
    }
}
