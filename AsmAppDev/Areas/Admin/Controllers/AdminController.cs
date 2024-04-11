using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.Admin.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
