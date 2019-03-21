using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarModelMutation : ObjectGraphType
    {
        public CarModelMutation(CarModelRepository modelRepository)
        {
            Field<CarModelType, CarModel>()
                .Name("createModel")
                .Argument<NonNullGraphType<CarModelInputType>>("model", "model input")
                .ResolveAsync(ctx =>
                {
                    var model = ctx.GetArgument<CarModel>("model");
                    return modelRepository.Add(model);
                });
        }
    }
}
