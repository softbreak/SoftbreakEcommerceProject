using AutoMapper;
using Project.BLL.Dtos.ProductDtos;
using Project.CoreMVCUI.Models.ViewModels.ProductViewModels;

namespace Project.CoreMVCUI.Mappings;

public class ProductMappings: Profile
{
    public ProductMappings()
    {
        CreateMap<ProductDto, ProductVm>();
    }
}
