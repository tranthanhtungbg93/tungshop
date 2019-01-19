using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class RegisterModel
    {
        private const string REGEX_PASSWORD = @"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[~!@#$%^&*()]).{8,}";
        [Required(ErrorMessage ="Bạn cần nhập tên đăng nhập.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên mật khẩu.")]
        [RegularExpression(REGEX_PASSWORD, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm: ký tự in hoa, ký tự in thường, ký tự số, ký tự đặc biệt ~!@#$%^&*().")]
        public string Password { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Bạn cần nhập email.")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng.")]
        public string Email { get; set; }
    }
}