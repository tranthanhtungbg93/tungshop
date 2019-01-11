using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeduShop.Model.Abstract;

namespace TeduShop.Web.Models
{
    public class ProductCategoryModel 
    {
        public int ID { set; get; }
		[Required]
        public string Name { set; get; }
		[Required]
		public string Alias { set; get; }
		[Required]
		[MaxLength(500)]
		public string Description { set; get; }
		public int? ParentID { set; get; }
		public int? DisplayOrder { set; get; }
		public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<ProductModel> Products { set; get; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		[Required]
		[MaxLength(256)]
		public string MetaKeyWord { get; set; }
		[Required]
		[MaxLength(256)]
		public string MetaDescription { get; set; }
		public bool Status { get; set; }
	}
}