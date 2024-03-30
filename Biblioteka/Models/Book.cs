using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Zdjęcie")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Ocena")]
        public double UserRating { get; set; }
        [Required]
        [Display(Name = "Dostępność")]
        public bool isAvailable { get; set; }
        [Required]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

    }
}
