using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant> 
    {
        //Son eklenen 10 restoranın listesini getirir
        List<Restaurant> Get10TopRestaurants();


    }
}
