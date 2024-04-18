using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class BorrowHistory
    {
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserName")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }

    }
}
