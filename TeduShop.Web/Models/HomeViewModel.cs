using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
	public class HomeViewModel
	{
		public IEnumerable<SlideModel> Slides { get; set; }
		public IEnumerable<ProductModel> Products { get; set; }
		public IEnumerable<ProductModel> TopSaleProducts { get; set; }
		public IEnumerable<ProductModel> LastestProducts { get; set; }
	}
}