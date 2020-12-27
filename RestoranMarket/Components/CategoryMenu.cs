using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Components
{
    public class CategoryMenu : ViewComponent
    {
        protected ICategoryRepository repository;

        public CategoryMenu(ICategoryRepository _repository)
        {
            repository = _repository;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.GetAllWidthRestaurantCount());
        }

    }
}
