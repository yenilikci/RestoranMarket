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
        public int PageSize = 2;

        public IRestaurantRepository repository;

        public RestaurantController(IRestaurantRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string category,int page=1)
        {
            var restaurants = repository.GetAll();

            if (!string.IsNullOrEmpty(category))
            {
                restaurants = restaurants
                    .Include(i => i.RestaurantCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.RestaurantCategories.Any(a => a.Category.CategoryName == category));
            }
            var count = restaurants.Count();
            restaurants = restaurants.Skip((page - 1) * PageSize).Take(PageSize);
            return View(
                new RestaurantListModel()
                {
                    Restaurants = restaurants,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = count
                    }
                }
                );

        }

        public IActionResult Details(int id)
        {

            return View(
                repository
                .GetAll()
                .Where(i => i.RestaurantId == id)
                .Include(i => i.Images)
                .Include(i => i.RestaurantCategories)
                .ThenInclude(i => i.Category)
                .Select(i => new RestaurantDetailsModel()
                {
                    Restaurant = i,
                    Images = i.Images,
                    Categories = i.RestaurantCategories.Select(a => a.Category).ToList()
                }).FirstOrDefault());
        }
    }
}
