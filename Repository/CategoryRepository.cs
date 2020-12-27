using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(RestaurantContext context) : base(context)
        {

        }

        public RestaurantContext RestaurantContext
        {
            get
            {
                return context as RestaurantContext;
            }
        }

        public Category CategoryByName(string name)
        {
            return RestaurantContext.Categories.Where(i => i.CategoryName == name).FirstOrDefault();
        }
    }
}
