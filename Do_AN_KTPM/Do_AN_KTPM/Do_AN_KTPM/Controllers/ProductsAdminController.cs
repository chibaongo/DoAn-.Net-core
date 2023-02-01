using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do_AN_KTPM.Data;
using Do_AN_KTPM.Models;
using Microsoft.Extensions.Hosting;
using System.Security.Principal;

namespace Do_AN_KTPM.Controllers
{
    public class ProductsAdminController : Controller
    {
        private FashionShopContext _context;
        private IWebHostEnvironment _environment;


        public ProductsAdminController(FashionShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: ProductsAdmin
        public async Task<IActionResult> Index()
        {
            var product = _context.Products.Include(p => p.ProductType).Where(a => a.Status == true);
            return View(product);
            // var fashionShopContext = _context.Products.Include(p => p.ProductType);
            // return View(await fashionShopContext.ToListAsync());
        }

        // GET: ProductsAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsAdmin/Create
        public IActionResult Create()
        {

            if (TempData["CreateFail"] != null)
            {
                ViewBag.CreateFail = TempData["CreateFail"];
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name");
            return View();
        }

        // POST: ProductsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SKU,Name,Description,Price,Stock,ProductTypeId,Image,ImageFile,Status")] Product product)
        {

            var pro = _context.Products.ToList();
            if (ModelState.IsValid)
            {
                for (int i = 0; i < pro.Count(); i++)
                {
                    if (pro[i].SKU == product.SKU)
                    {
                        TempData["CreateFail"] = "Product already exists";
                        return RedirectToAction("Create");
                    }
                    if(pro[i].Name == product.Name)
                    {
                        TempData["CreateFail"] = "Product already exists";
                        return RedirectToAction("Create");
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                if (product.ImageFile != null)
                {
                    var fileName = product.Id.ToString() + Path.GetExtension(product.ImageFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "product");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        product.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    product.Image = fileName;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: ProductsAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", product.ProductTypeId);
            return View(product);
        }

        // POST: ProductsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SKU,Name,Description,Price,Stock,ProductTypeId,Image,ImageFile,Status")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                _context.Update(product);
                _context.SaveChanges();
                //}
                // catch (DbUpdateConcurrencyException)
                //{
                if (product.ImageFile != null)
                {
                    var fileName = product.Id.ToString() + Path.GetExtension(product.ImageFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "product");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        product.ImageFile.CopyTo(fs);
                        fs.Flush();
                    }
                    product.Image = fileName;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
            //  }

            // ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", product.ProductTypeId);
            return View(product);
        }

        // GET: ProductsAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
                return RedirectToAction("Index");
            var pro = _context.Products.FirstOrDefault(x => x.Id == id);

            if (pro == null)
            {
                return NotFound();
            }
            pro.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'FashionShopContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        //search
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


        ///
        public IActionResult FilterProductFalse()
        {
            var pro = _context.Products.Where(a => a.Status == false);
            return View(pro);
        }
        public IActionResult Unlock(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var pro = _context.Products.FirstOrDefault(x => x.Id == id);

            if (pro == null)
            {
                return NotFound();
            }

            pro.Status = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
