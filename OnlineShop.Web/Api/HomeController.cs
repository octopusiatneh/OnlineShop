﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.Service;
using OnlineShop.Web.Infrastructure.Core;

namespace OnlineShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, memb. ";
        }
    }
}