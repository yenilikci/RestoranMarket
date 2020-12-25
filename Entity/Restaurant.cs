using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
