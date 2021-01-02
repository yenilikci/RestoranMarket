using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestoranMarket.Identity;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Controllers
{
    public class AdminController : Controller
    {

        private ICategoryRepository categoryrepo;

        //kullanıcı işlemleri için
        private UserManager<ApplicationUser> userManager;

        //update işlemi için
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;


        public AdminController(UserManager<ApplicationUser> _userManager, IPasswordValidator<ApplicationUser> _passwordValidator,IPasswordHasher<ApplicationUser> _passwordHasher,ICategoryRepository _categoryrepo)
        {
            userManager = _userManager;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
            categoryrepo = _categoryrepo;
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
        public async Task<IActionResult> Update(string id,string password,string email)
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
                    validPass = await passwordValidator.ValidateAsync(userManager,user, password);

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

    }
}
