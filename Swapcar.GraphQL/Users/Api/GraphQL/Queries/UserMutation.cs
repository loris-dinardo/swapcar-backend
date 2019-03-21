using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Users.Api.GraphQL.Types;
using Swapcar.GraphQL.Users.Domain.Models;
using Swapcar.GraphQL.Users.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Queries
{
    public class UserMutation : ObjectGraphType, ICoreGraphMutationIncluder
    {
        public UserMutation(UserRepository userRepository)
        {
            /**
             * NEW USER
             */
            Field<UserType, User>()
                .Name("createUser")
                .Argument<NonNullGraphType<UserInputType>>("user", "user input")
                .ResolveAsync(async ctx =>
                {
                    var user = ctx.GetArgument<User>("user");
                    return await userRepository.Add(user);
                });

            /**
             * UPDATE USER
             */
            Field<UserType, User>()
                .Name("updateUser")
                .Argument<NonNullGraphType<UserInputType>>("user", "user input")
                .ResolveAsync(async ctx =>
                {
                    var user = ctx.GetArgument<User>("user");

                    // Check if user exists
                    var currentBrand = await userRepository.FindById(user.Id);
                    if (currentBrand == null)
                    {
                        ctx.Errors.Add(new ExecutionError("User not found"));
                        return null;
                    }
                    // Update user
                    return await userRepository.Update(user);
                });

            /**
             * DELETE USER
             */
            Field<UserType, User>()
                .Name("deleteUser")
                .Argument<NonNullGraphType<IdGraphType>>("id", "user id input")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");

                    // Check if user exists
                    var currentUser = await userRepository.FindById(id);
                    if (currentUser == null)
                    {
                        ctx.Errors.Add(new ExecutionError("User not found"));
                        return null;
                    }
                    // delete user
                    await userRepository.Remove(id);

                    return null;
                });
        }
    }
}
