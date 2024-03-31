using Biblioteka.Data;
using Biblioteka.Models;
using Biblioteka.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            var existingCategory = _db.Categories.FirstOrDefault(c => c.Name == obj.Name);

            if (existingCategory != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }

            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var booksInCategory = _db.Books.Any(c => c.CategoryId == id);
            if (booksInCategory == false)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return BadRequest("Nie można usunąć kategori do której są przypisane książki.");
            }


        }

        #endregion
    }
}
