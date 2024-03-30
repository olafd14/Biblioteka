﻿using Biblioteka.Data;
using Biblioteka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Book> objBookList = _db.Books.Include(book => book.Category).ToList();
            return View(objBookList);
        }

        #region Create

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories.OrderByDescending(x => x.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book obj, IFormFile? file)
        {

            var existingBook = _db.Categories.FirstOrDefault(c => c.Name == obj.Title);

            if (existingBook != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }

            if (obj.Title == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                string wwwRotPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                { 
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRotPath, @"images");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\" + fileName;
                }

                _db.Books.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        #endregion

        #region Edit

        public IActionResult Edit(int? id)
        {
            ViewData["CategoryId"] = new SelectList(_db.Categories.OrderByDescending(x => x.Name), "Id", "Name");
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book book = _db.Books.FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book obj, IFormFile? file)
        {

            var existingBook = _db.Categories.FirstOrDefault(c => c.Name == obj.Title);

            if (existingBook != null)
            {
                ModelState.AddModelError("Name", "A category with the same name already exists.");
            }

            if (obj.Title == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                string wwwRotPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRotPath, @"images");

                    if(!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath =
                            Path.Combine(wwwRotPath, obj.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\" + fileName;
                }

                _db.Books.Update(obj);
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

            Book book = _db.Books.FirstOrDefault(c => c.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            
            if (!string.IsNullOrEmpty(book.ImageUrl))
            {
                var oldImagePath =
                          Path.Combine(_webHostEnvironment.WebRootPath, book.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
          

            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}
