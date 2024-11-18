using BarberShop.Services.Catalog.Application.Responses;
using BarberShop.Services.Catalog.Domain;

namespace BarberShop.Services.Catalog.Application.Mapping
{
    public class BrandMapProfile : Profile
    {
        public BrandMapProfile()
        {
            CreateMap<Brand, BrandResponse>()
                .ForMember(target => target.Name, map => map.MapFrom(source => source.Name))
                .ForMember(target => target.Description, map => map.MapFrom(source => source.Description))
                .ForMember(target => target.Id, map => map.MapFrom(source => source.Id));
        }
    }
}
