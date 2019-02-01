using System.ComponentModel.DataAnnotations;

namespace TeduShop.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bạn cần nhập mật khẩu.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}