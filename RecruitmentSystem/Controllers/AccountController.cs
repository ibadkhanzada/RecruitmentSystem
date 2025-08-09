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

        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register POST
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Email uniqueness check
            var userExists = _context.Users.Any(u => u.Email == model.Email);
            if (userExists)
            {
                ModelState.AddModelError("Email", "Email already registered");
                return View(model);
            }

            // Simple password hashing (optional, recommend hashing)
            // model.Password = HashPassword(model.Password);

            _context.Users.Add(model);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required";
                return View();
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            // Save user info in session for later use
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserRole", user.Role);

            // Redirect based on role
            if (user.Role == "HR")
                return RedirectToAction("DashboardHR", "Dashboard");
            else if (user.Role == "Interviewer")
                return RedirectToAction("DashboardInterviewer", "Dashboard");
            else
                return RedirectToAction("Index", "Home");  // Normal user

        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
