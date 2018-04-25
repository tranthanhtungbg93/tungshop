using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Model
{
    [Table("Menu")]
    public class Menu
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public string Target { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int GroupID { get; set; }
        [ForeignKey("GroupID")]
        public virtual MenuGroup MenuGroup { get; set; }
    }
}
