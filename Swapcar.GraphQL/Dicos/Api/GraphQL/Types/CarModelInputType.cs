using GraphQL.Types;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Types
{
    public class CarModelInputType : InputObjectGraphType
    {
        public CarModelInputType()
        {
            Name = "CarModelInput";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("carBrandId");
        }
    }
}
