using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>().MaxDepth(2);
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
                cfg.CreateMap<Tag, TagViewModel>().MaxDepth(2);

                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);
                cfg.CreateMap<Product, ProductViewModel>().MaxDepth(2);
                cfg.CreateMap<ProductTag, ProductTagViewModel>().MaxDepth(2);
                cfg.CreateMap<Footer, FooterViewModel>().MaxDepth(2);
                cfg.CreateMap<Slide, SlideViewModel>().MaxDepth(2);
                cfg.CreateMap<ContactDetail, ContactDetailViewModel>().MaxDepth(2);

                cfg.CreateMap<ApplicationGroup, ApplicationGroupViewModel>().MaxDepth(2);
                cfg.CreateMap<ApplicationRole, ApplicationRoleViewModel>().MaxDepth(2);
                cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>().MaxDepth(2);
            });           
        }
    }
}