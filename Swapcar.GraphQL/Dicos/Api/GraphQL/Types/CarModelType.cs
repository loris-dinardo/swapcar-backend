using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarModelType : ObjectGraphType<CarModel>
    {
        public CarModelType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.CarBrandId);
            Field<ListGraphType<CarVersionType>, IEnumerable<CarModel>>()
            .Name("Versions");
        }
    }
}
