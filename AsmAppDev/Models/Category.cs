using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Models
{
	public class Category 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		private bool Availability { get; set; } = false;
	}
}
