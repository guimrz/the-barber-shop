using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;
using BarberShop.Services.Catalog.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Services.Catalog.Application.Queries
{
    public class GetProductTypesQueryHandler : IRequestHandler<GetProductTypesQuery, IEnumerable<ProductTypeResponse>>
    {
        private readonly ICatalogServiceRepository _repository;
        private readonly IMapper _mapper;

        public GetProductTypesQueryHandler(ICatalogServiceRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);

            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ProductTypeResponse>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductType> productTypes = _repository.ProductTypes.AsNoTracking();

            return Task.FromResult(_mapper.Map<IEnumerable<ProductTypeResponse>>(productTypes));
        }
    }
}
