using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Dicos.Domain.Models;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<CarBrand> brands { get; set; }
        public DbSet<CarModel> models { get; set; }
        public DbSet<CarVersion> versions { get; set; }
    }
}
