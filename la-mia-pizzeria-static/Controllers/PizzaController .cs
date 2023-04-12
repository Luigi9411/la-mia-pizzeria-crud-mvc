using la_mia_pizzeria_static.Migrations;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
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

            var pizzas = _context.Pizzas.ToArray();

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
               return View(pizza);
            }

            _context.Pizzas.Add(pizza);
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

            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            var pizzaToUpdate = _context.Pizzas.Find(id);

            if (pizzaToUpdate is null)
            {
                return View("NotFound");
            }

            pizzaToUpdate.Name = pizza.Name;
            pizzaToUpdate.Description = pizza.Description;
            pizzaToUpdate.Image = pizza.Image;
            pizzaToUpdate.Price = pizza.Price; 

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
