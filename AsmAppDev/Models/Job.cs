﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmAppDev.Models
{
	public class Job 
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string requiredQualification { get; set; }
		public DateTime Deadline { get; set; }
		[ValidateNever]
		public int? CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public Category Category { get; set; }
	}
}
