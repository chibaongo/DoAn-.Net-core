using Do_AN_KTPM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Do_AN_KTPM.Controllers
{
    public class InvoicesController : Controller
    {
        private FashionShopContext _context;
        public InvoicesController(FashionShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var invoi = _context.Invoices.Include(i => i.Account);
            return View(invoi);
        }
        public IActionResult LatestBillOfTheWeek()
        {
            DateTime weekStart=DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek+1);
            var invoi = _context.Invoices.Where(i => i.IssuedDate >= weekStart)
                                            .OrderByDescending(i => i.IssuedDate)
                                            .ToList();
            return View(invoi);
        }
        public IActionResult Search()
        {
            var invoi = _context.Invoices.Include(i => i.Account);
            return View(invoi);
        }
        [HttpPost]
        public IActionResult Search(string name)
        {
            var invoi = _context.Invoices.Include(i=>i.Account).Where(i=>i.Account.Fullname.Contains(name)).ToList();

            return View(invoi);
        }

    }
}
