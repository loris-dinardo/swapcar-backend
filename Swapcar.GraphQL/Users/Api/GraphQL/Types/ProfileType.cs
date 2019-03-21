using GraphQL.Types;
using Swapcar.GraphQL.Users.Domain.Models;

namespace Swapcar.GraphQL.Users.Api.GraphQL.Types
{
    public class ProfileType : ObjectGraphType<Profile>
    {
        public ProfileType()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.UserId);
            Field<UserType, User>()
            .Name("User");
        }
    }
}
