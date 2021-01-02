using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{
    public class CatalogListModel
    {
        public List<Restaurant> Restaurants { get; set; }
        public List<Category> Categories { get; set; }
    }
}
