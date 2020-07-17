using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OtlobProject.Areas.Identity.Data;
using OtlobProject.Data;
using OtlobProject.ModelViews;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtlobProject.Services;
using OtlobProject.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace OtlobProject.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DBContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ManagerRegistration> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IService<Restaurant> _RestaurantService;
        private readonly IService<Area> _AreatService;
        private readonly IService<Address> _AddressService;
        private readonly IHostingEnvironment _appEnvironment;

        public ManagerController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, DBContext context,
            ILogger<ManagerRegistration> logger,
            IEmailSender emailSender,
            IService<Restaurant> RestaurantService,
            IService<Area> AreaService,
            IService<Address> AddressService,
            IHostingEnvironment appEnvironment)
           
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.context = context;
            _logger = logger;
            _emailSender = emailSender;
            this._RestaurantService = RestaurantService;
            this._AreatService = AreaService;
            _appEnvironment = appEnvironment;
            _AddressService = AddressService;
        }

    
      
        public IActionResult Index()
        {
            var res = _RestaurantService.GetAll();
            List<AllRestaurantModelView> restaurants = new List<AllRestaurantModelView>();
            foreach (var item in res)
            {
                Area area = _AreatService.GetDetails(item.AreaID);
                string a = area.CityName + " / " + area.SubArea;
                restaurants.Add(new AllRestaurantModelView { ID = item.ID, Logo = item.Logo, Name = item.Name, Area = a });
            }
           
            
            return View(restaurants);
        }
        public ActionResult Registration()
        {
             ViewBag.Rolesres = context.Roles.Where(r => r.Name == "Restaurant Admin").ToList();
            //Applicatiouser "Adress
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration(ManagerRegistration userRegister ,Restaurant rest)
        {

            IdentityRole role = new IdentityRole();
            ViewBag.Rolesres = context.Roles.Where(r => r.Name == "Restaurant Admin").ToList();
            if (!CheckForUser(userRegister))
            {
                ModelState.AddModelError("", "This  UserName is already Exists ,Please Choose another one");
                return View(userRegister);
            }
            if (!ModelState.IsValid)
            {
                return View(userRegister);
            }
            try
            {
                //Creat UserManager
                ApplicationUser user = new ApplicationUser();
                user.UserName = userRegister.Username;
                user.PasswordHash = userRegister.Password;
                user.Email = userRegister.Email;
                user.AreaID = rest.AreaID;
                user.RestID = rest.ID;

                //UserManager save user database
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                // IdentityResult resulte = await manager.CreateAsync(user, userRegister.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userRegister.Role);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
  
                        return RedirectToAction("Index");     
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(userRegister);
                    }
                    return RedirectToAction("Index");
                }
              
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userRegister);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NewRegistration()
        {
            ViewBag.Roles = context.Roles.Where(r => r.Name != "User" && r.Name != "Restaurant Admin").ToList();
            //Applicatiouser "Adress
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NewRegistration(ManagerRegistration userRegister)
        {

            IdentityRole role = new IdentityRole();
            ViewBag.Roles = context.Roles.Where(r => r.Name != "User" && r.Name != "Restaurant Admin").ToList();
            if (!CheckForUser(userRegister))
            {
                ModelState.AddModelError("", "This  UserName is already Exists ,Please Choose another one");
                return View(userRegister);
            }
            if (!ModelState.IsValid)
            {
                return View(userRegister);
            }
            try
            {
                //Creat UserManager
                ApplicationUser user = new ApplicationUser();
                user.UserName = userRegister.Username;
                user.PasswordHash = userRegister.Password;
                user.Email = userRegister.Email;
               

                //UserManager save user database
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                // IdentityResult resulte = await manager.CreateAsync(user, userRegister.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userRegister.Role);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        return RedirectToAction("Index");
                      
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return View(userRegister);
                    }
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(userRegister);
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<ActionResult> AddRestaurant(RestaurantModelView restaurant,IFormFile file) 
        {
          var stands = context.Areas
            .Select(s => new
            {
                ID = s.ID,
                areas = string.Format("{0} / {1}", s.CityName, s.SubArea)
            })
            .ToList();

            ViewBag.StandID = stands; 
            
            if (!ModelState.IsValid)
                return View(restaurant);
            Restaurant res = new Restaurant();
            res.ID = res.ID;
            res.MaxEstimatedDeliveryTime = res.MaxEstimatedDeliveryTime;
            res.Meals = restaurant.Meals;
            res.Mobile = restaurant.Mobile;
            res.Name = restaurant.Name;
            res.WorkingFrom = restaurant.WorkingFrom;
            res.WorkingTo = restaurant.WorkingTo;
            res.DeliveryFee = restaurant.DeliveryFee;
            res.Area = restaurant.Area;
            res.AreaID = restaurant.AreaID;
            res.HotLine = restaurant.HotLine;


            if(!CheckForRest(res))
            {
                ModelState.AddModelError("", "This Restaurant is already Exists in this Area ,Please check again your inputs");
                return View(restaurant);
            }
            try
            {
               
                string uniqueFileName=null;
                if (restaurant.Logo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject 
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + restaurant.Logo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    restaurant.Logo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                res.Logo = uniqueFileName;
                _RestaurantService.Add(res);

                return RedirectToAction("Registration", restaurant);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(restaurant);
            }
        }


        public ActionResult AddArea(Area area)
        {
           
            if (!ModelState.IsValid)
                return View(area);
            try
            {
                _AreatService.Add(area);

                return RedirectToAction("Registration");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(area);
            }

        }

        public ActionResult DeleteRestaurant(int id)
        {
            ApplicationUser user = context.Users.Where(u => u.RestID == id).FirstOrDefault();
            _RestaurantService.Delete(id);
            _userManager.DeleteAsync(user);

           // _RestaurantService.Delete(restid);
            return RedirectToAction("Index");
        }

        public bool CheckForRest(Restaurant res)
        {
            var restuarants = _RestaurantService.GetAll();
            foreach(var item in restuarants)
            {
                if(item.Name ==res.Name && item.AreaID==res.AreaID )
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckForUser(ManagerRegistration inp)
        {
            //if(dbcontext.Users)
            var users = context.Users.ToList();
            foreach (var item in users)
            {
                if (item.UserName == inp.Username)
                {
                    return false;
                }
            }
            return true;

        }

        public IActionResult AddAddress(Address add )
        {
           // add.AreaID = restaurant.AreaID;
            if (!ModelState.IsValid)
                return View(add);
            try
            {
               // add.AreaID = restaurant.AreaID;
                context.Addresses.Add(add);
                context.SaveChanges();
                //_AddressService.Add(add);

                return RedirectToAction("NewRegistration");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(add);
            }
        }


        public ActionResult Edit(int id)
        {
            var s = _RestaurantService.GetDetails(id);
            RestaurantModelView res = new RestaurantModelView();
            res.ID = s.ID;
            res.MaxEstimatedDeliveryTime = s.MaxEstimatedDeliveryTime;
            res.Meals = s.Meals;
            res.Mobile = s.Mobile;
            res.Name = s.Name;
            res.WorkingFrom = s.WorkingFrom;
            res.WorkingTo = s.WorkingTo;
            res.DeliveryFee = s.DeliveryFee;
            
            res.HotLine = s.HotLine;
            return View(res);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RestaurantModelView Model, IFormFile file)
        {

            try
            {
                var rest=_RestaurantService.GetDetails(id);
                rest.ID = Model.ID;
                rest.MaxEstimatedDeliveryTime = Model.MaxEstimatedDeliveryTime;
                rest.Meals = Model.Meals;
                rest.Mobile = Model.Mobile;
                rest.Name = Model.Name;
                rest.WorkingFrom = Model.WorkingFrom;
                rest.WorkingTo = Model.WorkingTo;
                rest.DeliveryFee = Model.DeliveryFee;
           
                rest.HotLine = Model.HotLine;
                string uniqueFileName = null;
                if (Model.Logo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject 
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Model.Logo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    Model.Logo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                rest.Logo = uniqueFileName;
                _RestaurantService.Update(id, rest); 
                return RedirectToAction("Index");
            }

            catch
            {
                return View(Model);
            }
        }

        public IActionResult Details(int id)
        {
            var res = _RestaurantService.GetDetails(id);
            Area area = _AreatService.GetDetails(res.AreaID);
            ViewBag.area = area.CityName + " / " + area.SubArea;
            return View(res);
        }

        public IActionResult SearchByRestaurantName(string searchString)
        {
            ViewBag.searchString = searchString;
            var res = _RestaurantService.GetAll();
            if (searchString!=null)
            {
                res = res.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            else
            {
                res = _RestaurantService.GetAll();
            }
            List<AllRestaurantModelView> restaurants = new List<AllRestaurantModelView>();
            foreach (var item in res)
            {
                Area area = _AreatService.GetDetails(item.AreaID);
                string a = area.CityName + " / " + area.SubArea;
                restaurants.Add(new AllRestaurantModelView { ID = item.ID, Logo = item.Logo, Name = item.Name, Area = a });
            }
            return View("Index", restaurants);
        }



    }
}