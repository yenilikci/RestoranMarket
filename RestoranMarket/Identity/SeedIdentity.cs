using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoranMarket.Identity
{
    public static class SeedIdentity
    {
        public static async Task CreateIdentityUsers(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            //önce asenkron olarak eklemek istediğimiz kullanıcı adına bakalım
            if (await userManager.FindByNameAsync(username) == null)
            {
                //eğer kullanıcı adı null ise daha sonra eklemek istediğimiz role bakalım
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role)); //rolumuz veritabanında olusacak
                }

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = username,
                    Email = email,
                    Name = "Admin",
                    Surname = "Admin"
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                //şimdi eğer kullanıcı oluşmuş ise
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }

            }
        }
    }
}
