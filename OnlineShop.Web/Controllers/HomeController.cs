using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductService productService,IProductCategoryService productCategoryService, ICommonService commonService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _commonService = commonService;
        }

        // GET: Home
        [OutputCache(Duration = 60,Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            var lastestProductModel = _productService.GetLastestProducts(24);
            var hotProductModel = _productService.GetHotProducts(24);
            var saleProductModel = _productService.GetSaleProducts(24);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProductModel);
            var saleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(saleProductModel);

            homeViewModel.LastestProduct = lastestProductViewModel;
            homeViewModel.HotProduct = hotProductViewModel;
            homeViewModel.SaleProduct = saleProductViewModel;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public PartialViewResult Footer()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            //var footerModel = _commonService.GetFooter();
            //var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public PartialViewResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;
            return PartialView(homeViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Banner()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Blog()
        {
            return PartialView();
        }
    }
}