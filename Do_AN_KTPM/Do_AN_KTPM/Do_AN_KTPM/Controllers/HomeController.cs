using Do_AN_KTPM.Data;
using Do_AN_KTPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Do_AN_KTPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _environment;
        private FashionShopContext _context;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment, FashionShopContext context)
        {
            _logger = logger;
            _environment = environment;
            _context = context;
        }

        public async Task<IActionResult> Index(int? priceorderby)
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            if (ViewBag.Username == null)
            {
                ViewBag.Username = "My account";
            }
            var product = _context.Products.Include(p => p.ProductType).Where(a => a.Status == true);
            if (priceorderby.HasValue)
            {
                //product = product.Where()
            }
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string name)
        {
            var products = _context.Products.Where(a => a.Name.Contains(name)).ToList();
            return View(products);
        }
        [HttpPost]
        public IActionResult productByPrice(int priceorderby)
        {
            if (priceorderby == null)
            {
                var products1 = _context.Products.ToList();
                return View(products1);
            }
            int priceResultBefore = 0;
            int priceResultAfter = 0;
            if (priceorderby == 0)
            {
                priceResultBefore = int.MinValue;
                priceResultAfter = int.MaxValue;
            }
            else if (priceorderby == 1)
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


            var products = _context.Products.Where(p => p.Price > priceResultBefore && p.Price < priceResultAfter).ToList();
            return View("Index", products);
        }

    }
}