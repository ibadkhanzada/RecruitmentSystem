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

        // === Applicant Registration Form ===
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
                // Log all model validation errors (view in Output window during debug)
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(model);
            }

            // Save uploaded CV file
            if (CvFile != null && CvFile.Length > 0)
            {
                var fileName = Path.GetFileName(CvFile.FileName);
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVs");

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    CvFile.CopyTo(stream);
                }

                // Save relative path
                model.CvFilePath = "/CVs/" + fileName;
            }

            _context.ApplicantsRequests.Add(model);
            _context.SaveChanges();

            TempData["Message"] = "Application submitted successfully!";
            return RedirectToAction("Register");
        }

        // === Login ===
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
