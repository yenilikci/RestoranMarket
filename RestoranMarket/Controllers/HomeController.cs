using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Controllers
{
    public class HomeController : Controller
    {
        public IUnitOfWork uow;

        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }


        public IActionResult Index(string q)
        {
            var query = uow.Restaurants.GetAll();
            query = query.Where(i => i.IsApproved && i.IsHome);
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Include(i => i.RestaurantCategories)
                .ThenInclude(i => i.Category)
                .Where(i => i.RestaurantCategories.Any(a => a.Category.CategoryName.Contains(q) || i.RestaurantName.Contains(q)));
                TempData["Aranan"] = q;
            }
            else
            {
                TempData["Tümü"] = "Tüm Restoranlar:";
            }

            return View(query.OrderByDescending(i => i.DateAdded));
        }

    }
}
