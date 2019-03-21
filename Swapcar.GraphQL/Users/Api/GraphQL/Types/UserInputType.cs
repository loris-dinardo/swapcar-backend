using GraphQL.Types;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInputType";
            Field<IdGraphType>("id");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<StringGraphType>("nickName");
        }
    }
}
