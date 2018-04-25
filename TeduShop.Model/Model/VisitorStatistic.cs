using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Model
{
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {
        [Key]
        public Guid Id { set; get; }
        [Required]
        public DateTime VisitedDate { set; get; }
        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}
