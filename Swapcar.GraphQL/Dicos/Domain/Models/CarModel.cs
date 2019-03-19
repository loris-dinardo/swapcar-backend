using System.Collections.Generic;

namespace Swapcar.GraphQL.Dicos.Domain.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarVersion> Versions { get; set; }
    }
}
