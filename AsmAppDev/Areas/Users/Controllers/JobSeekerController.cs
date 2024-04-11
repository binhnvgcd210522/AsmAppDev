using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.Users.Controllers
{
	public class JobSeekerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
