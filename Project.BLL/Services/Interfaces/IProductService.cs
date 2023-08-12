using Project.BLL.Dtos.ProductDtos;

namespace Project.BLL.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>>GetProductsAsync();
}