using GraphQL;
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
            /**
             * NEW BRAND
             */ 
            Field<CarBrandType, CarBrand>()
                .Name("createBrand")
                .Argument<NonNullGraphType<CarBrandInputType>>("brand", "brand input")
                .ResolveAsync(async ctx =>
                {
                    var brand = ctx.GetArgument<CarBrand>("brand");
                    return await brandRepository.Add(brand);
                });

            /**
             * UPDATE BRAND
             */
            Field<CarBrandType, CarBrand>()
                .Name("updateBrand")
                .Argument<NonNullGraphType<CarBrandInputType>>("brand", "brand input")
                .ResolveAsync(async ctx =>
                {
                    var brand = ctx.GetArgument<CarBrand>("brand");

                    // Check if brand exists
                    var currentBrand = await brandRepository.FindById(brand.Id);
                    if (currentBrand == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Brand not found"));
                        return null;
                    }
                    // Update brand
                    return await brandRepository.Update(brand);
                });

            /**
             * DELETE BRAND
             */
            Field<CarBrandType, CarBrand>()
                .Name("deleteBrand")
                .Argument<NonNullGraphType<IdGraphType>>("id", "brand id input")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");

                    // Check if brand exists
                    var currentBrand = await brandRepository.FindById(id);
                    if (currentBrand == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Brand not found"));
                        return null;
                    }
                    // delete brand
                    await brandRepository.Remove(id);

                    return null;
                });
        }
    }
}
