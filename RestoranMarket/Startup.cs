using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using RestoranMarket.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //context servisleri
            services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("RestoranMarket")));
            //identity için
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                //þifre için gerekli uzunluk
                options.Password.RequiredLength = 3;
                //küçük harf zorunluluðu kaldýrýldý
                options.Password.RequireLowercase = false;
                //büyük harf zorunluluðu kaldýrýldý
                options.Password.RequireUppercase = false;
                //alfanumerik zorunluluðu olmasýn
                options.Password.RequireNonAlphanumeric = false;
                //rakam zorunluluðu yok
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            //interfaceleri kullanmak için
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //lokalleþtirme için
            services.AddLocalization(options => options.ResourcesPath = "");

            //default
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new[]
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
                new CultureInfo("de-DE"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("tr-TR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "restaurants",
                pattern: "restaurants/{category?}",
                defaults: new { controller = "Restaurant", action = "List" }
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.Seed(app);
            SeedIdentity.CreateIdentityUsers(app.ApplicationServices,Configuration).Wait();
        }
    }
}
