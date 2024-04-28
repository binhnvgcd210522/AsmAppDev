using AsmAppDev.Models;
using AsmAppDev.Models.ViewModels;
using AsmAppDev.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace AsmAppDev.Areas.JobSeeker.Controllers
{
    [Area("JobSeeker")]
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProfileController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;   
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
        public IActionResult Edit(string id, [Bind("Id,Name,Address,Email,Introduction,Avatar,CV")] ApplicationUser jobSeeker, IFormFile avatarFile, IFormFile cvFile)
        {
            if (id != jobSeeker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwrootPath = _webHostEnvironment.WebRootPath;
                    // Lưu avatar mới nếu có
                    if (avatarFile != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(avatarFile.FileName);
                        string avatarPath = Path.Combine(wwwrootPath, @"img\avatars");
                        // Delete Old Images
                        if (!string.IsNullOrEmpty(jobSeeker.Avatar))
                        {
                            var oldImagePath = Path.Combine(wwwrootPath, jobSeeker.Avatar.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                        // Copy File to \img\avatars
                        using (var fileStream = new FileStream(Path.Combine(wwwrootPath, fileName), FileMode.Create))
                        {
                            avatarFile.CopyTo(fileStream);
                        }
                        // Update ImageUrl in DB
                        jobSeeker.Avatar = @"\img\avatars\" + fileName;
                    }

                    // Lưu CV mới nếu có
                    if (cvFile != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(cvFile.FileName);
                        string avatarPath = Path.Combine(wwwrootPath, @"img\cv");
                        // Delete Old Images
                        if (!string.IsNullOrEmpty(jobSeeker.CV))
                        {
                            var oldImagePath = Path.Combine(wwwrootPath, jobSeeker.CV.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                        // Copy File to \img\avatars
                        using (var fileStream = new FileStream(Path.Combine(wwwrootPath, fileName), FileMode.Create))
                        {
                            cvFile.CopyTo(fileStream);
                        }
                        // Update ImageUrl in DB
                        jobSeeker.CV = @"\img\avatars\" + fileName;
                    }

                    // Cập nhật thông tin người dùng trong cơ sở dữ liệu
                    _unitOfWork.AppUserRepository.Update(jobSeeker);
                    _unitOfWork.AppUserRepository.Save();
                    TempData["success"] = "Profile edited successfully";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    ModelState.AddModelError("", "An error occurred while updating the user profile.");
                    // Ghi log ngoại lệ vào file log
                }
            }

            return View(jobSeeker);
        }
    }
}