using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Aggiungi il nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Aggiungi la descrizione")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Deve contenere almeno cinque parole")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Aggiungi l'immagine")]
        public string? Image {get; set;}

        [Required(ErrorMessage = "Aggiungi il prezzo")]
        [Range(3, double.MaxValue)]
        
        public double Price { get; set; }

    }
}
