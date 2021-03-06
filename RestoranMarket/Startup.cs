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
using Microsoft.Extensions.Options;
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
            //identity i�in
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                //�ifre i�in gerekli uzunluk
                options.Password.RequiredLength = 3;
                //k���k harf zorunlulu�u kald�r�ld�
                options.Password.RequireLowercase = false;
                //b�y�k harf zorunlulu�u kald�r�ld�
                options.Password.RequireUppercase = false;
                //alfanumerik zorunlulu�u olmas�n
                options.Password.RequireNonAlphanumeric = false;
                //rakam zorunlulu�u yok
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            //interfaceleri kullanmak i�in
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            //lokalle�tirme ve globalle�tirme
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                options => { options.ResourcesPath = "Resources"; }).AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
                options => {
                    var supportedCulteres = new List<CultureInfo>
                {
                    new CultureInfo("tr"),
                    new CultureInfo("en"),
                    new CultureInfo("de")
                };
                    options.DefaultRequestCulture = new RequestCulture("tr");
                    options.SupportedCultures = supportedCulteres;
                    options.SupportedUICultures = supportedCulteres;
                });

            //default
            services.AddControllersWithViews();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

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
