using GraphQL.Types;
using Swapcar.GraphQL.Users.Domain.Models;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.Email);
            Field(x => x.NickName);
            Field<ProfileType, Profile>()
            .Name("Profile");
        }
    }
}
