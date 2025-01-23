using AutoMapper;
using Product.Application.DTOs;
namespace Product.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product.Domain.Entities.Products, ProductDTO>().ReverseMap().
                ForMember(dest => dest.ProductId, opt => opt.Ignore()); ;
        }
    }
}
