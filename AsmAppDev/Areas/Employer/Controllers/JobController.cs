using AsmAppDev.Models;
using AsmAppDev.Models.ViewModels;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.Users.Controllers
{
    [Area("Employer")]
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
        public IActionResult Create()
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
        public IActionResult Create(JobVM jobVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Add(jobVM.Job);
                _unitOfWork.JobRepository.Save();
                TempData["success"] = "Job created successfully";
                return RedirectToAction("Index");
            }
            return View(jobVM);
        }
        public IActionResult Edit(int? id)
        {
            JobVM jobVM = new JobVM()
            {
                Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }),
                Job = _unitOfWork.JobRepository.Get(c => c.Id == id)
            };
            jobVM.Categories = _unitOfWork.CategoryRepository.GetAll().Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
            return View(jobVM);
        }
        [HttpPost]
        public IActionResult Edit(JobVM jobVM)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Update(jobVM.Job);
                _unitOfWork.JobRepository.Save();
                TempData["success"] = "Job edited successfully";
                return RedirectToAction("Index");
            }
            return View(jobVM);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Job? job = _unitOfWork.JobRepository.Get(c => c.Id == id, "Category");
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }
        [HttpPost]
        public IActionResult Delete(Job job)
        {
            _unitOfWork.JobRepository.Delete(job);
            _unitOfWork.JobRepository.Save();
            TempData["success"] = "Job deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
