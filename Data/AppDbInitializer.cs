using sell_laptops.LMS.Data.Static;
using sell_laptops.LMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScop.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Laptopss
                if (!context.Laptopss.Any())
                {
                    context.Laptopss.AddRange(new List<Laptop>() {
                    new Laptop()
                    {
                        ImageCode = 11,
                        Name = "apple",
                        Description="Brand: Apple",
                        Price=1200,
                        LaptopCategory=LaptopCategory.Apple},
                    new Laptop()
                    {
                        ImageCode = 22,
                        Name = "asus",
                        Description="Brand: Asus",
                        Price=800,
                        LaptopCategory=LaptopCategory.Asus},

                    new Laptop()
                    {
                        ImageCode = 33,
                        Name = "dell",
                        Description="Brand: Dell",
                        Price=999,
                        LaptopCategory=LaptopCategory.Dell},

                    new Laptop()
                    {
                        ImageCode = 44,
                        Name = "HP",
                        Description="Brand: HP",
                        Price=500,
                        LaptopCategory=LaptopCategory.HP},

                    new Laptop()
                    {
                        ImageCode = 55,
                        Name = "acer",
                        Description="Brand: Acer",
                        Price=900,
                        LaptopCategory=LaptopCategory.Acer},

                    new Laptop()
                    {
                        ImageCode = 66,
                        Name = "Lenovo",
                        Description="Brand: Lenovo",
                        Price=600,
                        LaptopCategory=LaptopCategory.Lenovo},

                    

                    
                

                    });
                    context.SaveChanges();

                }


            }
        }
        
        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScop.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // Used default IdentityRole V.83
                
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                     await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                     await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //~

                // Users | Admin
                var userManager = serviceScop.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>(); // Created model customized inheret from IdentityUserRole V.83
                string AdminUserEmail= "admin@admin.com";
                var adminUser = await userManager.FindByEmailAsync(AdminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser
                    {
                        FullName = "Admin",
                        UserName = "admin-User",
                        Email = AdminUserEmail,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };
                    await userManager.CreateAsync(newAdminUser, "!Admin1");          // [TroubleShooting] when seed pass shoud provide pass_requiremen otherwice get FK_Conflect at FK_AspNetUserRoles MSH
                    await userManager.AddToRoleAsync(newAdminUser,UserRoles.Admin);
                }//~
                
                // Users | User
                string XUserEmail = "xuser@user.com";
                var XUser = await userManager.FindByEmailAsync(XUserEmail);
                if (XUser == null)
                {
                    var newXUser = new ApplicationUser
                    {
                        FullName = "User No.0",
                        UserName = "Xuser-User",
                        Email = XUserEmail,
                        EmailConfirmed = true,
                        LockoutEnabled = false
                    };
                    await userManager.CreateAsync(newXUser, "!User1");
                    await userManager.AddToRoleAsync(newXUser, UserRoles.User);
                }//~ 

            }
        }
        
    }
}



                         










                                     
                        
                       
                    


   
    

