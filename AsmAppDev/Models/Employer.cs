using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Models
{
	public class Employer 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public bool Activation { get; set; } = true;
	}
}
