using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace OnlineShop.Web.Models
{
    public class ShopViewModel
    {
        public PagedList.IPagedList<ProductViewModel> Products { get; set; }

        public IEnumerable<ProductCategoryViewModel> ProductCategories { get; set; }
    }
}