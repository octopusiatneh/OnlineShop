using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { get; set; }
        public IEnumerable<ProductViewModel> LastestProduct { get; set; }
        public IEnumerable<ProductViewModel> HotProduct { get; set; }
        public IEnumerable<ProductViewModel> SaleProduct { get; set; }
    }
}