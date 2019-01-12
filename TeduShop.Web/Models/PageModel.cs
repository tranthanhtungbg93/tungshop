using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
	public class PageModel
	{
		public int ID { set; get; }
		public string Name { set; get; }
		public string Alias { set; get; }

		public string Content { set; get; }
	}
}