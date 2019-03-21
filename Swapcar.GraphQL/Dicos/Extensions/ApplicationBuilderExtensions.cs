using Microsoft.AspNetCore.Builder;

namespace Swapcar.GraphQL.Dicos.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IApplicationBuilder UseDicosGraphQLSchemas(this IApplicationBuilder app)
        {
            /*
            app.UseGraphQL<CarBrandSchema>(path:"/graphql/brands");
            app.UseGraphQL<CarModelSchema>(path: "/graphql/models");
            app.UseGraphQL<CarVersionSchema>(path: "/graphql/versions");
            */
            return app;
        }
    }
}
