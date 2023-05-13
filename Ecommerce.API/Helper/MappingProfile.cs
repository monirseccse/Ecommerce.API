using AutoMapper;
using Domain.Entities;
using Ecommerce.API.DTOs;

namespace Ecommerce.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProducttoReturnDto>()
                .ForMember(x => x.ProductBrandName, x => x.MapFrom(y => y.ProductBrand.Name))
                .ForMember(x => x.ProductTypeName, x => x.MapFrom(y => y.ProductType.Name))
                .ForMember(x => x.PictureUrl, x => x.MapFrom<ProductUrlResolver>());
        }
    }
}
