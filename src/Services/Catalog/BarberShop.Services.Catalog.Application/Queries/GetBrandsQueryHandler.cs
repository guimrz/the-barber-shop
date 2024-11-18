using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<BrandResponse>>
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetBrandsQueryHandler(ILogger<GetBrandsQueryHandler> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken = default)
        {
            IEnumerable<Brand> brands = await _repository.Brands.AsNoTracking().ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<BrandResponse>>(brands);
        }
    }
}
