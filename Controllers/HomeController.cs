using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefs_dishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace chefs_dishes.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;
 
        public HomeController(Context context)
        {
            dbContext = context;
        }

        public ViewResult Index()
        {
            List<Chef> Chefs = dbContext.Chef.Include(a => a.Dishes).ToList();
            return View(Chefs);
        }

        [HttpGet("new")]
        public ViewResult New()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create_chef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        [HttpGet("dishes")]
        public ViewResult Dishes()
        {
            List<Dishes> dishesWithChef = dbContext.Dishes.ToList();
            return View(dishesWithChef);
        }

        [HttpGet("dishes/new")]
        public ViewResult New_Dishes()
        {
            List<Chef> Chefs = dbContext.Chef.ToList();
            ViewBag.Chefs = Chefs;
            return View();
        }

        [HttpPost("create_dish")]
        public IActionResult Create_dish(Dishes dish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> Chefs = dbContext.Chef.ToList();
                ViewBag.Chefs = Chefs;
                return View("New_Dishes", dish);
            }
        }
    }
}
