using Hydro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hydro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<Beverage> Beverages { get; set; }
    }
}
