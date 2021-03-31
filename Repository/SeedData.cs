using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Builder;

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
                    new Restaurant() {RestaurantName="Yüzen Hamsi Balık Restoranı",Image="restoran1.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-10)},
                    new Restaurant() {RestaurantName="Bread Pitt Unlu Mamülleri",Image="restoran2.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-5)},
                    new Restaurant() {RestaurantName="Kasap Et Derdinde Et Restoranı",Image="restoran3.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-7)},
                    new Restaurant() {RestaurantName="Yanar Döner Kebab",Image="restoran4.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-2)},
                    new Restaurant() {RestaurantName="FaceFood Kahvaltı Evi",Image="restoran1.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-3)},
                    new Restaurant() {RestaurantName="Aralık Sonu Ocakbaşı Çorba",Image="restoran2.jpg",IsOtopark=true,IsService=true,IsOpenArea=true,IsHome=false,IsApproved=false,IsFeatured=false,Description="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",HtmlContent="Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı <b>1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</b>",DateAdded=DateTime.Now.AddDays(-9)}
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

                    //kayıt işlemini tamamlamak için
                    context.SaveChanges();
                }

        }
    }
}
