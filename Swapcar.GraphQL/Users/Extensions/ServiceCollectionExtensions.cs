using Microsoft.Extensions.DependencyInjection;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Users.Api.GraphQL.Queries;
using Swapcar.GraphQL.Users.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Users.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /*************************************
         * REPOSITORIES EXTENSIONS 
         *************************************/
        public static IServiceCollection AddUsersRepositories(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<ProfileRepository>();
           
            return services;
        }

        /*************************************
         * GRAPHQL EXTENSIONS 
         *************************************/
        public static IServiceCollection AddUsersGraphQLSchemas(this IServiceCollection services)
        {
            services.AddScoped<ICoreGraphQueryIncluder, UserQuery>();

            services.AddScoped<ICoreGraphMutationIncluder, UserMutation>();
            services.AddScoped<ICoreGraphMutationIncluder, ProfileMutation>();

            return services;
        }
    }
}
