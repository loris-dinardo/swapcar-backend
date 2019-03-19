using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarBrandType : ObjectGraphType<CarBrand>
    {
        public CarBrandType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<ListGraphType<CarModelType>, IEnumerable<CarModel>>()
            .Name("Models");
        }
    }
}
