using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{
    public class AdminEditCategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<AdminEditCategoryRestaurant> Restaurants { get; set; }
    }

    public class AdminEditCategoryRestaurant
    {
        public int ResaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Image { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }

    }
}
