using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarVersionMutation : ObjectGraphType
    {
        public CarVersionMutation(CarVersionRepository versionRepository)
        {
            Field<CarVersionType, CarVersion>()
                .Name("createVersion")
                .Argument<NonNullGraphType<CarVersionInputType>>("version", "version input")
                .ResolveAsync(ctx =>
                {
                    var version = ctx.GetArgument<CarVersion>("version");
                    return versionRepository.Add(version);
                });
        }
    }
}
