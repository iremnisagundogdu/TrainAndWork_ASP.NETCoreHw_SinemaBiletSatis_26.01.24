using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.Service.Abstract;
using SinemaBiletSatis.UI.Utils;

namespace SinemaBiletSatis.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class MoviesController : Controller
    {
        private readonly IService<Film> _service;

        public MoviesController(IService<Film> service)
        {
            _service = service;
        }

        // GET: MoviesController
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsycn();
            return View(model);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Film film, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    film.Image = await FileHelper.FileLoaderAsync(Image, "/img/");
                    await _service.AddAsync(film);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");

                }

            }
           
            return View(film);
        }

        // GET: MoviesController/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Film film, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                    {
                        film.Image = await FileHelper.FileLoaderAsync(Image, "/img/");
                    }
            
                    _service.Update(film);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");

                }

            }
            return View(film);
        }

        // GET: MoviesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Film film)
        {
            try
            {

                _service.Delete(film);
               await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
