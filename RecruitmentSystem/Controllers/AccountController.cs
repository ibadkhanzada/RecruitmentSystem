using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;
using System.Linq;

namespace RecruitmentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly RecruitmentSystemDbContext _context;

        public AccountController(RecruitmentSystemDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Account already exists with this Email");
                return View(model);
            }

            bool isHrRegistered = _context.Users.Any(u => u.Role == "HR");
            if (model.Role == "HR" && isHrRegistered)
            {
                ModelState.AddModelError("Role", "HR role is already assigned. You cannot register as HR.");
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Role))
            {
                model.Role = "User";
            }

            _context.Users.Add(model);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u =>
                u.Email == model.Email &&
                u.Password == model.Password &&
                u.Role == model.Role);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email, Password, or Role");
                return View(model);
            }

            if (user.Role == "HR")
                return RedirectToAction("Index", "HR");  // HRController ke Index action pe redirect
            else if (user.Role == "Interviewer")
                return RedirectToAction("InterviewerDashboard", "Dashboard", new { id = user.Id });
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
