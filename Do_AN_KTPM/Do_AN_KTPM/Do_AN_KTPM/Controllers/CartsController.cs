using Do_AN_KTPM.Data;
using Do_AN_KTPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Do_AN_KTPM.Controllers
{
    public class CartsController : Controller
    {
        private FashionShopContext _context;
        public CartsController(FashionShopContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? name)
        {
            if (name == null)
                return RedirectToAction("Index", "Home");

            var fashionShopContext = _context.Carts.Include(c => c.Account)
                                                   .Include(c => c.Product)
                                                   .Where(c => c.Account.Username == name);
            return View(fashionShopContext);

        }
        [HttpPost]
        public IActionResult AddCart(string ?name, int Quantity, int productId)
        {
            if (name == null)
                return RedirectToAction("Index", "Home");
            var fashionShopContext = _context.Carts.Include(c => c.Account)
                                                   .Include(c => c.Product)
                                                   .Where(c => c.Account.Username == name);
            var accountId = _context.Accounts.FirstOrDefault(a => a.Username == name).Id;
            var cart = _context.Carts.Where(c => c.AccountId == accountId && c.ProductId == productId).FirstOrDefault();
            if (cart != null)
            {
                cart.Quantity += Quantity;
                _context.Carts.Update(cart);
                _context.SaveChanges();
            }
            else
            {
                cart = new Cart
                {
                    AccountId = accountId,
                    ProductId = productId,
                    Quantity = Quantity,
                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Carts");
        }
        public IActionResult UpDate()
        {
            return View();
        }
        [HttpPost]
       
       
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
                return RedirectToAction("Index");
            var cart = _context.Carts.FirstOrDefault(x => x.Id == Id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteAll(string? name)
        {
            
            if (name == null)
                return RedirectToAction("Index", "Home");

            var carts = _context.Carts.Include(c => c.Account)
                                      .Include(c => c.Product)
                                      .Where(c => c.Account.Username == name)
                                      .ToList();
            foreach (var item in carts)
            {
                _context.Carts.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //hóa đơn

        public IActionResult Purchase()
        {
            //var cart = _context.Carts.Include(c => c.Account).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Purchase(string ShippingAddress, string ShippingPhone, string? name)
        {
            if (name == null)
                return RedirectToAction("Index", "Home");

            var carts = _context.Carts.Include(c => c.Account)
                                      .Include(c => c.Product)
                                      .Where(c => c.Account.Username == name)
                                      .ToList();
            var accountId = _context.Accounts.FirstOrDefault(a => a.Username == name).Id;
            var total = carts.Sum(c => c.Quantity * c.Product.Price);
            var invoice = new Invoice
            {
                Code = DateTime.Now.ToString("yyyyMMddhhmmss"),
                AccountId = accountId,
                IssuedDate = DateTime.Now,
                ShippingAddress = ShippingAddress,
                ShippingPhone = ShippingPhone,
                Total = total,
                Status = true,
            };
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            //chi tiết hóa đơn
            foreach (var item in carts)
            {
                InvoiceDetail detail = new InvoiceDetail
                {
                    InvoiceId = invoice.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price
                };
                _context.InvoiceDetails.Add(detail);
                _context.Carts.Remove(item);

                item.Product.Stock -= item.Quantity;
                _context.Products.Update(item.Product);
            };
            _context.SaveChanges();

            return RedirectToAction("Index", "Carts");
        }
        
    }
}
