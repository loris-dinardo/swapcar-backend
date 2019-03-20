using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas;

namespace Swapcar.GraphQL.Dicos.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IApplicationBuilder UseDicosGraphQLSchemas(this IApplicationBuilder app)
        {
            app.UseGraphQL<CarBrandSchema>();

            return app;
        }
    }
}
