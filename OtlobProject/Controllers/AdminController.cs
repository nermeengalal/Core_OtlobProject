using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtlobProject.Areas.Identity.Data;
using OtlobProject.Data;
using OtlobProject.Models;
using OtlobProject.ModelViews;
using OtlobProject.Services;


namespace OtlobProject.Controllers
{
    [Authorize(Roles = "Restaurant Admin")]
    public class AdminController : Controller
    {
        private readonly DBContext context;
        private readonly IService<MealsInMenu> _MealsService;
        private readonly IService<Area> _AreatService;
        private readonly IService<Card> _cardService;
        private readonly IService<Order> _orderService;
        private readonly IService<Restaurant> _restaurantService;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(
            DBContext context,
            IService<MealsInMenu> MealsService,
            IService<Area> AreaService,
            IService<Card> CardService,
            IService<Order> OrderService,
            IService<Restaurant> restService,
            IHostingEnvironment appEnvironment,
            UserManager<ApplicationUser> userManager)
           
        {  
            this.context = context;
            this._MealsService = MealsService;
            this._AreatService = AreaService;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _cardService = CardService;
            _orderService = OrderService;
            _restaurantService = restService;
        }

        public IActionResult Index()
        {
            //var n=HttpContext.User.Identity.Name;
            string UserId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser User = context.Users.Where(u => u.Id == UserId).FirstOrDefault();

            //string UerID= this.User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            var meals=_MealsService.GetAll().Where(m=>m.RestID==User.RestID);
            var restname = (context.Restaurants.Where(r => r.ID == User.RestID).FirstOrDefault()).Name;
            ViewBag.restname = restname;
            return View(meals);
        }

        public IActionResult AddMeal(MealViewModel Model, IFormFile file)
        {
            string UserId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser User = context.Users.Where(u => u.Id == UserId).FirstOrDefault();
           

            MealsInMenu Meal = new MealsInMenu();
            //Meal.Cat = Model.Cat;
            Meal.Description = Model.Description;
            Meal.IsMeal = Model.IsMeal;
            Meal.Name = Model.Name;
            Meal.Price = Model.Price;

            if (!ModelState.IsValid)
                return View(Meal);
            try
            {
                string uniqueFileName = null;
                if (Model.Logo != null)
                {
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Model.Logo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Model.Logo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (User.RestID !=null )
                {
                    Meal.RestID = User.RestID.Value;
                }
                Meal.Logo = uniqueFileName;
                _MealsService.Add(Meal);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(Meal);
            }
           
        }


        public ActionResult UpdateMeal(int id)
        {   
            var s = _MealsService.GetDetails(id);
            return View(s);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult UpdateMeal(int id, MealViewModel Model ,IFormFile file)
        {
            MealsInMenu meal = new MealsInMenu();
            meal.IsMeal = Model.IsMeal;
            meal.Name = Model.Name;
            meal.Price = Model.Price;
            meal.Description = Model.Description;
            
            try
            {
                string uniqueFileName = null;
                if (Model.Logo != null)
                {
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Model.Logo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Model.Logo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                meal.Logo = uniqueFileName;
                _MealsService.Update(id, meal);
                return RedirectToAction("Index");
            }

            catch
            {
                return View(Model);
            }
        }


        public IActionResult DeleteMeal(int id)
        {
            _MealsService.Delete(id);
            return RedirectToAction("Index");
        }

          
        public IActionResult MealDetail(int id)
        {
           var meal= _MealsService.GetDetails(id);
            return View(meal);
        }

       public IActionResult OrderList()
        {
            string UserId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser User = context.Users.Where(u => u.Id == UserId).FirstOrDefault();
            int restid = 0;
            if (User.RestID != null)
            {
                restid = User.RestID.Value;
            }
            List<Card> card = new List<Card>();
            List<Order> o = new List<Order>();
            var ordrs = _orderService.GetAll();
            var cards = _cardService.GetAll();
            var users = new List<ApplicationUser>();
            List<Ordercst> ordcst = new List<Ordercst>();
            foreach (var item in cards.Where(c => c.RestID == restid))
            {
                card.Add(item);
            }
            foreach (var item in card)
            {
                var orderid = item.OrderID;
                foreach (var i in ordrs.Where(o => o.ID == orderid))
                {
                    o.Add(i);
                    
                }
            };
            foreach (var a in o)
            {
                ordcst.Add(new Ordercst { ID = a.ID, CustomerName = (context.Users.Where(u => u.Id == a.CustomerID).FirstOrDefault()).UserName });
            }
            return View(ordcst);
        }

        public IActionResult OrdersOfRest(int id)
        {
            ViewBag.ordid = id;
            List<Card> card = _cardService.GetAll().Where(c=>c.OrderID==id).ToList();
            List<innerorder> inner = new List<innerorder>();
            foreach (var item in card)
            {
                inner.Add(new innerorder { Meal = (context.Meals.Where(c => c.ID == item.MealID).FirstOrDefault()).Name, Quantity = item.Quantity });
            }
            return View(inner);
        }


    }
}