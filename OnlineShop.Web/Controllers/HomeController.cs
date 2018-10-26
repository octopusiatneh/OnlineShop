using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
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