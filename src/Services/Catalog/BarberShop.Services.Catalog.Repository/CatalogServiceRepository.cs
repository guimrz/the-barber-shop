using BarberShop.Services.Catalog.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Repository
{
    public class CatalogServiceRepository : ICatalogServiceRepository
    {
        private readonly ILogger _logger;
        private readonly CatalogServiceDbContext _dbContext;

        public CatalogServiceRepository(ILogger<CatalogServiceRepository> logger, CatalogServiceDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(dbContext);

            _logger = logger;
            _dbContext = dbContext;
        }

        public IQueryable<Product> Products => _dbContext.Set<Product>();

        public async Task<Product> InsertAsync(Product product, CancellationToken cancellationToken = default)
        {
            EntityEntry<Product> entry = await _dbContext.AddAsync(product, cancellationToken);

            return entry.Entity;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}