using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReviewController : Controller
    {        
        private readonly ApplicationDbContext _db;

        public ReviewController(ApplicationDbContext db)
        {
            _db = db;           
        }


        public IActionResult Create(string userId, int bookId)
        {          
            ViewData["UserId"] = userId;
            ViewData["BookId"] = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review obj)
        {
            obj.Date = DateTime.Now;

            var existingReview= _db.Reviews.FirstOrDefault(c => c.Id == obj.Id);

            if (existingReview != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }

            if (obj.Title == obj.Content.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {                
                _db.Reviews.Add(obj);
                _db.SaveChanges(); 
                var bookToUpdate = _db.Books.Find(obj.BookId);
                bookToUpdate.CalculateOverallRating(obj.Rating);
                _db.SaveChanges();
                return RedirectToAction("Preview", "Home", new { area = "Customer" });
            }
            return View();
        }
    }
}
