using AsmAppDev.Models;
using AsmAppDev.Models.ViewModels;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.JobSeeker.Controllers
{
    [Area("JobSeeker")]
    public class ViewJobController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ViewJobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Job> myList = _unitOfWork.JobRepository.GetAll("Category").ToList();
            return View(myList);
        }
        /*public IActionResult Apply()
        {
            JobVM jobVM = new JobVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Job = new Job()
            };
            return View(jobVM);
        }
        [HttpPost]
        public IActionResult Apply(JobVM jobVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Add(jobVM.Job);
                _unitOfWork.JobRepository.Save();
                TempData["success"] = "Job created successfully";
                return RedirectToAction("Index");
            }
            return View(jobVM);
        }*/
    }
}
