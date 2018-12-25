using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Abstract;

namespace TeduShop.Web.Models
{
    public class ProductCategoryModel : Auditable
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<ProductModel> Products { set; get; }
    }
}