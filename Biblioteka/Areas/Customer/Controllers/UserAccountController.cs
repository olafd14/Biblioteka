using Biblioteka.Data;
using Biblioteka.Models;
using Biblioteka.Models.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserAccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public UserAccountController(ApplicationDbContext db, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            var userIdTest = _userManager.GetUserName(User);

            IQueryable<Book> booksQuery = _db.Books.Include(book => book.Category);           

            var objBookList = booksQuery.ToList();

            var borrowHistory = _db.BorrowHistorys.Where(r => r.UserId == userIdTest).ToList();

            var viewModel = new UserBorrowHistoryVM
            {
                BorrowHistories = borrowHistory,
                Books = objBookList
            };
            return View(viewModel);
        }
    }
}
