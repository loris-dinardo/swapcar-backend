using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarModelQuery : ObjectGraphType
    {
        public CarModelQuery(CarModelRepository modelRepository)
        {
            Field<ListGraphType<CarModelType>>("models",
                resolve: context =>
                {
                    return modelRepository.FindAllByPredicate(x => x.Versions);
                });

            Field<CarModelType>("model",
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
                        context.Errors.Add(new ExecutionError("Model Id is invalid or missing"));
                        return null;
                    }

                    return modelRepository.FindBy(x => x.Id == id, x => x.Versions);
                });
        }
    }
}
