using GraphQL.Types;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Types
{
    public class ProfileInputType : InputObjectGraphType
    {
        public ProfileInputType()
        {
            Name = "ProfileInputType";
            Field<IdGraphType>("id");
            Field<StringGraphType>("firstName");
            Field<StringGraphType>("lastName");
            Field<NonNullGraphType<IntGraphType>>("userId");
        }
    }
}
