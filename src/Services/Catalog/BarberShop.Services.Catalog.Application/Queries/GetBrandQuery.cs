using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetBrandQuery : IRequest<BrandResponse>
    {
        public Guid BrandId { get; set; }
    }
}
