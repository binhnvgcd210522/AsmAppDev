using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.Users.Controllers
{
	public class EmployerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
