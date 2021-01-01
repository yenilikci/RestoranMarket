using Data;
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
        protected readonly IStringLocalizer<SharedResource> sharedResource;

        public HomeController(IUnitOfWork _uow, IStringLocalizer<SharedResource> _sharedResource)
        {
            uow = _uow;
            sharedResource = _sharedResource;
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
