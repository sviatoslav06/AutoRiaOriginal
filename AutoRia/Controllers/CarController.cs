﻿using DataAccess;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoRia.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly CarDbContext ctx;
        public CarController(CarDbContext ctx)
        {
            this.ctx = ctx;
        }
        private void LoadCategories()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = ctx.Cars.ToList();

            return View(products);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var item = ctx.Cars.Find(id);

            if (item == null) return NotFound();

            ctx.Cars.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Cars prod)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(prod);
            }

            ctx.Cars.Add(prod);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = ctx.Cars.Find(id);

            if (item == null) return NotFound();

            LoadCategories();

            return View(item);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Cars car)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(car);
            }

            ctx.Cars.Update(car);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Show(int id)
        {
            var item = ctx.Cars.Find(id);

            if (item == null) return NotFound();

            ViewBag.Message = item;

            return View("ShowCar");
        }
    }
}
