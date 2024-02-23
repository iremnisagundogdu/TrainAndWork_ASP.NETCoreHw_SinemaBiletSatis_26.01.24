using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SinemaBiletSatis.Data;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.UI.Models;
using System.Diagnostics;
using System.Security.AccessControl;

namespace SinemaBiletSatis.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DatabaseContext databaseContext;
        public HomeController(ILogger<HomeController> logger,DatabaseContext databaseContext)
        {
            _logger = logger;
            this.databaseContext = databaseContext;
        
        }

        public IActionResult Index()
        {

            var movies = databaseContext.Filmler.ToList();
            return View(movies);
        }
      
        public IActionResult BuyTicket(int movieId)
        {
      
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.User.Identity.Name;
                Film movie = databaseContext.Filmler.FirstOrDefault(f => f.Id == movieId);

                BuyTicketViewModel viewModel = new BuyTicketViewModel
                {
                    MovieId = movieId,
                    MovieTitle = movie.FilmAdi,
                    UserName = userName, 
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public IActionResult BuyTicket(BuyTicketViewModel model)
        {
            var userName = HttpContext.User.Identity.Name;
            var user = databaseContext.Kullanicilar.FirstOrDefault(k => k.Adi == userName);
            if (ModelState.IsValid)
            {
                Bilet ticket = new Bilet
                {
                    GosterimID = 3, 
                    KullaniciID = user.Id,
                    KoltukNumarasi = "A4",
                    SatisTarihi = DateTime.Now,
                    Fiyat = 22,
                    
                };

                databaseContext.Biletler.Add(ticket);
                databaseContext.SaveChanges();
               return RedirectToAction("Fatura","Home");

                
            }

            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Fatura()
        {
            Iyzipay.Options options = new Iyzipay.Options();
            options.ApiKey = "sandbox-Hol2hCzKVpo2HsL6dK1ULVFcWiUtOs20";
            options.SecretKey = "sandbox-YtsAJNo1UEFEplE0CN4zJlWfSDwerukY";
            options.BaseUrl = "Https://sandbox-api.iyzipay.com";



            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://localhost:7066/Home/Success";


            Buyer buyer = new Buyer();
            buyer.Id = "asdadsada";
            buyer.Name = "Erhan";
            buyer.Surname = "Kaya";
            buyer.GsmNumber = "+905554443322";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2000-12-12 12:00:00";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Erhan Kaya";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Bereket döner karşısı";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Erhan Kaya";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Bereket Döner";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketProduct;
            basketProduct = new BasketItem();
            basketProduct.Id = "1";
            basketProduct.Name = "Asus Bilgisayar";
            basketProduct.Category1 = "Bilgisayar";
            basketProduct.Category2 = "";
            basketProduct.ItemType = BasketItemType.PHYSICAL.ToString();

            double price = 1;
            double endPrice = 1;
            basketProduct.Price = endPrice.ToString().Replace(",", "");
            basketItems.Add(basketProduct);

            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.pay = checkoutFormInitialize.CheckoutFormContent;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}