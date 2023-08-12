using Project.BLL.Dtos.ProductDtos;
using Project.BLL.Services.Interfaces;
using Project.BLL.UnitOfWorks;

namespace Project.BLL.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _unitOfWork.GetProductRepository().GetAllAsync(null, product=> product.Category);
        var result = _unitOfWork.Mapper.Map<IEnumerable<ProductDto>>(products);
        return result;
    }
}