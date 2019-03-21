using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarBrandMutation : ObjectGraphType, ICoreGraphMutationIncluder
    {
        public CarBrandMutation(CarBrandRepository brandRepository)
        {
            Field<CarBrandType, CarBrand>()
                .Name("createBrand")
                .Argument<NonNullGraphType<CarBrandInputType>>("brand", "brand input")
                .ResolveAsync(ctx =>
                {
                    var brand = ctx.GetArgument<CarBrand>("brand");
                    return brandRepository.Add(brand);
                });
        }
    }
}
