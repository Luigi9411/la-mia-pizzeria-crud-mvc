using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; }

        public void Seed()
        {

            if (!Pizzas.Any())
            {
                var seed = new Pizza[]
                {
            new Pizza
            {
                Name = "Pizza Margherita",
                Description = "Pizza classica dal gusto inconfondibile.",
                Image = "img/margherita-50kalo.jpg",
                Price = 4,
            },
            new Pizza
            {
                Name = "Americana",
                Description = "Pizza che De Sica definirebbe con: 'Che è sta cafonata'.",
                Image = "img/americana.jpg",
                Price = 5,
            },
            new Pizza
            {
                Name = "Diavola",
                Description = "Pizza leggera ma quel pizzico in più.",
                Image = "img/diavola.jpg",
                Price = 4.5,
            },
            new Pizza
            {
                Name = "Capricciosa",
                Description = "Pizza amata dal ristoratore. Gli permette di liberarsi dei condimenti",
                Image = "img/Capricciosa.jpg",
                Price = 6.5,
            }
            };

                Pizzas.AddRange(seed);

                SaveChanges();
            }
        }
    }
}

