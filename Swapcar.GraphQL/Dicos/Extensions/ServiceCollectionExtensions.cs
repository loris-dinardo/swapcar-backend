using Microsoft.Extensions.DependencyInjection;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /*************************************
         * REPOSITORIES EXTENSIONS 
         *************************************/
        public static IServiceCollection AddDicosRepositoriesConfiguration(this IServiceCollection services)
        {
            // AuthClientRepository used by UserSessionManager
            services.AddScoped<CarBrandRepository>();

            return services;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IServiceCollection AddDicosGraphQLSchemas(this IServiceCollection services)
        {
            services.AddScoped<CarBrandSchema>();

            return services;
        }
    }
}
