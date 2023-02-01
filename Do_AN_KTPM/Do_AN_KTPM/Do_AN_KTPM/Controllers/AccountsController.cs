using Do_AN_KTPM.Data;
using Do_AN_KTPM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Diagnostics.Metrics;

namespace Do_AN_KTPM.Controllers
{
    public class AccountsController : Controller
    {
        private FashionShopContext _context;
        private IWebHostEnvironment _environment;
        public AccountsController(FashionShopContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var accounts=_context.Accounts.Where(a=>a.Status==true);
            if (TempData["result"]!=null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            if (TempData["MsgADmin"]!=null)
            {
                ViewBag.MsgADmin = TempData["MsgADmin"];
            }
            return View(accounts);
        }
        public IActionResult Create()
        {
            if (TempData["CreateFail"] != null)
            {
                ViewBag.CreateFail = TempData["CreateFail"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Username,Password,Email,Phone,Adress,Fullname,Avatar,AvatarFile,Status,IsAdmin")]Account account)
        {
            var acc = _context.Accounts.ToList();
            if(ModelState.IsValid)
            {
                for(int i=0;i<acc.Count();i++)
                {
                    if( acc[i].Username==account.Username)
                    {
                        TempData["CreateFail"] = "Account already exists";
                        return RedirectToAction("Create");
                    }
                    if (acc[i].Phone == account.Phone)
                    {
                        TempData["CreateFail"] = "This phone number is already registered";
                        return RedirectToAction("Create");
                    }
                    if (acc[i].Email == account.Email)
                    {
                        TempData["CreateFail"] = "This email is already registered";
                        return RedirectToAction("Create");
                    }
                }    
                _context.Add(account);
                _context.SaveChanges();
                if(account.AvatarFile!=null)
                {
                    var fileName = account.Id.ToString() + Path.GetExtension(account.AvatarFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                    var uploadPath=Path.Combine(uploadFolder, fileName);
                    using (FileStream fs=System.IO.File.Create(uploadPath))
                    {
                        account.AvatarFile.CopyTo(fs);
                        fs.Flush();
                    }
                    account.Avatar = fileName;
                    _context.Accounts.Update(account);
                    _context.SaveChanges();
                }
                TempData["result"] = "Have an account just created!";
                return RedirectToAction(nameof(Index));
            }
            return View(account);
          
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var accounts=_context.Accounts.FirstOrDefault(a=>a.Id == id);
            if(accounts == null)
            {
                return NotFound();

            }
            if(accounts.Status==false)
            {
                return NotFound();

            }
            if(TempData["resultUser"]!=null)
            {
                ViewBag.UserEdit = TempData["resultUser"];
            }    
            return View(accounts);
        }
        public IActionResult Delete(int? id)
        {
            
            if (id == null)
                return RedirectToAction("Index");
            
            var account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            
            if (account == null)
            {
                return NotFound();
            }
            if(account.IsAdmin == true || account.Id==1)
            {
                
                TempData["MsgADmin"]= "Can't delete admin account!";
                return RedirectToAction("Index", "Accounts");
            }
            account.Status = false;

            //_context.Accounts.Remove(account);
            _context.SaveChanges();
            TempData["result"] = "Account deleted successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (TempData["EditAdmin1"]!=null)
            {
                ViewBag.EditAdminID1 = TempData["EditAdmin1"];
            }    
            if (id == null)
                return RedirectToAction("Index");
            var account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]
        public IActionResult Edit(int? id, [Bind("Id,Username,Password,Email,Phone,Adress,Fullname,Avatar,AvatarFile,Status,IsAdmin")] Account account)
        {
           
            if(ModelState.IsValid)
            {
              if(account.Id==1)
                {
                    TempData["EditAdmin1"] = "This admin cannot be edited";
                    return RedirectToAction("Edit", "Accounts");
                }    
                //if(account.Password==null)
                //{
                //    account.Password = _context.Accounts.FirstOrDefault(x => x.Id == id).Password;
                //}    
                _context.Accounts.Update(account);
                _context.SaveChanges();
                if(account.AvatarFile!=null)
                {

                    var fileName = account.Id.ToString() + Path.GetExtension(account.AvatarFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        account.AvatarFile.CopyTo(fs);
                        fs.Flush();
                    }
                    account.Avatar = fileName;
                    _context.Accounts.Update(account);
                    _context.SaveChanges();
                }
                TempData["result"] = "Account update successful!";
                return RedirectToAction(nameof(Index));
            }    
            return View(account);

        }
        //Login
        public IActionResult Login()
        {
            if (TempData["CreateSuccess"] != null)
            {
                ViewBag.CreateSuccess = TempData["CreateSuccess"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account account)
        {
          
            var obj=_context.Accounts.Where(a=>a.Status ==true && a.Username==account.Username && a.Password == account.Password).FirstOrDefault();
            
            if(obj!=null)
            {
               
                    if (obj.IsAdmin == true)
                    {
                        var isAdmin = obj.IsAdmin;
                        HttpContext.Session.SetString("IsAdmin", isAdmin.ToString());
                        HttpContext.Session.SetString("Name", obj.Fullname);
                        HttpContext.Session.SetString("UserName", obj.Username);
                        HttpContext.Session.SetInt32("Id", obj.Id);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        
                        HttpContext.Session.SetString("Name", obj.Fullname);
                        HttpContext.Session.SetString("UserName", obj.Username);
                        HttpContext.Session.SetInt32("Id", obj.Id);
                        return RedirectToAction("Index", "Home");
                    }
              

            }
            else
            {
                ViewBag.Error = "Incorrect account or password!";
                return View("Login");
            } 
            
        }
        public IActionResult Logout()
        {
            
            if (HttpContext.Session.GetString("Name") != null)
            {
                HttpContext.Session.Remove("UserName");
                HttpContext.Session.Remove("IsAdmin");
                HttpContext.Session.Remove("Name");
                HttpContext.Session.Remove("Id");
               
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignUp()
        {
            if (TempData["SignUpFail"] != null)
            {
                ViewBag.MSignUpFail = TempData["SignUpFail"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult SignUp([Bind("Username,Password,Email,Phone,Adress,Fullname,Avatar,AvatarFile,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                var acc = _context.Accounts.ToList();
                for (int i = 0; i < acc.Count(); i++)
                {
                    if (acc[i].Username == account.Username)
                    {
                        TempData["SignUpFail"] = "Account already exists";
                        return RedirectToAction("SignUp");
                    }
                    if (acc[i].Phone==account.Phone)
                    {
                        TempData["SignUpFail"] = "This phone number is already registered";
                        return RedirectToAction("SignUp");
                    }
                    if (acc[i].Email == account.Email)
                    {
                        TempData["SignUpFail"] = "This email is already registered";
                        return RedirectToAction("SignUp");
                    }
                }
                _context.Add(account);
                _context.SaveChanges();
                if (account.AvatarFile != null)
                {
                    var fileName = account.Id.ToString() + Path.GetExtension(account.AvatarFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        account.AvatarFile.CopyTo(fs);
                        fs.Flush();
                    }
                    account.Avatar = fileName;
                    _context.Accounts.Update(account);
                    _context.SaveChanges();
                }
                TempData["result"] = "Have an account just created!";
                TempData["CreateSuccess"] = "Create Account Success! Please login with your newly created account!";
                return RedirectToAction("Login", "Accounts");
            }
            return View(account);

        }
        public IActionResult Search()
        {
            var accounts = _context.Accounts.Where(a => a.Status == true);
            return View(accounts);
        }
        [HttpPost]
        public IActionResult Search(string name)
        {
            var acc = _context.Accounts.Where(a => a.Username.Contains(name)).Where(a => a.Status == true).ToList();
            
            return View(acc);
        }

        public IActionResult FilterUser()
        {
            var acc = _context.Accounts.Where(a => a.IsAdmin==false).Where(a => a.Status == true).ToList();
            return View(acc);
        }
        public IActionResult FilterAdmin()
        {
            var acc = _context.Accounts.Where(a => a.IsAdmin == true).Where(a => a.Status == true).ToList();
            return View(acc);
        }
        public IActionResult EditUser(int? id)
        {
            if (id == null)
                return RedirectToAction("Details");
            var account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]
        public IActionResult EditUser([Bind("Id,Username,Password,Email,Phone,Adress,Fullname,Avatar,AvatarFile,Status")] Account account)
        {
     
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                if (account.AvatarFile != null)
                {

                    var fileName = account.Id.ToString() + Path.GetExtension(account.AvatarFile.FileName);
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "img", "avatar");
                    var uploadPath = Path.Combine(uploadFolder, fileName);
                    using (FileStream fs = System.IO.File.Create(uploadPath))
                    {
                        account.AvatarFile.CopyTo(fs);
                        fs.Flush();
                    }
                    account.Avatar = fileName;
                    _context.Accounts.Update(account);
                    _context.SaveChanges();
                }
                TempData["resultUser"] = "Account update successful!";
                return RedirectToAction("Details", "Accounts", new {Id=account.Id} );
            }
            return View("Details");

        }
        public IActionResult FilterUserFalse()
        {
            var acc = _context.Accounts.Where(a => a.Status == false);
            return View(acc);
        }
        public IActionResult Unlock(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var account = _context.Accounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }
            
            account.Status = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
