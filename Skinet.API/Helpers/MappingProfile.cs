using AutoMapper;
using Skinet.API.Dtos;
using Skinet.Core.Entities;

namespace Skinet.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(p =>
                    p.ProductType, des =>
                    des.MapFrom(s => s.ProductType.Name))
                .ForMember(p =>
                    p.ProductBrand, des =>
                    des.MapFrom(s => s.ProductBrand.Name))
                .ForMember(u => u.PictureUrl, o =>
                    o.MapFrom<ProductUrlResolver>())
                .ReverseMap();
        }
    }
}
