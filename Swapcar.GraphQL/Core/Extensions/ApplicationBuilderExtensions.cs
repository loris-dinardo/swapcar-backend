using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swapcar.GraphQL.Core.Api.GraphQL.Schemas;

namespace Swapcar.GraphQL.Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /*************************************
         * DEBUG EXTENSIONS 
         *************************************/
        public static IApplicationBuilder UseCoreDebug(this IApplicationBuilder app, IConfiguration Configuration, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug();
            }

            return app;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IApplicationBuilder UseCoreGraphQLPlayGround(this IApplicationBuilder app)
        {
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground

            return app;
        }

        public static IApplicationBuilder UseCoreGraphQLSchema(this IApplicationBuilder app)
        {
            app.UseGraphQL<CoreGraphSchema>();

            return app;
        }
    }
}
