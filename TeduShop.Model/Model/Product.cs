using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeduShop.Model.Abstract;

namespace TeduShop.Model.Model
{
    [Table("Product")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Alias { set; get; }
        public int CateforyID { set; get; }
        public string Image { set; get; }
        public XElement MoreImages { set; get; }

        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public string Description { set; get; }
        public string Content { set; get; }
        public bool? HomeFlag { set; get; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        
        [ForeignKey("CateforyID")]
        public virtual IEnumerable<ProductCategory> ProductCategories { set; get; }
    }
}
