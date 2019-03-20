using GraphQL.Types;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarBrandInputType : InputObjectGraphType
    {
        public CarBrandInputType()
        {
            Name = "CarBrandInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
