namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Data.OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShop.Data.OnlineShopDbContext context)
        {
            //CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OnlineShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new OnlineShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "quang",
                Email = "ntnq1910@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Nguyễn Trương Ngọc Quang"

            };

            var user2 = new ApplicationUser()
            {
                UserName = "ngoc",
                Email = "caulaai1998@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Ngọc Gà"

            };

            manager.Create(user, "123654$");
            manager.Create(user2, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("ntnq1910@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(OnlineShop.Data.OnlineShopDbContext context)
        {
            if(context.ProductCategories.Count()== 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory(){Name="Điện lạnh",Alias="dien-lanh",Status=true},
                new ProductCategory(){Name="Viễn thông",Alias="vien-thong",Status=true},
                new ProductCategory(){Name="Đồ gia dụng",Alias="do-gia-dung",Status=true},
                new ProductCategory(){Name="Mỹ phẩm",Alias="my-pham",Status=true}
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
          
        }
    }
}