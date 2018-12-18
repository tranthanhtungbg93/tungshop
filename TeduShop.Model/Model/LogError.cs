using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Model
{
    [Table("LogError")]
    public class LogError
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Massage { get; set; }
        public string StackTrace { get; set; }
    }
}
