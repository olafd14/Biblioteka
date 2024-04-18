using Biblioteka.Data;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserAccountController : Controller
    {        
        private readonly ApplicationDbContext _db;

        public UserAccountController(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
