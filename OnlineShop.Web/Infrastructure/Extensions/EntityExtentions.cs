using OnlineShop.Model.Models;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Infrastructure.Extensions
{
    public static class EntityExtentions
    {
        public static void UpdatePostCategory(this PostCategory postCategory,PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Description = postCategoryVm.Description;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Image = postCategoryVm.Image;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;

            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;
            post.ViewCount = postVm.ViewCount;

            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;

        }

        public static void UpdateProductCategory(this ProductCategory prodcutCategory, ProductCategoryViewModel productCategoryVm)
        {
            prodcutCategory.ID = productCategoryVm.ID;
            prodcutCategory.Name = productCategoryVm.Name;
            prodcutCategory.Description = productCategoryVm.Description;
            prodcutCategory.Alias = productCategoryVm.Alias;
            prodcutCategory.ParentID = productCategoryVm.ParentID;
            prodcutCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            prodcutCategory.Image = productCategoryVm.Image;
            prodcutCategory.HomeFlag = productCategoryVm.HomeFlag;

            prodcutCategory.CreatedDate = productCategoryVm.CreatedDate;
            prodcutCategory.CreatedBy = productCategoryVm.CreatedBy;
            prodcutCategory.UpdatedDate = productCategoryVm.UpdatedDate;
            prodcutCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            prodcutCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            prodcutCategory.MetaDescription = productCategoryVm.MetaDescription;
            prodcutCategory.Status = productCategoryVm.Status;

        }

        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Description = productVm.Description;
            product.Alias = productVm.Alias;
            product.CategoryID = productVm.CategoryID;
            product.Content = productVm.Content;
            product.Image = productVm.Image;
            product.MoreImages = productVm.MoreImages;
            product.Price = productVm.Price;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.ViewCount = productVm.ViewCount;

            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = productVm.UpdatedDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
            product.Tags = productVm.Tags;
        }
    }
}