using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinemaBiletSatis.Data;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.Service.Abstract;
using SinemaBiletSatis.UI.Models;
using System.Security.Claims;

namespace SinemaBiletSatis.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<Kullanici> _service;
        private readonly IService<Rol> _serviceRol;
        private readonly DatabaseContext _db;

        public AccountController(IService<Kullanici> service, IService<Rol> serviceRol, DatabaseContext db)
        {
            _service = service;
            _serviceRol = serviceRol;
            _db = db;
        }

        //[Authorize(Policy="UserPolicy")]
        public IActionResult Index()
        {
            var movies = _db.Filmler.ToList();

            return View(movies);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rol = await _serviceRol.GetASycn(r => r.Adi == "User");
                    if (rol == null)
                    {
                        ModelState.AddModelError("", "Kayıt Başarısız.");
                        return View();
                    }
                    kullanici.RolId = rol.Id;
                    kullanici.AktifMi = true;
                    kullanici.KullaniciAdi = kullanici.Adi;
                    await _service.AddAsync(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata oluştu.");
                }
            }
          
            return View();
        }


        public  IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginViewModel userViewModel)
        {
            try
            {
                var account =  _service.Get(k => k.Eposta == userViewModel.Eposta && k.Sifre == userViewModel.Sifre && k.AktifMi == true);
                if (account == null)
                {
                 
                    ModelState.AddModelError("", "Giriş Başarısız.");
                }
                else
                {
                    var rol = _serviceRol.Get(r => r.Id == account.RolId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Adi),
                    };
                    if (rol is not null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Adi));
                    }
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    if (rol.Adi=="Admin")
                    {
                        return Redirect("/Admin");
                    }
                    return Redirect("/");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu.");
            }
            return View();

        }
    }
}
