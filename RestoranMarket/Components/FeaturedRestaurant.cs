using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Components
{
    public class FeaturedRestaurant : ViewComponent
    {

        public IRestaurantRepository repository;

        public FeaturedRestaurant(IRestaurantRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repository.GetAll().Where(i => i.IsApproved && i.IsFeatured).ToList());
        }
    }
}
