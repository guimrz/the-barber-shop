using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandResponse>
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetBrandQueryHandler(ILogger<GetBrandQueryHandler> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        public async Task<BrandResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            Brand? brand = await _repository.Brands
                .AsNoTracking()
                .SingleOrDefaultAsync(brand => brand.Id == request.BrandId, cancellationToken);

            return _mapper.Map<BrandResponse>(brand);
        }
    }
}
