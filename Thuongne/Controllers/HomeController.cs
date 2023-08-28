using System.Diagnostics;
using System.Drawing.Design;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Thuongne.Models;

namespace Thuongne.Controllers
{
	public class HomeController : Controller
	{
        private readonly Web1Context _dbContext;
        private readonly ILogger<HomeController> _logger;
		private readonly IHttpContextAccessor _contextAccessor;
		public HomeController(ILogger<HomeController> logger, Web1Context web1Context, IHttpContextAccessor contextAccessor)
		{
			_logger = logger;
			_dbContext = web1Context;
			_contextAccessor = contextAccessor;
		}
		

		public IActionResult Index()
		{

			var db = _dbContext.Products.Include(t => t.Thumbnails).ToList();
            return View(db);
		}

		public IActionResult Detail_Products(int id)
		{
			var detail = _dbContext.Products.Include(t => t.Thumbnails).Where(t => t.Id == id).FirstOrDefault();
            return View(detail);
		}

		//[HttpGet]
  //      public IActionResult Cart_products()
		//{
		//	return View();
		//}

		
        public IActionResult Cart_products(int id,String thumb,String name, Double price, int quantity)
		{
			int Id = id;
			String Thumb = thumb;
			String Name = name;
			Double Price = price;
			int Quantity = quantity;
			//create
			List<Giohang> carts = new List<Giohang>();
			
			//giohang gh = new giohang();
			//if (id == gh.Id )
			//{
   //             CommonModel item = new CommonModel();
   //             item.Carts = carts;


   //             //var carts = _dbContext.Products.Include(t => t.Thumbnails).Where(t => t.Id == id).FirstOrDefault();
   //             return View(item);
   //         }
			//else
			//{
                carts.Add(new Giohang { Id = Id, thumb = Thumb, name = Name, price = Price, quantity = Quantity });

                //save
                String cartsString = JsonConvert.SerializeObject(carts);
                _contextAccessor.HttpContext.Session.SetString("CategoriesList", cartsString);

                // check
                String categoriesString = _contextAccessor.HttpContext.Session.GetString("CategoriesList");
                carts = JsonConvert.DeserializeObject<List<Giohang>>(categoriesString);

                CommonModel model = new CommonModel();
                model.Carts = carts;


                //var carts = _dbContext.Products.Include(t => t.Thumbnails).Where(t => t.Id == id).FirstOrDefault();
                return View(model);


               
            //}
            //return View();
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
	}
}