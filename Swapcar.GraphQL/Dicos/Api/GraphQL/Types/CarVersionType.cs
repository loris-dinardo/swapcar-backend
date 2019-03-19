using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Domain.Models;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarVersionType : ObjectGraphType<CarVersion>
    {
        public CarVersionType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
