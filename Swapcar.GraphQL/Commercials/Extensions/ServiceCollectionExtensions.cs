using Microsoft.Extensions.DependencyInjection;
using Swapcar.GraphQL.Commercials.Api.GraphQL.Queries;
using Swapcar.GraphQL.Commercials.EntityFramework.Repositories;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Commercials.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /*************************************
         * REPOSITORIES EXTENSIONS 
         *************************************/
        public static IServiceCollection AddCommercialsRepositories(this IServiceCollection services)
        {
            services.AddScoped<SearchRepository>();
            services.AddScoped<SellRepository>();
            services.AddScoped<TradeInRepository>();

            return services;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IServiceCollection AddCommercialsGraphQLSchemas(this IServiceCollection services)
        {
            services.AddScoped<ICoreGraphQueryIncluder, SearchQuery>();
            services.AddScoped<ICoreGraphQueryIncluder, SellQuery>();
            services.AddScoped<ICoreGraphQueryIncluder, TradeInQuery>();

            services.AddScoped<ICoreGraphMutationIncluder, SearchMutation>();
            services.AddScoped<ICoreGraphMutationIncluder, SellMutation>();
            services.AddScoped<ICoreGraphMutationIncluder, TradeInMutation>();

            return services;
        }
    }
}
