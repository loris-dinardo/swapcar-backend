using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Types;
using Swapcar.GraphQL.Dicos.EntityFramework.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Queries
{
    public class CarBrandQuery : ObjectGraphType
    {
        public CarBrandQuery(CarBrandRepository brandRepository)
        {
            Field<ListGraphType<CarBrandType>>("brands",
                resolve: context =>
                {
                    var result = brandRepository.FindAllEager();
                    return result;
                });

            Field<CarBrandType>("brand",
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
                        context.Errors.Add(new ExecutionError("Brand Id is invalid or missing"));
                        return null;
                    }

                    var result = brandRepository.FindBy(x => x.Id == id, x => x.Models);
                    return result;
                });
        }
    }
}
