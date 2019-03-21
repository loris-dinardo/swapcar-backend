using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarVersionMutation : ObjectGraphType, ICoreGraphMutationIncluder
    {
        public CarVersionMutation(CarVersionRepository versionRepository)
        {
            /**
             * NEW VERSION
             */
            Field<CarVersionType, CarVersion>()
                .Name("createVersion")
                .Argument<NonNullGraphType<CarVersionInputType>>("version", "version input")
                .ResolveAsync(async ctx =>
                {
                    var version = ctx.GetArgument<CarVersion>("version");
                    return await versionRepository.Add(version);
                });

            /**
             * UPDATE VERSION
             */
            Field<CarVersionType, CarVersion>()
                .Name("updateVersion")
                .Argument<NonNullGraphType<CarVersionInputType>>("version", "version input")
                .ResolveAsync(async ctx =>
                {
                    var version = ctx.GetArgument<CarVersion>("version");

                    // Check if version exists
                    var currentVersion = await versionRepository.FindById(version.Id);
                    if (currentVersion == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Version not found"));
                        return null;
                    }
                    // Update version
                    return await versionRepository.Update(version);
                });

            /**
             * DELETE VERSION
             */
            Field<CarVersionType, CarVersion>()
                .Name("deleteVersion")
                .Argument<NonNullGraphType<IdGraphType>>("id", "brand id input")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");

                    // Check if version exists
                    var currentVersion = await versionRepository.FindById(id);
                    if (currentVersion == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Version not found"));
                        return null;
                    }
                    // delete Version
                    await versionRepository.Remove(id);

                    return null;
                });
        }
    }
}
