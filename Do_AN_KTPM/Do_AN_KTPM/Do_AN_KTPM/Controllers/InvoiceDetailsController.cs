using Do_AN_KTPM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_AN_KTPM.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private FashionShopContext _context;
        public InvoiceDetailsController(FashionShopContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)

        {
            if(id==null)
            {
                RedirectToAction("Index", "Invoices");
            }
            var invoiceDetails = _context.InvoiceDetails.Include(i => i.Product).Where(i => i.Id == id);
            return View(invoiceDetails);
        }
    }
}
