using Do_AN_KTPM.Data;
using Do_AN_KTPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_AN_KTPM.Controllers
{
    public class ProductsController : Controller
    {
        private FashionShopContext _context;
        private IWebHostEnvironment _environment;



        public ProductsController(FashionShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int? priceorderby, int? productType)
        {
            var product = _context.Products.Include(p => p.ProductType).Where(a => a.Status == true);
            int priceResultBefore = 0;
            int priceResultAfter = 0;
            ViewBag.CheckedRadio = 0;
            if (productType.HasValue)
            {
                product = product.Where(x => x.ProductTypeId == productType.Value);
            }


            if (priceorderby.GetValueOrDefault(0) > 0)
            {
                ViewBag.CheckedRadio = priceorderby.Value;


                if (priceorderby == 1)
                {

                    priceResultBefore = 0;
                    priceResultAfter = 100000;
                }
                else if (priceorderby == 2)
                {

                    priceResultBefore = 100000;
                    priceResultAfter = 300000;
                }
                else if (priceorderby == 3)
                {

                    priceResultBefore = 300000;
                    priceResultAfter = 500000;
                }
                else if (priceorderby == 4)
                {

                    priceResultBefore = 500000;
                    priceResultAfter = 3000000;
                }
                product = product.Where(x => x.Price > priceResultBefore && x.Price < priceResultAfter);
            }
            return View(product);
            //var fashionShopContext = _context.Products.Include(p => p.ProductType);
            //return View(await fashionShopContext.ToListAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            //var fashionShopContext = _context.Products.Include(p => p.ProductType);
            if (id == null)
                return RedirectToAction("Index");
            var pr = _context.Products.FirstOrDefault(a => a.Id == id);
            if (pr == null)
            {
                return NotFound();

            }

            return View(pr);

        }
        //
        public IActionResult Search()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Search(string name, int minPrice = 0, int maxPrice = int.MaxValue)
        {
            var products = _context.Products.Where(a => a.Name.Contains(name)).Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            return View(products);
        }



    }
}
