using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        public DateTime DateAdded { get; set; }
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string HtmlContent { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFeatured { get; set; }
        
        public List<RestaurantCategory> RestaurantCategories { get; set; }
        public List<Image> Images { get; set; } 
        public List<RestaurantAttribute> Attributes { get; set; }
    }
}
