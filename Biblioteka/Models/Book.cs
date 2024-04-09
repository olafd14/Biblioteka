using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Book
    {
        /// <summary>
        /// Id Książki
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tytuł Książki
        /// </summary>
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        /// <summary>
        /// Opis książki
        /// </summary>
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        /// <summary>
        /// Autor Książki
        /// </summary>
        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        /// <summary>
        /// Okładka książki
        /// </summary>
        [Display(Name = "Zdjęcie")]
        public string? ImageUrl { get; set; }
        public int NumberOfRatings { get; set; }
        /// <summary>
        /// Ocena użytkowników książki
        /// </summary>
        [Display(Name = "Ocena")]
        public double UserRating { get; set; }
        /// <summary>
        /// Czy książka jest dostępna do wypożyczenia
        /// </summary>
        [Required]
        [Display(Name = "Dostępność")]
        public bool isAvailable { get; set; }
        /// <summary>
        /// Kategoria książki połączona z tabelą kategorie
        /// </summary>
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        public Book()
        {
            NumberOfRatings = 0;
        }

        public void CalculateOverallRating(int newRating)
        {
            // Oblicz nową ocenę książki na podstawie dotychczasowej oceny i ilości ocen
            double newOverallRating = (UserRating * NumberOfRatings + newRating) / (NumberOfRatings + 1);

            // Zaktualizuj właściwości książki
            UserRating = newOverallRating;
            NumberOfRatings++;
        }
    }
}
