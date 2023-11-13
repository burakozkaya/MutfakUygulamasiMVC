using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutfakUygulamasiMVC.Data.Context;
using MutfakUygulamasiMVC.Models;
using System.Diagnostics;

namespace MutfakUygulamasiMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tempList = _context.Envanterler.Include(x => x.Urun).ToList();
            return View(tempList);
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