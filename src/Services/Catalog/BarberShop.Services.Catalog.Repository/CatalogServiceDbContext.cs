using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BarberShop.Services.Catalog.Repository
{
    public class CatalogServiceDbContext : DbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies all the entity configurations of this assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
