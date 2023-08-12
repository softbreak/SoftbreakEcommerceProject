using AutoMapper;
using Project.BLL.Dtos.ProductDtos;
using Project.ENTITIES.Models;

namespace Project.BLL.Mappings;

public class ProductMappings:Profile
{
    public ProductMappings()
    {
        CreateMap<Product,ProductDto>()
        .ForMember(src=> src.CategoryName, opt=> opt.MapFrom(dest=> dest.Category.CategoryName));
    }
}