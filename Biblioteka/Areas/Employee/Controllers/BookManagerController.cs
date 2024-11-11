using Biblioteka.Data;
using Biblioteka.Models;
using Biblioteka.Models.VM;
using Biblioteka.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = SD.Role_Employee)]
    public class BookManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookManagerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var currentlyBorrowedBooks = _db.BorrowHistorys
                .Where(u => u.ReturnTime == DateTime.MinValue)
                .Include(u => u.Book)
                .GroupBy(u => u.UserId)
                .Select(g => new BorrowedBookViewModel
                {
                    User = g.FirstOrDefault().UserId,
                    Title = g.FirstOrDefault().Book.Title,
                    DateOfBorrow = g.FirstOrDefault().BorrowTime,
                    CopieNumber = g.FirstOrDefault().Book.CopiesNumber,
                    CopiesAvailable = g.FirstOrDefault().Book.CopiesAvailable
                })
                .OrderByDescending(x => x.User)
                .ToList();

            

            return View(currentlyBorrowedBooks);
        }
    }
}
