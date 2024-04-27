using AsmAppDev.Models;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.JobSeeker.Controllers
{
    public class ApplicationStatusController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;
		public ApplicationStatusController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<JobApplication> myList = _unitOfWork.JobApplicationRepository.GetAll().ToList();
			return View(myList);
		}
	}
}
