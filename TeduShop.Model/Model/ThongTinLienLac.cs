using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Model
{
	[Table("ThongTinLienLac")]
	public class ThongTinLienLac
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[StringLength(250)]
		[Required]
		public string TenLienLac { get; set; }
		[StringLength(50)]
		public string SoDienThoai { get; set; }
		[StringLength(250)]
		public string EmailLienLac { get; set; }
		[StringLength(250)]
		public string WebSiteLienLac { get; set; }
		[StringLength(250)]
		public string AddressLienLac { get; set; }
		public string OtherLienLac { get; set; }
		public double? LatLienLac { get; set; }
		public double? LgnLienLac { get; set; }
		public bool TrangThai { get; set; }
	}
}
