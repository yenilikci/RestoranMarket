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
    [Authorize]
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager; //kullanıcı bilgilerini almak için
        private SignInManager<ApplicationUser> signInManager; //sisteme oturum girişi için

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //kullancıyı mail adresi ile alalım
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await signInManager.SignOutAsync(); //daha önceden oluşturulmuş bir cookie varsa silelim

                    //tekrar sisteme dahil edelim
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false,false); //user,şifre,kalıcı mı olusturulsun?

                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Email", "Invalid Email or Password");
            }
            return View(model);
        }
    }
}
