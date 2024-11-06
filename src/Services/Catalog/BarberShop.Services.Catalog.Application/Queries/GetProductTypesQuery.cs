using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductTypesQuery : IRequest<IEnumerable<ProductTypeResponse>>
    {
    }
}
