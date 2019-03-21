using Swapcar.GraphQL.Core.EntityFramework;
using Swapcar.GraphQL.Dicos.Domain.Models;

namespace Swapcar.GraphQL.Dicos.EntityFramework.Repositories
{
    public class CarModelRepository : AbstractRepository<int, CarModel>
    {
        public CarModelRepository(AppDbContext context) : base(context) { }

        public override int GetId(CarModel e)
        {
            return e.Id;
        }
    }
}
