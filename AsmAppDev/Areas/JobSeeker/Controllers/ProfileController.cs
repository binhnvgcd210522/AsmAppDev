using AsmAppDev.Models;
using AsmAppDev.Models.ViewModels;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsmAppDev.Areas.JobSeeker.Controllers
{
	[Area("JobSeeker")]
	public class ProfileController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public ProfileController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
		{
            _userManager = userManager;
            _unitOfWork = unitOfWork;
		}

        public async Task<IActionResult> Index()
        {
            var profile = await _userManager.GetUserAsync(User);

            return View(profile);
        }


        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser? jobSeeker = _unitOfWork.AppUserRepository.Get(x => x.Id == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            return View(jobSeeker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Name,Address,Avatar,Email,Introduction,CV")] ApplicationUser jobSeeker)
        {
            if (id != jobSeeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.AppUserRepository.Update(jobSeeker);
                    _unitOfWork.Save();
                }
                catch (Exception)
                {
                    // Handle exception
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobSeeker);
        }
    }
}
