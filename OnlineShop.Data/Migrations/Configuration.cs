namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineShopDbContext context)
        {
            CreateUserSample(context);
            CreateProductCategorySample(context);
            CreateProductSample(context);
            CreateSlideSample(context);
            CreateContactDetail(context);
            //  This method will be called after migrating to the latest version.


        }
        private void CreateUserSample(OnlineShopDbContext context)
        {
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

        private void CreateProductCategorySample(OnlineShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory(){Name="Nam",Alias="nam",Status=true},
                new ProductCategory(){Name="Nữ",Alias="nu",Status=true},
                new ProductCategory(){Name="Ba lô",Alias="ba-lo",Status=true},
                new ProductCategory(){Name="Đồng hồ",Alias="dong-ho",Status=true},
                new ProductCategory(){Name="Giày",Alias="giay",Status=true}
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateProductSample(OnlineShopDbContext context)
        {
            if(context.Products.Count()==0)
            {
                List<Product> listProduct = new List<Product>()
                {
                    new Product(){Name="Esprit Ruffle Shirt",Alias="esprit-ruffle-shirt",Image="/UploadFiles/images/product-01.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=16},
                    new Product(){Name="Herschel supply",Alias="herschel-supply",Image="/UploadFiles/images/product-02.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=35},
                    new Product(){Name="Only Check Trouser",Alias="only-check-trouser",Image="/UploadFiles/images/product-03.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=24},
                    new Product(){Name="Classic Trench Coat",Alias="classic-trench-coat",Image="/UploadFiles/images/product-04.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=75},
                    new Product(){Name="Front Pocket Jumper",Alias="front-pocket-jumper",Image="/UploadFiles/images/product-05.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=34},
                    new Product(){Name="Vintage Inspired Classic",Alias="vintage-inspired-classic",Image="/UploadFiles/images/product-06.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=93},
                    new Product(){Name="Shirt in Stretch Cotton",Alias="shirt-in-stretch-cotton",Image="/UploadFiles/images/product-07.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=52},
                    new Product(){Name="Pieces Metallic Printed",Alias="pieces-metallic-printed",Image="/UploadFiles/images/product-08.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,Price=18},
                    new Product(){Name="Converse All Star Hi Plimsolls",Alias="converse-all-star-hi-plimsolls",Image="/UploadFiles/images/product-09.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=75},
                    new Product(){Name="Femme T-Shirt In Stripe",Alias="femme-t-shirt-in-stripe",Image="/UploadFiles/images/product-10.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=26},
                    new Product(){Name="T-Shirt with Sleeve",Alias="t-shirt-with-sleeve",Image="/UploadFiles/images/product-11.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=63},
                    new Product(){Name="Herschel supply",Alias="herschel-supply",Image="/UploadFiles/images/product-12.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=60},
                    new Product(){Name="Faded Skinny Jean",Alias="faded-skinny-jean",Image="/UploadFiles/images/product-13.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=18},
                    new Product(){Name="Pretty Little Thing",Alias="pretty-little-thing",Image="/UploadFiles/images/product-14.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=54},
                    new Product(){Name="Mini Silver Mesh Watch",Alias="mini-silver-mesh-watch",Image="/UploadFiles/images/product-15.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=86},
                    new Product(){Name="Legging",Alias="legging",Image="/UploadFiles/images/product-16.jpg",Status=true,HomeFlag=true,CategoryID=2,CreatedDate=DateTime.Now,HotFlag=true,Price=29}
                };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }

        private void CreateSlideSample(OnlineShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>
                {
                    new Slide()
                    {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,Url="#",
                        Image ="/Assets/client/images/slide-02.jpg",
                        Content = @" <div class=""layer-slick1 animated visible-false"" data-appear=""rollIn"" data-delay=""0"">
                            <span class=""ltext-202 cl2 respon2"">
                                Men New-Season
                            </span>
                        </div>
                                    <div class=""layer-slick1 animated visible-false"" data-appear=""lightSpeedIn"" data-delay=""400"">
                            <h2 class=""ltext-104 cl2 p-t-19 p-b-43 respon1"">
                                Jackets & Coats
                            </h2>
                        </div>

                        <div class=""layer-slick1 animated visible-false"" data-appear=""slideInUp"" data-delay=""800"">
                            <a href = ""product.html"" class=""flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04"">
                                Shop Now
                            </a>
                        </div>
"
                    },
                    new Slide()
                    {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,Url="#",
                        Image ="/Assets/client/images/slide-03.jpg",
                        Content =@"
                            <div class=""layer-slick1 animated visible-false"" data-appear=""rollIn"" data-delay=""0"">
								<span class=""ltext-202 cl2 respon2"">
									Men New-Season
                                </span>
							</div>
								
							<div class=""layer-slick1 animated visible-false"" data-appear=""lightSpeedIn"" data-delay=""400"">
								<h2 class=""ltext-104 cl2 p-t-19 p-b-43 respon1"">
									Jackets & Coats
                                </h2>
							</div>
								
							<div class=""layer-slick1 animated visible-false"" data-appear=""slideInUp"" data-delay=""800"">
								<a href = ""product.html"" class=""flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04"">
									Shop Now
                                </a>
							</div>"
                    },
                    new Slide()
                    {
                        Name = "Slide 3",
                        DisplayOrder = 3,
                        Status = true,
                        Url = "#",
                        Image = "/Assets/client/images/slide-04.jpg",
                        Content=@" 
                            <div class=""layer-slick1 animated visible-false"" data-appear=""rotateInDownLeft"" data-delay=""0"">
								<span class=""ltext-202 cl2 respon2"">
									Women Collection 2018
                                </span>
							</div>
								
							<div class=""layer-slick1 animated visible-false"" data-appear=""rotateInUpRight"" data-delay=""400"">
								<h2 class=""ltext-104 cl2 p-t-19 p-b-43 respon1"">
									NEW SEASON
                                </h2>
							</div>
								
							<div class=""layer-slick1 animated visible-false"" data-appear=""rotateIn"" data-delay=""800"">
								<a href = ""product.html"" class=""flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04"">
									Shop Now
                                </a>
							</div>"
                    }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(OnlineShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new ContactDetail()
                    {
                        Name = "Houturn Clo Store",
                        Address = "155 Sư Vạn Hạnh (nd), Phường 13, Quận 10, TP.HCM",
                        Email = "ntnq1910@gmail.com",
                        Lat = 10.77595,
                        Lng = 106.66750,
                        Phone = "0937003163",
                        Website = "https://www.facebook.com/Houturn.clo/",
                        Other = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }

            }
        }
    }
}