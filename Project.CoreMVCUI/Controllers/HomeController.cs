using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services.Interfaces;
using Project.CoreMVCUI.Models;
using Project.CoreMVCUI.Models.ViewModels.ProductViewModels;
using System.Diagnostics;

namespace Project.CoreMVCUI.Controllers
{
    public class HomeController : BaseController
    {
    
        private readonly IProductService _productService;
        public HomeController(IMapper mapper, IProductService productService) : base(mapper)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            var result = products.Select(product => new ProductVm(product.ID, product.ProductName, product.UnitPrice, product.CategoryName));
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}