using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string? Search { get; set; }
    }
}
