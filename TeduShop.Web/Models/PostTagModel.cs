using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostTagModel
    {
        public int PostID { set; get; }
        public string TagId { set; get; }
        public virtual PostModel PostModel { set; get; }
        public virtual TagModel Tag { set; get; }
    }
}