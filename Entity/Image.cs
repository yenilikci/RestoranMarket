using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int RestaurantId { get; set; } 
        public Restaurant Restaurant { get; set; }
    }
}
