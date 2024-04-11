using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Controllers
{
	public class JobController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
