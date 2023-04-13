namespace la_mia_pizzeria_static.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; } = new Pizza();
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
    }
}
