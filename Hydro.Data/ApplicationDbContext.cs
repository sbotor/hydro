using Hydro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hydro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<DrinkContainer> DrinkContainers { get; set; }

        public DbSet<DrinkType> DrinkTypes { get; set; }
    }
}
