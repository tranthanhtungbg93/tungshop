using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Abstract;

namespace TeduShop.Web.Models
{
    public class ProductModel : Auditable
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public int CateforyID { set; get; }
        public string Image { set; get; }
        public string MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public virtual IEnumerable<ProductCategoryModel> ProductCategories { set; get; }
    }
}