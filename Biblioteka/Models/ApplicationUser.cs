using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Wypożyczona Książka")]
        public int? BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        [Display(Name = "Czy ma książkę wypożyczoną")]
        public bool HasBorrowedBook { get; set; }
        [NotMapped]
        public string Role { get; set; }

        public void BorrowBook(Book book)
        {
            if (!HasBorrowedBook)
            {
                BookId = book.Id;
                HasBorrowedBook = true;
                book.isAvailable = false;
            }
            // Możesz dodać tutaj obsługę przypadku, gdy użytkownik już ma wypożyczoną książkę
            else
            {
                // Obsługa błędu, użytkownik ma już wypożyczoną książkę
                throw new InvalidOperationException("Użytkownik już ma wypożyczoną książkę.");
            }
        }

        // Metoda, która pozwoli użytkownikowi zwrócić książkę
        public void ReturnBook(Book book)
        {
            BookId = null;
            HasBorrowedBook = false;
            book.isAvailable = true;
        }
    }
}
