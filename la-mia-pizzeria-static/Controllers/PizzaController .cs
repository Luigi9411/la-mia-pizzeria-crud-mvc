using la_mia_pizzeria_static.Migrations;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;
        private readonly PizzaContext _context;

        public PizzaController(ILogger<PizzaController> logger, PizzaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var pizzas = _context.Pizzas.Include(p => p.Category).ToArray();

            return View(pizzas);
        }

        public IActionResult Detail(int id)
        {

            var pizza = _context.Pizzas.Find(id);

            if (pizza is null)
            {
                return NotFound($"L'id {id} della pizza non è stato trovato");
            }

            return View(pizza);
        }

        public IActionResult Create()
        {
            var formModel = new PizzaFormModel
            {
                Categories = _context.Categories.ToArray(),
            };
            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = _context.Categories.ToArray();
               return View(form);
            }

            _context.Pizzas.Add(form.Pizza);
            _context.SaveChanges();

            return RedirectToAction("Index");
        } 

        public IActionResult Update(int id)
        {
            var pizza = _context.Pizzas.Find(id);

            if (pizza is null)
            {
                return View("NotFound");
            }

            var formModel = new PizzaFormModel
            {
                Pizza = pizza,
                Categories = _context.Categories.ToArray()
            };

            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaFormModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var pizzaToUpdate = _context.Pizzas.Find(id);

            if (pizzaToUpdate is null)
            {
                return View("NotFound");
            }

            pizzaToUpdate.Name = form.Pizza.Name;
            pizzaToUpdate.Description = form.Pizza.Description;
            pizzaToUpdate.Image = form.Pizza.Image;
            pizzaToUpdate.Price = form.Pizza.Price; 

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var pizzaToDelete = _context.Pizzas.Find(id);

            if (pizzaToDelete is null)
            {
                return View("NotFound");
            }

            _context.Pizzas.Remove(pizzaToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
