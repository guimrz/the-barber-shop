using BarberShop.Services.Catalog.Application.Responses;
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
                .ForMember(target => target.Description, map => map.MapFrom(source => source.Description))
                .ForMember(target => target.TypeId, map => map.MapFrom(source => source.Type.Id))
                .ForMember(target => target.BrandId, map => map.MapFrom(source => source.Brand.Id))
                .ForMember(target => target.Price, map => map.MapFrom(source => source.Price));
        }
    }
}
