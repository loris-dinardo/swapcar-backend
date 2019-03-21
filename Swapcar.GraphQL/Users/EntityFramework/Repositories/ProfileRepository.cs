using Swapcar.GraphQL.Core.EntityFramework;
using Swapcar.GraphQL.Users.Domain.Models;

namespace Swapcar.GraphQL.Users.EntityFramework.Repositories
{
    public class ProfileRepository : AbstractRepository<int, Profile>
    {
        public ProfileRepository(AppDbContext context) : base(context) { }

        public override int GetId(Profile e)
        {
            return e.Id;
        }
    }
}
