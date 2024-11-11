using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Id książka którą aktualnie użytkownik wypożycza, jeśli nie ma żadnej to ma wartość null (połączone z tabelą książek za pomocą ID)
        /// </summary>
        [Display(Name = "Wypożyczona Książka")]
        public int? BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        /// <summary>
        /// Sprawdzenie czy użytkownik ma wypożyczoną książkę
        /// </summary>
        [Display(Name = "Czy ma książkę wypożyczoną")]
        public bool HasBorrowedBook { get; set; }
        /// <summary>
        /// Rola użytkownika nie przekazywana do bazy danych, zaczytana z tabeli usersRoles
        /// </summary>
        [NotMapped]
        public string Role { get; set; }

        /// <summary>
        /// Metoda wypożyczająca książkę jeśli użytkownik aktalnie nie posiada wypożyczonej książki
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void BorrowBook(Book book)
        {
            if (!HasBorrowedBook)
            {
                BookId = book.Id;
                HasBorrowedBook = true;
                book.CopiesAvailable--;
                if (book.CopiesAvailable == 0)
                {
                    book.isAvailable = false;
                }
            }
            else
            {
                throw new InvalidOperationException("Użytkownik już ma wypożyczoną książkę.");
            }
        }

        /// <summary>
        /// Metoda zwracająca książkę którą ma użytkownik
        /// </summary>
        /// <param name="book"></param>
        public void ReturnBook(Book book)
        {
            BookId = null;
            HasBorrowedBook = false;
            book.CopiesAvailable++;
            book.isAvailable = true;
        }
    }
}
