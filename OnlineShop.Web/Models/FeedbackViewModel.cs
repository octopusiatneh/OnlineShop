
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }

        [MaxLength(250, ErrorMessage = "Tên không được quá 250 ký tự")]   
        public string Name { set; get; }

        [MaxLength(250, ErrorMessage = "Bạn biết không, email gọn gàng sẽ khiến mọi người thoải mái hơn")]
        [Required(ErrorMessage = "Có lẽ như bạn quên nhập email của bản thân thì phải")]
        public string Email { set; get; }

        [MaxLength(500, ErrorMessage = "Tụi mình sẽ gặp khó khăn nếu tin nhắn của bạn quá dài đó")]
        [Required(ErrorMessage = "Bạn muốn nhắn gửi gì đến tụi mình vậy")]
        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required(ErrorMessage = "Phải nhập trạng thái")]
        public bool Status { set; get; }

        public ContactDetailViewModel ContactDetail { set; get; }
    }
}