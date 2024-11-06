using BarberShop.Services.Catalog.Application.Responses;
using MediatR;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductQuery : IRequest<ProductResponse?>
    {
        public Guid ProductId { get;  }

        public GetProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
