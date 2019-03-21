using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarModelMutation : ObjectGraphType, ICoreGraphMutationIncluder
    {
        public CarModelMutation(CarModelRepository modelRepository)
        {
            /**
             * NEW MODEL
             */
            Field<CarModelType, CarModel>()
                .Name("createModel")
                .Argument<NonNullGraphType<CarModelInputType>>("model", "model input")
                .ResolveAsync(async ctx =>
                {
                    var model = ctx.GetArgument<CarModel>("model");
                    return await modelRepository.Add(model);
                });

            /**
             * UPDATE MODEL
             */
            Field<CarModelType, CarModel>()
                .Name("updateModel")
                .Argument<NonNullGraphType<CarBrandInputType>>("model", "model input")
                .ResolveAsync(async ctx =>
                {
                    var model = ctx.GetArgument<CarModel>("model");

                    // Check if model exists
                    var currentModel = await modelRepository.FindById(model.Id);
                    if (currentModel == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Model not found"));
                        return null;
                    }
                    // Update model
                    return await modelRepository.Update(model);
                });

            /**
             * DELETE MODEL
             */
            Field<CarModelType, CarModel>()
                .Name("deleteModel")
                .Argument<NonNullGraphType<IdGraphType>>("id", "model id input")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");

                    // Check if model exists
                    var currentModel = await modelRepository.FindById(id);
                    if (currentModel == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Model not found"));
                        return null;
                    }
                    // delete model
                    await modelRepository.Remove(id);

                    return null;
                });
        }
    }
}
