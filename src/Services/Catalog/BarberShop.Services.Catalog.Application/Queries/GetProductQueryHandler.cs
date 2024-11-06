using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse?>
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(ILogger<GetProductQueryHandler> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponse?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            Product? product = await _repository.Products
                .AsNoTracking()
                .SingleOrDefaultAsync(product => product.Id == request.ProductId, cancellationToken);

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
