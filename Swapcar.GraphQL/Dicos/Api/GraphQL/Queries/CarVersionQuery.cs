using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarVersionQuery : ObjectGraphType
    {
        public CarVersionQuery(CarVersionRepository versionRepository)
        {
            Field<ListGraphType<CarVersionType>>("versions",
                resolve: context =>
                {
                    return versionRepository.FindAll();
                });

            Field<CarVersionType>("version",
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
                        context.Errors.Add(new ExecutionError("Version Id is invalid or missing"));
                        return null;
                    }

                    return versionRepository.FindById(id);
                });
        }
    }
}
