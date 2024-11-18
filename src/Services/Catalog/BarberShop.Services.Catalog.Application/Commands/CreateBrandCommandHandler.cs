using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandResponse>
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(ILogger<CreateBrandCommandHandler> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<BrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            Brand brand = new Brand(request.Name, request.Description);

            brand = await _repository.InsertAsync(brand, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BrandResponse>(brand);
        }
    }
}
