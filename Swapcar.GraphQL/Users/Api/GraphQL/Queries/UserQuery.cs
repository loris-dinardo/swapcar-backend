using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Users.Api.GraphQL.Types;
using Swapcar.GraphQL.Users.EntityFramework.Repositories;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Queries
{
    public class UserQuery : ObjectGraphType, ICoreGraphQueryIncluder
    {
        public UserQuery(UserRepository userRepository)
        {
            Field<ListGraphType<UserType>>("users",
                resolve: context =>
                {
                    return userRepository.FindAllByPredicate(u => u.Profile);
                });

            Field<UserType>("user",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    }
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    if (id <= 0)
                    {
                        context.Errors.Add(new ExecutionError("User Id is invalid or missing"));
                        return null;
                    }

                    return userRepository.FindBy(u => u.Id == id, u => u.Profile);
                });
        }
    }
}
