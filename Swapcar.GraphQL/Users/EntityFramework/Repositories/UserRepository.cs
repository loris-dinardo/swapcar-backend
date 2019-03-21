using Swapcar.GraphQL.Core.EntityFramework;
using Swapcar.GraphQL.Users.Domain.Models;

namespace Swapcar.GraphQL.Users.EntityFramework.Repositories
{
    public class UserRepository : AbstractRepository<int, User>
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public override int GetId(User e)
        {
            return e.Id;
        }
    }
}
