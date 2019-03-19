using Swapcar.GraphQL.Dicos.Domain.Models;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public class DbContext 
    {
        private FakeDb _fakeDb { get; set; }

        public DbContext(FakeDb fakeDb)
        {
            _fakeDb = fakeDb;
        }

        public List<T> DbSet<T>(T type)
        {
            if (type is CarBrand) { return _fakeDb.CarBrands as List<T>; }
            else
            if (type is CarModel) { return _fakeDb.CarModels as List<T>; }
            else { return _fakeDb.CarVersions as List<T>; }
        }
    }
}
