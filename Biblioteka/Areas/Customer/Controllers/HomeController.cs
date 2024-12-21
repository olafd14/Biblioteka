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
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
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

            //var userIdTest = _userManager.GetUserId(User);

            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userId);
            var reviews = _db.Reviews.Where(r => r.BookId == id).ToList();
            
            var viewModel = new BookDetailsViewModel
            {
                Book = book,
                Reviews = reviews,
                UserId = userId
            };
            
            ViewData["CurrentUser"] = user;
            ViewData["Book"] = book;

            return View(viewModel);
        }

        #region BorrowReturnBook

        [HttpPost]
        public IActionResult BorrowBook(int id, string userId)
         {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }


            var userIdTest = _userManager.GetUserName(User);

            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userIdTest);

            var borrowHistory = new BorrowHistory
            {
                BookId = book.Id,
                UserId = userIdTest,
                BorrowTime = DateTime.Now
            };

            
            user.BorrowBook(book);

            _db.BorrowHistorys.Add(borrowHistory);
            _db.applicationUsers.Update(user);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ReturnBook(int id, string userId)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            var borrowHistory = _db.BorrowHistorys.FirstOrDefault(b => b.BookId == id && b.ReturnTime == DateTime.MinValue);
            borrowHistory.ReturnTime = DateTime.Now;

            var userIdTest = _userManager.GetUserName(User);

            var user = _db.applicationUsers.FirstOrDefault(c => c.UserName == userIdTest);

            
            user.ReturnBook(book);

            _db.BorrowHistorys.Update(borrowHistory);
            _db.applicationUsers.Update(user);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Create

        public IActionResult CreateReview(string userId, int bookId)
        {
            ViewData["UserId"] = userId;
            ViewData["BookId"] = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(Review obj)
        {
            obj.Date = DateTime.Now;

            var existingReview = _db.Reviews.FirstOrDefault(c => c.Id == obj.Id);
            

            if (obj.Title == obj.Content.ToString())
            {
                ModelState.AddModelError("name", "Opis i tytu³ nie mog¹ byæ takie same.");
            }
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(obj);
                _db.SaveChanges();
                var bookToUpdate = _db.Books.Find(obj.BookId);
                bookToUpdate.CalculateOverallRating(obj.Rating);
                _db.SaveChanges();
                return RedirectToAction("Preview", new { id = obj.BookId });
            }
            return View();
        }
        #endregion
    }
}
