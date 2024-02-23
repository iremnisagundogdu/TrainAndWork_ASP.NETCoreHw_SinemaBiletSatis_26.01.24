using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.Service.Abstract;
using System.Security.Claims;

namespace SinemaBiletSatis.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;

        public LoginController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string Eposta, string Sifre)
        {
            try
            {
                var account = _service.Get(k=>k.Eposta==Eposta && k.Sifre==Sifre && k.AktifMi==true);
                if (account==null)
                {
                    TempData["Mesaj"] = "Giriş başarısız.";
                }
                else
                {
                    var rol = _serviceRol.Get(r=>r.Id == account.RolId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Adi),
                    };
                    if (rol is not null )
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Adi));
                    }
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }
            }
            catch (Exception)
            {

                TempData["Mesaj"] = "Hata Oluştu.";
            }
            return View();
        }
    }
}
