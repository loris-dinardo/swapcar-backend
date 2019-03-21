using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Dicos.Domain.Models;
using Swapcar.GraphQL.Users.Domain.Models;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<CarBrand> Brands { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<CarVersion> Versions { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
