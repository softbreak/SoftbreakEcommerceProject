using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Dtos.ProductDtos;
using Project.BLL.Services.Interfaces;
using Project.CoreMVCUI.Models.ViewModels.ProductViewModels;

namespace Project.CoreMVCUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IMapper mapper, IProductService productService) : base(mapper)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDto> products = await _productService.GetProductsAsync();
            var result = _mapper.Map<IEnumerable<ProductVm>>(products);
            return View(result);
        }
    }
}
