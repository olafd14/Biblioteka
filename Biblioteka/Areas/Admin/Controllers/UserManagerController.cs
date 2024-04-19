using Biblioteka.Data;
using Biblioteka.Models;
using Biblioteka.Models.VM;
using Biblioteka.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public UserManagerController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> objUserList = _db.applicationUsers.Include(user => user.Book).ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList)
            {

                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

            }

            return View(objUserList);
        }

        #region Edit

        public IActionResult Edit(string id)
        {
            var user = _db.UserRoles.FirstOrDefault(u => u.UserId == id);
            if (user is null)
                throw new Exception();

            var roleId = user.RoleId;  

            RoleManagmentViewModel roleVM = new RoleManagmentViewModel()
            {
                ApplicationUser = _db.applicationUsers.FirstOrDefault(u => u.Id == id),
                RoleList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),

            };

            roleVM.ApplicationUser.Role = _db.Roles.FirstOrDefault(u => u.Id == roleId).Name;

            return View(roleVM);
        }

        [HttpPost]
        public IActionResult Edit(RoleManagmentViewModel roleManagmentViewModel)
        {
            if (roleManagmentViewModel is null)
                return RedirectToAction("Index");

            string RoleID = _db.UserRoles.FirstOrDefault(u => u.UserId == roleManagmentViewModel.ApplicationUser.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == RoleID).Name;

            if (!(roleManagmentViewModel.ApplicationUser.Role == oldRole))
            {
                var applicationUser = _db.applicationUsers.FirstOrDefault(u => u.Id == roleManagmentViewModel.ApplicationUser.Id);
                if(applicationUser is null)
                {
                    return RedirectToAction("Index");
                }
                _db.SaveChanges();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagmentViewModel.ApplicationUser.Role).GetAwaiter().GetResult();
            }


            return RedirectToAction("Index");
        }

        #endregion

        [HttpPost]
        public IActionResult LockUnlock(string id)
        {
            var objFromDb = _db.applicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return RedirectToAction("Index");
            }

            if(objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;                
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
