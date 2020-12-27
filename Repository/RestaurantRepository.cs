using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {

        public RestaurantRepository(RestaurantContext context) : base(context)
        {

        }


        public RestaurantContext RestaurantContext
        {
            get
            {
                return context as RestaurantContext;
            }
        }

        public List<Restaurant> Get10TopRestaurants()
        {
            return RestaurantContext.Restaurants
             .OrderByDescending(i => i.RestaurantId)
             .Take(10)
             .ToList();
        }

         
    }
}
