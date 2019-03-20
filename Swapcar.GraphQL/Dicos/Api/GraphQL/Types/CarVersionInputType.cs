using GraphQL.Types;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarVersionInputType : InputObjectGraphType
    {
        public CarVersionInputType()
        {
            Name = "CarVersionInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("carModelId");
        }
    }
}
