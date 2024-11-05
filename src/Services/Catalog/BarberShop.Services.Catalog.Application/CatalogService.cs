using BarberShop.Services.Catalog.Application.Objects.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application
{
    public class CatalogService : ICatalogService
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public CatalogService(ILogger<CatalogService> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> CreateProductAsync(string name, string? description, CancellationToken cancellationToken = default)
        {
            Product product = new Product(name, description);

            product = await _repository.InsertAsync(product, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse?> GetProductAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            Product? product = await _repository.Products
                .AsNoTracking()
                .SingleOrDefaultAsync(product => product.Id == productId, cancellationToken);

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(page, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

            IQueryable<Product> products = _repository.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products.Where(product => EF.Functions.Like(product.Name, "%" + search + "%"));
            }

            var filteredProducts = await products.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductResponse>>(filteredProducts);
        }
    }
}
