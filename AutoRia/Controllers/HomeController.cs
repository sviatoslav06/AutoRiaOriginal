using AutoRia.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoRia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarDbContext ctx;

        public HomeController(ILogger<HomeController> logger, CarDbContext ctx)
        {
            _logger = logger;
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View(ctx.Cars.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Show(int id)
        {
            var item = ctx.Cars.Find(id);

            if (item == null) return NotFound();

            ViewBag.Message = item;

            return View("ShowCar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}