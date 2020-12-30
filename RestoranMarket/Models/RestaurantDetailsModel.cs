using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{
    public class RestaurantDetailsModel
    {
        public Restaurant Restaurant { get; set; }
        public List<Image> Images { get; set; }
        public List<RestaurantAttribute> RestaurantAttributes { get; set; }
        public List<Category> Categories { get; set; }
    }
}
