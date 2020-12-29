using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RestaurantAttribute
    {
        public int RestaurantAttributeId { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
