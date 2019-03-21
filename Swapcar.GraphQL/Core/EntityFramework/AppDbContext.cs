using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Dicos.Domain.Models;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<CarBrand> Brands { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<CarVersion> Versions { get; set; }
    }
}
