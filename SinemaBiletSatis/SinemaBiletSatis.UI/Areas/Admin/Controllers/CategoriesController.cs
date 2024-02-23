using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.Service.Abstract;

namespace SinemaBiletSatis.UI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy ="AdminPolicy")]
    public class CategoriesController : Controller
    {
        private readonly IService<Kategori> _service;

        public CategoriesController(IService<Kategori> service)
        {
            _service = service;
        }

        // GET: CategoriesController
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsycn();
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Kategori kategori)
        {
            try
            {
                await _service.AddAsync(kategori);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu.");
            }
            return View(kategori);
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Kategori kategori)
        {
            try
            {
                 _service.Update(kategori);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata oluştu.");
            }
            return View(kategori);
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kategori kategori)
        {
            try
            {
                _service.Delete(kategori);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
