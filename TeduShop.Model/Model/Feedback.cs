﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Model
{
	[Table("Feedbacks")]
	public class Feedback
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[StringLength(250)]
		[Required]
		public string Name { get; set; }
		[StringLength(250)]
		public string Email { get; set; }
		[StringLength(1000)]
		public string Message { get; set; }
		public DateTime CreateDate { get; set; }
		[Required]
		public bool Status { get; set; }
	}
}
