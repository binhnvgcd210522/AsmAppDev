using AsmAppDev.Models;
using AsmAppDev.Models.ViewModels;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace AsmAppDev.Areas.Users.Controllers
{
    [Area("Employer")]
    public class JobController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public JobController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var myList = _unitOfWork.JobRepository.GetAll("Category")
                    .Where(j => j.UserId == userId)  // Chỉ lấy các job thuộc về user hiện tại
                    .ToList();
                return View(myList);
            }
            // Nếu không có userId, hoặc không tìm thấy job, trả về View trống hoặc với danh sách rỗng
            return View(new List<Job>());
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
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (userId != null)
                {
                    jobVM.Job.UserId = userId;
                    _unitOfWork.JobRepository.Add(jobVM.Job);
                    _unitOfWork.JobRepository.Save();
                    TempData["success"] = "Job created successfully";
                    return RedirectToAction("Index");
                }
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
        public IActionResult ViewJobApp(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Expression<Func<JobApplication, bool>> filter = j => j.JobId == id;
            var jobApps = _unitOfWork.JobApplicationRepository.GetAllJobApp(filter);
            return View(jobApps);
        }
        public async Task<IActionResult> ViewProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin của JobApplication dựa trên id
            var jobApplication = _unitOfWork.JobApplicationRepository.Get(c => c.Id == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            // Lấy thông tin của người dùng (ApplicationUser) dựa trên email của JobApplication
            var jobSeeker = await _userManager.FindByEmailAsync(jobApplication.Email);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            // Trả về view với thông tin của người dùng
            return View(jobSeeker);
        }
        public async Task<IActionResult> Accept(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin của người dùng dựa trên id
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Thực hiện logic chấp nhận yêu cầu ở đây (ví dụ: đánh dấu user đã được chấp nhận)

            // Chuyển hướng đến trang index sau khi chấp nhận
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decline(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin của người dùng dựa trên id
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Thực hiện logic từ chối yêu cầu ở đây (ví dụ: xóa user khỏi hệ thống)

            // Chuyển hướng đến trang index sau khi từ chối
            return RedirectToAction("Index");
        }
    }
}
