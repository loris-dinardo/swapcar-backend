using Swapcar.GraphQL.Core.Domain.Model;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    public interface ICarRepository : IRepository<int, CarBrand>
    {
    }
}
