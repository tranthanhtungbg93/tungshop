using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
	public class ThongTinLienLacModel
	{
		public int ID { get; set; }
		[Required]
		public string TenLienLac { get; set; }
		[StringLength(50, ErrorMessage ="Số điện thoại không vượt quá 50 kí tự.")]
		public string SoDienThoai { get; set; }
		[StringLength(250,ErrorMessage = "Email không vượt quá 250 kí tự.")]
		public string EmailLienLac { get; set; }
		[StringLength(250, ErrorMessage = "Trang web không vượt quá 250 kí tự.")]
		public string WebSiteLienLac { get; set; }
		[StringLength(250, ErrorMessage = "Địa chỉ không vượt quá 250 kí tự.")]
		public string AddressLienLac { get; set; }
		public string OtherLienLac { get; set; }
		public double? LatLienLac { get; set; }
		public double? LgnLienLac { get; set; }
		public bool TrangThai { get; set; }
	}
}