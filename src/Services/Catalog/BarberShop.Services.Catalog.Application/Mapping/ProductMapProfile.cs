using BarberShop.Services.Catalog.Application.Objects.Responses;
using BarberShop.Services.Catalog.Domain;

namespace BarberShop.Services.Catalog.Application.Mapping
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(target => target.Id, map => map.MapFrom(source => source.Id))
                .ForMember(target => target.Name, map => map.MapFrom(source => source.Name))
                .ForMember(target => target.Description, map => map.MapFrom(source => source.Description));
        }
    }
}
