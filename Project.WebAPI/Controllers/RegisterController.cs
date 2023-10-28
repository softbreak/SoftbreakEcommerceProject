using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.AppUsers.RequestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IAppUserManager _appUserManager;

        public RegisterController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel item)
        {
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password
            };

            bool result = await _appUserManager.CreateUserAsync(appUser);
            if (result)
            {
                return Ok("Kullanıcı ekleme basarılı");
            }
            return BadRequest("Kullanıcı ekleme kısmında bir sorunla karsılasıldı");
        }
    }
}
