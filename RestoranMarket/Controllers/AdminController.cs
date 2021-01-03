using Data;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using RestoranMarket.Identity;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private ICategoryRepository categoryrepo;
        private IRestaurantRepository restaurantrepo;
        private RestaurantContext context;

        //kullanıcı işlemleri için
        private UserManager<ApplicationUser> userManager;

        //update işlemi için
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;


        public AdminController(UserManager<ApplicationUser> _userManager, IPasswordValidator<ApplicationUser> _passwordValidator, IPasswordHasher<ApplicationUser> _passwordHasher, ICategoryRepository _categoryrepo, IRestaurantRepository _restaurantrepo, RestaurantContext _context)
        {
            userManager = _userManager;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
            categoryrepo = _categoryrepo;
            restaurantrepo = _restaurantrepo;
            context = _context;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "kullanıcı bulunamadı!");
            }
            return View("Index", userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(string id, string password, string email)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {

                user.Email = email;
                //kullanıcı varsa güncelleme işlemi
                IdentityResult validPass = null;

                //dışarıdan gelen bir password değeri varsa
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);

                    if (validPass.Succeeded)
                    {
                        //parolayı güncelle
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        foreach (var item in validPass.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            else //eğer bir kullanıcı yoksa
            {
                ModelState.AddModelError("", "kullanıcı bulunamadı!");
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CategoryList()
        {
            var model = categoryrepo.GetAll();
            return View(model);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult RestaurantList()
        {
            var model = restaurantrepo.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryrepo.Add(category);
                categoryrepo.Save();
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = categoryrepo.GetAll()
                .Include(i => i.RestaurantCategories)
                .ThenInclude(i => i.Restaurant)
                .Where(i => i.CategoryId == id)
                .Select(i => new AdminEditCategoryModel()
                {
                    CategoryId = i.CategoryId,
                    CategoryName = i.CategoryName,
                    Restaurants = i.RestaurantCategories.Select(a => new AdminEditCategoryRestaurant()
                    {
                        ResaurantId = a.RestaurantId,
                        RestaurantName = a.Restaurant.RestaurantName,
                        Image = a.Restaurant.Image,
                        IsApproved = a.Restaurant.IsApproved,
                        IsFeatured = a.Restaurant.IsFeatured,
                        IsHome = a.Restaurant.IsHome
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryrepo.Edit(category);
                categoryrepo.Save();
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRestaurant(int id)
        {
            restaurantrepo.Delete(restaurantrepo.Get(id));
            restaurantrepo.Save();
            return RedirectToAction("RestaurantList");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            categoryrepo.Delete(categoryrepo.Get(id));
            categoryrepo.Save();
            return RedirectToAction("CategoryList");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddRestaurant()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddRestaurant(Restaurant restaurant, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\app\\thumb", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        restaurant.Image = file.FileName;
                    }
                }
                restaurant.DateAdded = DateTime.Now;
                restaurantrepo.Add(restaurant);
                restaurantrepo.Save();
                return RedirectToAction();
            }
            return View(restaurant);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditRestaurant(int id) 
        {
            return View(restaurantrepo.Get(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditRestaurant(Restaurant restaurant, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\app\\thumb", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        restaurant.Image = file.FileName;
                    }
                }

                restaurantrepo.Edit(restaurant);
                restaurantrepo.Save();
                return RedirectToAction("RestaurantList");
            }
            return View(restaurant);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddAttribute()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddAttribute(RestaurantAttribute entity)
        {
            context.RestaurantAttributes.Add(entity);
            context.SaveChanges();
            return View();
        }
    }
}
