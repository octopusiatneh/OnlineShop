﻿using AutoMapper;
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
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            var lastestProductModel = _productService.GetLastestProducts(8);
            var hotProductModel = _productService.GetHotProducts(8);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProductModel);


            homeViewModel.LastestProduct = lastestProductViewModel;
            homeViewModel.HotProduct = hotProductViewModel;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            //var footerModel = _commonService.GetFooter();
            //var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
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