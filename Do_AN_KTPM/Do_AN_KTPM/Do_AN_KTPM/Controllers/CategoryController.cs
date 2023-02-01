using Do_AN_KTPM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_AN_KTPM.Controllers
{
    public class CategoryController : Controller
    {
        private FashionShopContext _context;
        private IWebHostEnvironment _environment;


        public CategoryController(FashionShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult categoryInfo()
        {
            var result = _context.ProductTypes.ToList();
            return PartialView("_categoryInfo",result);
        }




    }


}
