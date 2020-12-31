using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Models
{

        public class PagingInfo
        {
            public int TotalItems { get; set; } //kaç tane ürün var
            public int ItemsPerPage { get; set; } //kaç tanesi o an sayfaya gelecek
            public int CurrentPage { get; set; } //o an ki sayfa
            public int TotalPages()
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }

        }

        public class RestaurantListModel
        {
            public IEnumerable<Restaurant> Restaurants { get; set; }
            public PagingInfo PagingInfo { get; set; }
        }
}
