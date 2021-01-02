using Data;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranMarket.Identity;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Controllers
{
    public class AdminController : Controller
    {

        private ICategoryRepository categoryrepo;
        private IRestaurantRepository restaurantrepo;

        //kullanıcı işlemleri için
        private UserManager<ApplicationUser> userManager;

        //update işlemi için
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;


        public AdminController(UserManager<ApplicationUser> _userManager, IPasswordValidator<ApplicationUser> _passwordValidator, IPasswordHasher<ApplicationUser> _passwordHasher, ICategoryRepository _categoryrepo, IRestaurantRepository _restaurantrepo)
        {
            userManager = _userManager;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
            categoryrepo = _categoryrepo;
            restaurantrepo = _restaurantrepo;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        public IActionResult CategoryList()
        {
            var model = categoryrepo.GetAll();
            return View(model);
        }

        public IActionResult RestaurantList()
        {
            var model = restaurantrepo.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            ViewBag.Categories = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

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
                ViewBag.Categories = new SelectList(categoryrepo.GetAll(), "CategoryId", "CategoryName");
                restaurantrepo.Add(restaurant);
                restaurantrepo.Save();
                return RedirectToAction("RestaurantList");
            }
            return View(restaurant);
        }

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

    }
}
