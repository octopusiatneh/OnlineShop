using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Service;
using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, ICommonService commonService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _commonService = commonService;
        }
        // GET: Product
        public ActionResult Detail(int productId)
        {
            var productModel = _productService.GetById(productId);

            var relatedProducts = _productService.GetRelatedProducts(productId, 8);

            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProducts);

            var viewModel = Mapper.Map<Product, ProductViewModel>(productModel);

            var moreImages = viewModel.MoreImages;

            List<string> listImages = new List<string>();

            if (viewModel.MoreImages != null)
                listImages = new JavaScriptSerializer().Deserialize<List<string>>(viewModel.MoreImages);

            var categoryName = _productCategoryService.GetById(viewModel.CategoryID).Name;

            ViewBag.CategoryName = categoryName;
            ViewBag.MoreImages = listImages;

            return View(viewModel);
        }

        //public ActionResult Index()
        //{
        //    var productModel = _productService.GetAll();
        //    var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);

        //    return View(productViewModel);
        //}

        public ActionResult Index(int? page, int pageSize = 16, string sort = "")
        {
            var shopViewModel = new ShopViewModel();

            var productCategoryModel = _productCategoryService.GetAll();
            //var productModel = _productService.GetAll();
            var productModel = _productService.GetSortedProduct(sort);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);

            int pageNumber = (page ?? 1);

            shopViewModel.ProductCategories = productCategoryViewModel;
            shopViewModel.Products = productViewModel.ToPagedList(pageNumber, pageSize);

            return View(shopViewModel);
        }

        public ActionResult Search(int? page, int pageSize = 8, string keyword = "")
        {
            var shopViewModel = new ShopViewModel();

            var productCategoryModel = _productCategoryService.GetAll();
            var productModel = _productService.Search(keyword);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            var productCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(productCategoryModel);

            ViewBag.Keyword = keyword;
            int pageNumber = (page ?? 1);

            shopViewModel.ProductCategories = productCategoryViewModel;
            shopViewModel.Products = productViewModel.ToPagedList(pageNumber, pageSize);

            return View(shopViewModel);
        }

        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetProductByName(keyword);

            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
    }
}