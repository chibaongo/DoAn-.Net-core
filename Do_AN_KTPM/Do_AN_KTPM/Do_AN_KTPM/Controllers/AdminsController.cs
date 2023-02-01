using Do_AN_KTPM.Data;
using Microsoft.AspNetCore.Mvc;

namespace Do_AN_KTPM.Controllers
{
    public class AdminsController : Controller
    {
        private FashionShopContext _context;
        public AdminsController(FashionShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
