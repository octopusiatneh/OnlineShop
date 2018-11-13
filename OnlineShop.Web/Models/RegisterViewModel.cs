using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="Nhập tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [MinLength(8,ErrorMessage ="Mật khẩu phải có ít nhất 8 ký tự")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nhập địa chỉ email")]
        public string Email { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}