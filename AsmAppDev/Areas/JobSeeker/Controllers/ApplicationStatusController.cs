using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.JobSeeker.Controllers
{
    public class ApplicationStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
