using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class RestaurantCategory
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
