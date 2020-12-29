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
                    new Restaurant() {RestaurantName="Yüzen Hamsi Balık Restoranı",Image="restoran1.jpg"},
                    new Restaurant() {RestaurantName="Bread Pitt Unlu Mamülleri",Image="restoran2.jpg"},
                    new Restaurant() {RestaurantName="Kasap Et Derdinde Et Restoranı",Image="restoran3.jpg"},
                    new Restaurant() {RestaurantName="Yanar Döner Kebab",Image="restoran4.jpg"},
                    new Restaurant() {RestaurantName="FaceFood Kahvaltı Evi",Image="restoran1.jpg"},
                    new Restaurant() {RestaurantName="Aralık Sonu Ocakbaşı Çorba",Image="restoran2.jpg"}
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


                    var images = new[]
                    {
                        new Image(){ ImageName="restoran1.jpg",Restaurant=restaurants[0]},
                        new Image(){ ImageName="restoran2.jpg",Restaurant=restaurants[0]},
                        new Image(){ ImageName="restoran3.jpg",Restaurant=restaurants[0]},
                        new Image(){ ImageName="restoran4.jpg",Restaurant=restaurants[0]},


                        new Image(){ ImageName="restoran1.jpg",Restaurant=restaurants[1]},                       
                        new Image(){ ImageName="restoran2.jpg",Restaurant=restaurants[1]},
                        new Image(){ ImageName="restoran3.jpg",Restaurant=restaurants[1]},
                        new Image(){ ImageName="restoran4.jpg",Restaurant=restaurants[1]},

                        
                        new Image(){ ImageName="restoran1.jpg",Restaurant=restaurants[2]},
                        new Image(){ ImageName="restoran2.jpg",Restaurant=restaurants[2]},
                        new Image(){ ImageName="restoran3.jpg",Restaurant=restaurants[2]},
                        new Image(){ ImageName="restoran4.jpg",Restaurant=restaurants[2]},

                        new Image(){ ImageName="restoran1.jpg",Restaurant=restaurants[3]},
                        new Image(){ ImageName="restoran2.jpg",Restaurant=restaurants[3]},
                        new Image(){ ImageName="restoran3.jpg",Restaurant=restaurants[3]},
                        new Image(){ ImageName="restoran4.jpg",Restaurant=restaurants[3]},

                        new Image(){ ImageName="restoran1.jpg",Restaurant=restaurants[4]},
                        new Image(){ ImageName="restoran2.jpg",Restaurant=restaurants[4]},
                        new Image(){ ImageName="restoran3.jpg",Restaurant=restaurants[4]},
                        new Image(){ ImageName="restoran4.jpg",Restaurant=restaurants[4]},
                    };

                    context.Images.AddRange(images);

                    var attributes = new []
                    {
                        new RestaurantAttribute(){Attribute="Otopark Var Mı?",Value="Evet",Restaurant=restaurants[0]},
                        new RestaurantAttribute(){Attribute="Açık Alan Var Mı?",Value="Evet",Restaurant=restaurants[0]},
                        new RestaurantAttribute(){Attribute="Paket Servis Var Mı?",Value="Evet",Restaurant=restaurants[0]},

                        new RestaurantAttribute(){Attribute="Otopark Var Mı?",Value="Hayır",Restaurant=restaurants[1]},
                        new RestaurantAttribute(){Attribute="Açık Alan Var Mı?",Value="Hayır",Restaurant=restaurants[1]},
                        new RestaurantAttribute(){Attribute="Paket Servis Var Mı?",Value="Evet",Restaurant=restaurants[1]},

                        new RestaurantAttribute(){Attribute="Otopark Var Mı?",Value="Evet",Restaurant=restaurants[2]},
                        new RestaurantAttribute(){Attribute="Açık Alan Var Mı?",Value="Hayır",Restaurant=restaurants[2]},
                        new RestaurantAttribute(){Attribute="Paket Servis Var Mı?",Value="Evet",Restaurant=restaurants[2]},

                        new RestaurantAttribute(){Attribute="Otopark Var Mı?",Value="Evet",Restaurant=restaurants[3]},
                        new RestaurantAttribute(){Attribute="Açık Alan Var Mı?",Value="Evet",Restaurant=restaurants[3]},
                        new RestaurantAttribute(){Attribute="Paket Servis Var Mı?",Value="Hayır",Restaurant=restaurants[3]},

                        new RestaurantAttribute(){Attribute="Otopark Var Mı?",Value="Hayır",Restaurant=restaurants[4]},
                        new RestaurantAttribute(){Attribute="Açık Alan Var Mı?",Value="Hayır",Restaurant=restaurants[4]},
                        new RestaurantAttribute(){Attribute="Paket Servis Var Mı?",Value="Hayır",Restaurant=restaurants[4]},
                    };

                    context.RestaurantAttributes.AddRange(attributes);

                    //kayıt işlemini tamamlamak için
                    context.SaveChanges();
                }

        }
    }
}
