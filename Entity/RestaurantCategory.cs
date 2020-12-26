using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RestaurantCategory
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
