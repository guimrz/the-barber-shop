using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public record CreateBrandCommand : IRequest<BrandResponse>
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
