using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MutfakUygulamasiMVC.Data.Context;
using MutfakUygulamasiMVC.Data.Entity;

namespace MutfakUygulamasiMVC.Controllers
{
    [Authorize]
    public class EnvanterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvanterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tempList = _context.Envanterler.Include(x => x.Urun).ToList();
            return View(tempList);
        }

        public IActionResult Create()
        {
            var tempSelectList = _context.Urunler.ToList().Select(x => new SelectListItem()
            {
                Text = x.ProductName,
                Value = x.Id.ToString()
            });
            ViewBag.SelectList = tempSelectList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Envanter envanter)
        {
            _context.Envanterler.Add(envanter);
            _context.SaveChanges();
            return RedirectToAction("Index", "Envanter");
        }

        public IActionResult Delete(int id)
        {

            var temp = _context.Envanterler.Find(id);
            _context.Envanterler.Remove(temp);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var tempSelectList = _context.Urunler.ToList().Select(x => new SelectListItem()
            {
                Text = x.ProductName,
                Value = x.Id.ToString()
            });
            var temp = _context.Envanterler.Include(x => x.Urun).First(x => x.Id == id);
            ViewBag.SelectList = tempSelectList;
            return View(temp);
        }
        [HttpPost]
        public IActionResult Edit(Envanter envanter)
        {
            _context.Envanterler.Update(envanter);
            _context.SaveChanges();
            return RedirectToAction("Index", "Envanter");
        }
    }
}
