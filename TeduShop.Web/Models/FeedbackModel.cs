using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
	public class FeedbackModel
	{
		public int ID { get; set; }
		[MaxLength(250,ErrorMessage ="Tên không được nhập quá 250 ký tự")]
		[Required(ErrorMessage ="Bạn cần nhập tên.")]
		public string Name { get; set; }
		[MaxLength(250, ErrorMessage = "Email không được nhập quá 250 ký tự")]
		public string Email { get; set; }
		[MaxLength(1000, ErrorMessage = "Message không được nhập quá 1000 ký tự")]
		public string Message { get; set; }
		public DateTime CreateDate { get; set; }
		public bool Status { get; set; }
		public ThongTinLienLacModel ThongTinLienLacModel { get; set; }
	}
}