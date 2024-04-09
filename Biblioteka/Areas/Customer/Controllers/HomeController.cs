using Biblioteka.Data;
using Biblioteka.Models;
using Biblioteka.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Biblioteka.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        #region Index

        public IActionResult Index(int? categoryId)
        {
            // Pobierz wszystkie ksi¹¿ki lub ksi¹¿ki z wybranej kategorii
            IQueryable<Book> booksQuery = _db.Books.Include(book => book.Category);

            if (categoryId.HasValue)
            {
                booksQuery = booksQuery.Where(book => book.CategoryId == categoryId);
            }

            var objBookList = booksQuery.ToList();

            var viewModel = new BookViewModel
            {
                Books = objBookList,
                CategoryId = categoryId
            };

            ViewData["CategoryId"] = new SelectList(_db.Categories.OrderByDescending(x => x.Name), "Id", "Name", categoryId);
            return View(viewModel);
        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Preview(int? id, string userId)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book book = _db.Books.Include(b => b.Category).FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userId);
            var reviews = _db.Reviews.Where(r => r.BookId == id).ToList();

            // Utwórz instancjê ViewModel i przeka¿ informacje o ksi¹¿ce, recenzjach i ID u¿ytkownika
            var viewModel = new BookDetailsViewModel
            {
                Book = book,
                Reviews = reviews,
                UserId = userId
            };
            // Pass the information to the view
            ViewData["CurrentUser"] = user;
            ViewData["Book"] = book;

            return View(viewModel);
        }

        
        [HttpPost]
        public IActionResult Borrow(int id, string userId)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Pobierz zalogowanego u¿ytkownika
            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userId);

            // Wypo¿ycz ksi¹¿kê przez u¿ytkownika
            user.BorrowBook(book);

            // Zapisz zmiany w bazie danych
            _db.applicationUsers.Update(user);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Return(int id, string userId)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            // Pobierz zalogowanego u¿ytkownika
            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userId);

            // Wypo¿ycz ksi¹¿kê przez u¿ytkownika
            user.ReturnBook(book);

            // Zapisz zmiany w bazie danych
            _db.applicationUsers.Update(user);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
