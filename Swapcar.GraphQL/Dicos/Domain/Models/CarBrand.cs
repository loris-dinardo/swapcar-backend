using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarModel> Models { get; set; }
    }
}
