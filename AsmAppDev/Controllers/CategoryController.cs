using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
