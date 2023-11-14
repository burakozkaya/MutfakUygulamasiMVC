using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MutfakUygulamasiMVC.Data.Context;
using MutfakUygulamasiMVC.Data.Entity;

namespace MutfakUygulamasiMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tempList = _context.Urunler.ToList();
            return View(tempList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Urun urun)
        {
            _context.Urunler.Add(urun);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id)
        {
            var temp = _context.Urunler.Find(id);
            _context.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Edit(int id)
        {
            var temp = _context.Urunler.Find(id);
            return View(temp);
        }

        [HttpPost]
        public IActionResult Edit(Urun urun)
        {
            _context.Urunler.Update(urun);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
