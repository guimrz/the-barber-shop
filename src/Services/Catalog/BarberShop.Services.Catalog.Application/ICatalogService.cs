using BarberShop.Services.Catalog.Application.Objects.Responses;

namespace BarberShop.Services.Catalog.Application
{
    public interface ICatalogService
    {
        Task<ProductResponse?> GetProductAsync(Guid productId, CancellationToken cancellationToken = default);

        Task<ProductResponse> CreateProductAsync(string name, string? description, CancellationToken cancellationToken = default);

        Task<IEnumerable<ProductResponse>> GetProductsAsync(int page, int pageSize, string? search, CancellationToken cancellationToken = default);
    }
}