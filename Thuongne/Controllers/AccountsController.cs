using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Thuongne.Models;

namespace Thuongne.Controllers
{
    public class AccountsController : Controller
    {
        private readonly Web1Context _dbcontext;
		private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment v;
        public AccountsController(Web1Context context, IHttpContextAccessor contextAccessor, IWebHostEnvironment v)
        {
            _dbcontext = context;
            _contextAccessor = contextAccessor;
            this.v = v;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(String user,String password)
        {
        //var taikhoan = _dbcontext.Accounts.Where(s => s.Phone == user);
		//var matkhau = _dbcontext.Accounts.Where(s => s.Password == password);
            
			//if (user == "admin" && password == "123456")
   //         {
   //             //HttpContext.Session.SetString("user", user);
                
			//	return RedirectToAction("Index", "Home", new {area=""}) ;
   //        }
            
            var checktk = _dbcontext.Accounts.SingleOrDefault(tk => tk.Phone == user && tk.Password == password);
			if (checktk != null)
            {
                if(checktk.RoleId == 1)
                {
					String kiemtra = JsonConvert.SerializeObject(checktk);
					_contextAccessor.HttpContext.Session.SetString("TkList", kiemtra);
					HttpContext.Session.SetString("user", kiemtra);
					//ViewBag.user = user;
					return RedirectToAction("Products", "Admin", new { area = "" });
				}
                else if(checktk.RoleId == 2)
                {
					String kiemtra = JsonConvert.SerializeObject(checktk);
					_contextAccessor.HttpContext.Session.SetString("TkList", kiemtra);
					HttpContext.Session.SetString("user", kiemtra);
					//ViewBag.user = user;
					return RedirectToAction("Index", "Home", new { area = "" });
				}
				
            }
           
				return View();
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Phone,Email,Password,Salt,Active,FullName,Birthday,Avatar,Address,RoleId,LastLogin,CreateDate")] Account accounts, IFormFile img)
		{
            if (ModelState.IsValid)
            {
               
                if (img != null && img.Length > 0)
                {
                    string uploadsFolder = Path.Combine(v.WebRootPath, "img");
                    string uniqueFileName = /*Guid.NewGuid().ToString() + "_" + */img.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await img.CopyToAsync(fileStream);
                    }
                    String Avatar= accounts.Avatar = /*"/img/" +*/ uniqueFileName;
                    _dbcontext.Add(accounts);
                    await _dbcontext.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                
            }
            
            return View();
        }

	}
}
