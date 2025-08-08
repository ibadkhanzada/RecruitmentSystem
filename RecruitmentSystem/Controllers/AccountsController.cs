using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RecruitmentSystem.Models;
using System.IO;
using System.Linq;

namespace RecruitmentSystem.Controllers
{
    public class AccountsController : Controller
    {
        private readonly RecruitmentSystemDbContext _context;

        public AccountsController(RecruitmentSystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(ApplicantsRequest model, IFormFile CvFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Save CV
            if (CvFile != null && CvFile.Length > 0)
            {
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVs");
                if (!Directory.Exists(uploadsPath))
                    Directory.CreateDirectory(uploadsPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(CvFile.FileName);
                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CvFile.CopyTo(stream);
                }

                model.CvFilePath = "/CVs/" + fileName;
            }

            _context.ApplicantsRequests.Add(model);
            _context.SaveChanges();

            TempData["Message"] = "Application submitted successfully!";
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
