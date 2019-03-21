using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Core.EntityFramework;
using Swapcar.GraphQL.Core.Exceptions;
using Swapcar.GraphQL.Dicos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Swapcar.GraphQL.Dicos.EntityFramework.Repositories
{
    public class CarBrandRepository : AbstractRepository<int, CarBrand>
    {
        public CarBrandRepository(AppDbContext context) : base(context) { }

        public override int GetId(CarBrand e)
        {
            return e.Id;
        }

        public async Task<List<CarBrand>> FindAllEager()
        {
            try
            {
                return await _dbSet
                    .AsNoTracking()
                    .Include(b => b.Models)
                        .ThenInclude(m => m.Versions)
                    .ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException("Error attempting to find all elements with all sub lists included", ex);
            }
        }

        public async Task<CarBrand> FindByIdEager(int id)
        {
            try
            {
                return await _dbSet
                    .AsNoTracking()
                    .Include(b => b.Models)
                        .ThenInclude(m => m.Versions)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException($"Error attempting to find element {id} with all sub lists included", ex);
            }
        }
    }
}
