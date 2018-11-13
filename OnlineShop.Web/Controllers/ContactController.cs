using OnlineShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using OnlineShop.Model.Models;
using OnlineShop.Web.Models;
using OnlineShop.Web.Infrastructure.Extensions;
using OnlineShop.Web.Api;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using OnlineShop.Common;

namespace OnlineShop.Web.Controllers
{

    public class ContactController : Controller
    {
        // GET: Contact
        IContactDetailService _contactDetailService;
        IFeedbackService _feedbackService;

        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            _contactDetailService = contactDetailService;
            _feedbackService = feedbackService;
        }

        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            //Validate Google recaptcha below
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (ModelState.IsValid && response.Success)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();                 

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var adminEmail = System.Web.Configuration.WebConfigurationManager.AppSettings["AdminEmail"];
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ website", content);

                ViewData["SuccessMsg"] = "Phản hồi của bạn đã được gửi thành công ^^, " +
                    "bọn mình sẽ liên hệ với bạn trong thời gian sớm nhất";

                feedbackViewModel.Email = string.Empty;
                feedbackViewModel.Message = string.Empty;
            }
            else
            {
                ViewData["ErrorMsg"] = "Phản hồi của bạn gửi đi không thành công :(";
            }
            feedbackViewModel.ContactDetail = GetDetail();
            return View("Index", feedbackViewModel);
        }

        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }

        /// <summary>  
        /// Validate Captcha  
        /// </summary>  
        /// <param name="response"></param>  
        /// <returns></returns>  
        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        }
    }

}