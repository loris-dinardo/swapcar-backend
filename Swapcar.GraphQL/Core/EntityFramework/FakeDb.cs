using Swapcar.GraphQL.Dicos.Domain.Models;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public class FakeDb
    {
        public List<CarBrand> CarBrands { get; set; }
        public List<CarModel> CarModels { get; set; }
        public List<CarVersion> CarVersions { get; set; }

        public FakeDb()
        {
            CarBrands = new List<CarBrand>();
            CarModels = new List<CarModel>();
            CarVersions = new List<CarVersion>();
        }
    }
}
