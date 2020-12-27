using Data;
using Microsoft.AspNetCore.Mvc;
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
        public IRestaurantRepository restaurant;
        public IUnitOfWork uow;

        public HomeController(IUnitOfWork _uow, IRestaurantRepository _restaurant)
        {
            uow = _uow;
            restaurant = _restaurant;
        }

        public IActionResult Index()
        {
        
            return View(restaurant.GetAll());
        }

    }
}
