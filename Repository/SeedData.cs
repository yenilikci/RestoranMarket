using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {

                var context = app.ApplicationServices.GetService<RestaurantContext>();

                context.Database.EnsureCreated();

                //eğer hiçbir restoran verisi yoksa
                if (!context.Restaurants.Any())
                {
                    var restaurants = new[]
                    {
                    new Restaurant() {RestaurantName="Yüzen Hamsi Balık Restoranı"},
                    new Restaurant() {RestaurantName="Bread Pitt Unlu Mamülleri"},
                    new Restaurant() {RestaurantName="Kasap Et Derdinde Et Restoranı"},
                    new Restaurant() {RestaurantName="Yanar Döner Kebab"},
                    new Restaurant() {RestaurantName="FaceFood Kahvaltı Evi"},
                    new Restaurant() {RestaurantName="Aralık Sonu Ocakbaşı Çorba"}
                };

                    //restoran isimlerini ekleyelim
                    context.Restaurants.AddRange(restaurants);

                    var categories = new[]
                    {
                    new Category(){CategoryName="Et Restoranı"},
                    new Category(){CategoryName="Balık Restoranı"},
                    new Category(){CategoryName="Çorba Restoranı"},
                    new Category(){CategoryName="Kahvaltı Restoranı"},
                    new Category(){CategoryName="Hamurişi Restoranı"}
                };

                    //kategori isimlerini ekleyelim
                    context.Categories.AddRange(categories);

                    var restaurantCategories = new[]
                    {
                    new RestaurantCategory(){Restaurant=restaurants[0],Category=categories[1]},
                    new RestaurantCategory(){Restaurant=restaurants[1],Category=categories[4]},
                    new RestaurantCategory(){Restaurant=restaurants[2],Category=categories[0]},
                    new RestaurantCategory(){Restaurant=restaurants[3],Category=categories[0]},
                    new RestaurantCategory(){Restaurant=restaurants[4],Category=categories[3]},
                    new RestaurantCategory(){Restaurant=restaurants[5],Category=categories[2]},
                };

                    context.AddRange(restaurantCategories);

                    //kayıt işlemini tamamlamak için
                    context.SaveChanges();
                }

        }
    }
}
