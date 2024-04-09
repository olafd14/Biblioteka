using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class Review
    {
        public int Id { get; set; }
        /// <summary>
        /// Nagłówek recenzji
        /// </summary>
        [Required]
        [Display(Name = "Nagłówek")]
        public string Title { get; set; }
        /// <summary>
        /// Treść recenzji
        /// </summary>
        [Required]
        [Display(Name = "Treść")]
        public string Content { get; set; }
        /// <summary>
        /// Ocena z recenzji
        /// </summary>
        [Required]
        [Display(Name = "Ocena")]
        public int Rating { get; set; }
        /// <summary>
        /// ID ocenianej książki
        /// </summary>
        public int? BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        /// <summary>
        /// Użytkownik który wystawił recenzje
        /// </summary>
        public string UserId { get; set; }
        [ForeignKey("UserName")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Data wystawienia recenzji
        /// </summary>
        public DateTime Date { get; set; }

    }
}
