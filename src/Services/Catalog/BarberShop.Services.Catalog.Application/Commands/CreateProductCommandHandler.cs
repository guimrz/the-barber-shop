using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BarberShop.Services.Catalog.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly ILogger _logger;
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            Brand? brand = await _repository.Brands.SingleOrDefaultAsync(brand => brand.Id == request.BrandId, cancellationToken);

            if (brand is null)
            {
                throw new InvalidOperationException($"The specified brand with id '{request.BrandId}' could not be found.");
            }

            ProductType? productType = await _repository.ProductTypes.SingleOrDefaultAsync(productType => productType.Id == request.TypeId, cancellationToken);

            if (productType is null)
            {
                throw new InvalidOperationException($"The specified product type with id '{request.TypeId}' could not be found.");
            }

            Product product = new Product(request.Name, request.Description, request.Price, brand, productType);

            product = await _repository.InsertAsync(product, cancellationToken);

            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
