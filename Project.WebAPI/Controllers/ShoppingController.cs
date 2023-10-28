using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.ExtensionClasses;
using Project.WebAPI.Models.ShoppingTools;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IProductManager _productManager;
        IOrderManager _orderManager;
        IOrderDetailManager _orderDetailManager;

        public ShoppingController(IProductManager productManager, IOrderManager orderManager, IOrderDetailManager orderDetailManager)
        {
            _productManager = productManager;
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToCart(int id)
        {
            Cart c = HttpContext.Session.GetObject<Cart>("scart") == null ? new Cart() : HttpContext.Session.GetObject<Cart>("scart");

            Product productEntity = await _productManager.FindAsync(id);

            CartItem ci = new()
            {
                ID = productEntity.ID,
                Name = productEntity.ProductName,
                Price = productEntity.UnitPrice
            };

            c.AddToCart(ci);
            HttpContext.Session.SetObject("scart", c);
            return Ok($"{ci.Name} isimli ürün sepete eklenmiştir");
        }

        [HttpGet]
        public async Task<IActionResult> GetCardInfo()
        {
            if(HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                return Ok(c);
            }
            return BadRequest("Sepetinizde henüz bir ürün bulunmamaktadır");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            if(HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                c.RemoveFromCart(id);
                HttpContext.Session.SetObject("scart", c);
                return Ok(c);
            }
            else
            {
                return BadRequest("Sepetinizde ürün bulunmamaktadır");
            }
            
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmOrder(string shippingAddress,int? appUserID)
        {
            if (HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                //API banka ile haberlesme kodları (Kullanıcıdan aldıgınız kredi kartı bilgileri bankanın size verdigi API dökümantasyonunda istenen şekilde Bankanın API projesine gönderilir... Ve eger bankadan dönen sonuc Kartın alısveriş yapmaya uygun oldugu yonundeyse
                Cart c = HttpContext.Session.GetObject<Cart>("scart");

                Order o = new()
                {
                    ShippingAddress = shippingAddress,
                    AppUserID = appUserID
                };

                _orderManager.Add(o);

                foreach (CartItem item in c.MyCart)
                {
                    OrderDetail od = new();
                    od.OrderID = o.ID;
                    od.ProductID = item.ID;
                    od.Quantity = item.Amount;
                    _orderDetailManager.Add(od);
                }

                return Ok($"Siparişiniz alınmıstır...Ödediginiz fiyat : {c.TotalPrice}");
            }
            else
            {
                return BadRequest("Sepetinizde ürün bulunmamaktadır");
            }
        }


    }
}
