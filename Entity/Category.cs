using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
