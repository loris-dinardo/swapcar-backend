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
        public static IServiceCollection AddDicosRepositories(this IServiceCollection services)
        {
            services.AddScoped<CarBrandRepository>();
            services.AddScoped<CarModelRepository>();
            services.AddScoped<CarVersionRepository>();

            return services;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IServiceCollection AddDicosGraphQLSchemas(this IServiceCollection services)
        {
            services.AddScoped<CarBrandSchema>();
            services.AddScoped<CarModelSchema>();
            services.AddScoped<CarVersionSchema>();

            return services;
        }
    }
}
