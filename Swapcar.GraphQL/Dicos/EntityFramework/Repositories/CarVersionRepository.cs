using Swapcar.GraphQL.Core.EntityFramework;
using Swapcar.GraphQL.Dicos.Domain.Models;

namespace Swapcar.GraphQL.Dicos.EntityFramework.Repositories
{
    public class CarVersionRepository : AbstractRepository<int, CarVersion>
    {
        public CarVersionRepository(AppDbContext context) : base(context) { }

        public override int GetId(CarVersion e)
        {
            return e.Id;
        }
    }
}
