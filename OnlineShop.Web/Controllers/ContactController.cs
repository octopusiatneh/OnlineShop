using OnlineShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Controllers
{
    [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server)]
    public class ContactController : Controller
    {
        // GET: Contact
        IContactDetailService _contactDetailService;

        public ContactController(IContactDetailService contactDetailService)
        {
            _contactDetailService = contactDetailService;
        }
        public ActionResult Index()
        {
            var model = _contactDetailService.GetDefaultContact();
            var modelViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return View(modelViewModel);
        }
    }
}