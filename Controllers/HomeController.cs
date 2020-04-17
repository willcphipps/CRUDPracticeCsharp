using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRUDible.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDible.Controllers {
    public class HomeController : Controller {

        private MyContext _context { get; set; }

        public HomeController (MyContext context) {
            _context = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            List<Dish> dishes = _context.Dishes.OrderByDescending (l => l.CreatedAt).ToList ();
            return View (dishes);
        }

        [HttpGet ("add")]
        public IActionResult Add () {
            return View ();
        }

        [HttpPost ("create")]
        public IActionResult Create (Dish newdish) {
            if (ModelState.IsValid) {
                _context.Dishes.Add (newdish);
                _context.SaveChanges ();
                return RedirectToAction ("Index");
            } else {
                return View ("Add");
            }
        }

        [HttpGet ("{DId}")]
        public IActionResult Show (int DId) {
            Dish show = _context.Dishes.FirstOrDefault (l => l.DishId == DId);
            return View ("Show", show);
        }

        [HttpGet ("edit/{DId}")]
        public IActionResult Edit (int DId) {
            Dish edit = _context.Dishes.FirstOrDefault (l => l.DishId == DId);
            return View (edit);
        }

        [HttpPost ("Update/{DId}")]
        public IActionResult Update (int DId, Dish update) {
            Dish retrieved = _context.Dishes.FirstOrDefault (l => l.DishId == DId);
            if (ModelState.IsValid) {
                retrieved.DishName = update.DishName;
                retrieved.ChefName = update.ChefName;
                retrieved.Calories = update.Calories;
                retrieved.Tastiness = update.Tastiness;
                retrieved.UpdatedAt = DateTime.Now;
                _context.SaveChanges ();
                return Redirect ($"/{DId}");
            } else {
                update.DishId = DId;
                return View ("Edit", update);
            }
        }

        [HttpGet ("delete/{DId}")]
        public IActionResult Destroy (int DId) {
            Dish eightySixed = _context.Dishes.FirstOrDefault (l => l.DishId == DId);
            _context.Dishes.Remove (eightySixed);
            _context.SaveChanges ();
            return Redirect ("/");
        }

    }
}