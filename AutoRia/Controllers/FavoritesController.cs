using System.Collections.Generic; // Add this using statement
using System.Linq;
using AutoRia.Helpers;
using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRia.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly CarDbContext ctx;

        public FavoritesController(CarDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("favorite_items");

            List<Cars> carss = new List<Cars>(); // Initialize the list

            if (ids != null)
                carss = ctx.Cars.Where(x => ids.Contains(x.Id)).ToList();

            return View(carss);
        }

        public IActionResult Add(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null)
                ids = new List<int>();

            ids.Add(id);

            HttpContext.Session.Set("favorite_items", ids);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Remove(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("favorite_items");

            if (ids != null)
            {
                ids.Remove(id);
                HttpContext.Session.Set("favorite_items", ids);
            }

            // You can redirect to the Index action or any other appropriate page
            return RedirectToAction("Index");
        }
    }
}