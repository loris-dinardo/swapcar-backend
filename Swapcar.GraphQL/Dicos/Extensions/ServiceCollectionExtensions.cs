using Microsoft.Extensions.DependencyInjection;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Queries;
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
            services.AddScoped<ICoreGraphQueryIncluder, CarBrandQuery>();
            services.AddScoped<ICoreGraphQueryIncluder, CarModelQuery>();
            services.AddScoped<ICoreGraphQueryIncluder, CarVersionQuery>();

            services.AddScoped<ICoreGraphMutationIncluder, CarBrandMutation>();
            services.AddScoped<ICoreGraphMutationIncluder, CarModelMutation>();
            services.AddScoped<ICoreGraphMutationIncluder, CarVersionMutation>();

            return services;
        }
    }
}
