using Data;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Controllers
{
    public class RestaurantController : Controller
    {
        public IRestaurantRepository repository;

        public RestaurantController(IRestaurantRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {

            return View(
                repository
                .GetAll()
                .Where(i => i.RestaurantId == id)
                .Include(i => i.Images)
                .Include(i => i.Attributes)
                .Include(i => i.RestaurantCategories)
                .ThenInclude(i => i.Category)
                .Select(i => new RestaurantDetailsModel()
                {
                    Restaurant = i,
                    Images = i.Images,
                    RestaurantAttributes = i.Attributes,
                    Categories = i.RestaurantCategories.Select(a => a.Category).ToList()
                }).FirstOrDefault());
        }
    }
}
