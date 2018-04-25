using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Model
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        public int PostID { set; get; }
        [Key]
        [Column(TypeName ="varchar")]
        public int TagId { set; get; }
        [ForeignKey("PostID")]
        public virtual Post Post { set; get; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}
