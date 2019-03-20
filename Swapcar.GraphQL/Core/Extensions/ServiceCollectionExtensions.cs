using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Core.EntityFramework;
using GraphQL;
using GraphQL.Server;

namespace Swapcar.GraphQL.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /*************************************
         * DATA BASE EXTENSIONS 
         *************************************/
        public static IServiceCollection AddCoreDatabaseConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            // User Context used by both User and User Rel Repositories
            services.AddDbContext<AppDbContext>(
                 opts => opts.UseNpgsql(Configuration["DbContextSettings:ConnectionString"])
            );
            
            return services;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IServiceCollection AddCoreGraphQLConfiguration(this IServiceCollection services, bool inDevMod)
        {
            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = inDevMod; //set true only in dev mode.
            })
            .AddGraphTypes(ServiceLifetime.Scoped);

            return services;
        }
    }
}
