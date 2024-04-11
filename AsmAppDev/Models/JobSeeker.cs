using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmAppDev.Models
{
	public class JobSeeker 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string? Resume { get; set; }
		public int JobId { get; set; }
		[ForeignKey(nameof(JobId))]
		[ValidateNever]
		public Job Job { get; set; }
		public bool Activation { get; set; } = true;
	}
}
