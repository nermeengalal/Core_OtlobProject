using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtlobProject.Areas.Identity.Data;
using OtlobProject.Data;
using OtlobProject.Helpers;
using OtlobProject.Models;
using OtlobProject.ModelViews;
using OtlobProject.Services;

namespace OtlobProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DBContext context;
        private readonly IService<MealsInMenu> _MealsService;
        private readonly IService<Area> _AreatService;
        private readonly IService<Restaurant> _RestaurantService;
        private readonly IService<Address> _AddressService;
        private readonly IService<Order> _orderService;
        private readonly IService<Card> _cardService;
        private readonly IService<Area> _areaService;
        private readonly UserManager<ApplicationUser> _userManager;
        public List<MealModelView> Incard;

        public UserController(
            DBContext context,
            IService<MealsInMenu> MealsService,
            IService<Area> AreaService,
            UserManager<ApplicationUser> userManager,
            IService<Restaurant> RestaurantService,
            IService<Address> addService,
            IService<Area> areaService,
            IService<Order> orderService,
             IService<Card> cardService)

        {
            this.context = context;
            this._MealsService = MealsService;
            this._AreatService = AreaService;
            _userManager = userManager;
            _RestaurantService = RestaurantService;
            _AddressService = addService;
            _orderService = orderService;
            _cardService = cardService;
            _areaService = areaService;
        }

        public IActionResult Index()
        {
            List<Area> areas = _areaService.GetAll();
            ViewBag.cities = areas;
            return View();
        }

        public IActionResult ShowRestMenu()
        {
            var res = _RestaurantService.GetAll();
            return View(res);
        }
        public IActionResult SearchByRestaurantArea(string searchString)
        {
            ViewBag.searchString = searchString;
            List<Area> areas = _areaService.GetAll().Where(a => a.CityName.ToLower() == searchString.ToLower()).ToList();
            List<int> aid = new List<int>();
            foreach (var item in areas)
            {
                aid.Add(item.ID);
            }
            var res = new List<Restaurant>();
            foreach (var item in aid)
            {
                foreach (var i in _RestaurantService.GetAll().Where(r => r.AreaID == item))
                {
                    res.Add(i);
                }
            }
                
            return View("ShowRestMenu", res);
        }


        public IActionResult SearchByRestaurantName(string searchString)
        {
            ViewBag.searchString = searchString;
            var res = _RestaurantService.GetAll();
            if (searchString != null)
            {
                res = res.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            else
            {
                res = _RestaurantService.GetAll();
            }
            return View("ShowRestMenu", res);
        }

        public IActionResult ShowMenu(int id)
        {
            var meals = _MealsService.GetAll().Where(m => m.RestID == id);
            return View(meals);
        }

        public IActionResult ShowMealDetails(int id)
        {
            var meal = _MealsService.GetDetails(id);
            return View(meal);
        }

        public IActionResult Details(int id)
        {
            MealsInMenu meal = _MealsService.GetDetails(id);
          
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
        
            if (card == null)
            {
                card = new List<MealModelView>();
                card.Add(new MealModelView
                {
                    ID = meal.ID,
                    Price = meal.Price,
                    Name = meal.Name,
                    Logo = meal.Logo,
                    Description = meal.Description,
                    IsMeal = meal.IsMeal,
                    //Cat =meal.Cat,
                    QuantityNeeded = 1,
                    TotalPrice=meal.Price
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
                
            }
            else
            {
                int index = Exists(card, id);
                if(index == -1)
                {
                   
                    card.Add(new MealModelView
                    {
                        ID = meal.ID,
                        Price = meal.Price,
                        Name = meal.Name,
                        Logo = meal.Logo,
                        Description = meal.Description,
                        IsMeal = meal.IsMeal,
                        //Cat =meal.Cat,
                        QuantityNeeded = 1,
                        TotalPrice = meal.Price
                    });
                }
                else
                {
                    card[index].QuantityNeeded++;
                    card[index].TotalPrice = card[index].QuantityNeeded * card[index].Price;
                }
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
            }
            int iid = meal.RestID;
            return RedirectToAction("ShowMenu",new { id = iid });
        }

        public int Exists(List<MealModelView> card,int id)
        {
            for(var i=0;i<card.Count;i++)
            {
                if(card[i].ID==id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult CardDetails()
        {
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
            return View(card);
        }

        public IActionResult DeleteFromCard(int id)
        {
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
            for (var i = 0; i < card.Count; i++)
            {
                if (card[i].ID == id)
                {
                    card.RemoveAt(i);
                }
            }
            return View("CardDetails", card);
        }

        public IActionResult BeforeConfirmingOrder(Address add)
        {
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
            int mealid = card[0].ID;
            var meal = _MealsService.GetDetails(mealid);
            int restid = meal.RestID;
            var restaurant = _RestaurantService.GetDetails(restid);
            int areaid = restaurant.AreaID;

            if (!ModelState.IsValid)
                return View(add);
            try
            {
                add.AreaID = areaid;
                _AddressService.Add(add);
                SessionHelper.SetObjectAsJson(HttpContext.Session,"AddId",add.ID);
                return RedirectToAction("ConfirmingOrder");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(add);
            }
            
        }

        public IActionResult ConfirmingOrder()
        {
            var totalprice = 0;
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
            int mealid = card[0].ID;
            var meal = _MealsService.GetDetails(mealid);
            int restid = meal.RestID;
            var restuarant = _RestaurantService.GetDetails(restid);

            foreach (var item in card)
            {
                totalprice += item.TotalPrice;
            }

            Order o = new Order();
            o.SubTotalPrice = totalprice;
            o.OrderTime = DateTime.Now.TimeOfDay;
            o.AddressID = SessionHelper.GetObjectAsJson<int>(HttpContext.Session, "AddId");
            o.CustomerID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            o.EstimatedDeliveryTime = restuarant.MaxEstimatedDeliveryTime;
            o.TotalPrice = o.SubTotalPrice + restuarant.DeliveryFee.Value;
            
            _orderService.Add(o);
            return RedirectToAction("SaveInCard");
        }

        public IActionResult SaveInCard()
        {
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Order O = context.orders.OrderByDescending(or => or.ID).FirstOrDefault(or => or.CustomerID == userid);
            var card = SessionHelper.GetObjectAsJson<List<MealModelView>>(HttpContext.Session, "card");
            int mealid = card[0].ID;
            var meal = _MealsService.GetDetails(mealid);
            int restid = meal.RestID;
            var rest = _RestaurantService.GetDetails(restid);
            ViewBag.rest = rest.Name;
            ViewBag.Deliveryfee = rest.DeliveryFee;
            ViewBag.totalprice = O.TotalPrice - ViewBag.Deliveryfee;
            foreach (var item in card)
            {
                Card c = new Card();
                c.MealID = item.ID;
                c.OrderID = O.ID;
                c.Price = item.TotalPrice;
                c.Quantity = item.QuantityNeeded;
                c.RestID = restid;
                _cardService.Add(c);
            }
            CardOrder cd = new CardOrder();
            var cst = context.Users.Where(s => s.Id == O.CustomerID).FirstOrDefault();
            cd.OrderId = O.ID;
            cd.CusName = cst.UserName;
            cd.Totalprice = O.TotalPrice;
            cd.cards = context.Cards.Where(c => c.OrderID == O.ID).ToList();
            cd.MealName = new List<string>();
            foreach (var item in cd.cards)
            {
                var meals = context.Meals.Where(m => m.ID == item.MealID).FirstOrDefault();
                cd.MealName.Add(meals.Name);
            }
            
            return View(cd);

        }



    }
}