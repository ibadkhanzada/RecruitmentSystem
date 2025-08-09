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

            // Check if email already exists
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email is already registered");
                return View(model);
            }

            // Default role user
            model.Role = "User";

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
            {
                return View(model);
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(model);
            }

            // Login success - Redirect to UserDashboard
            return RedirectToAction("UserDashboard", new { id = user.Id });
        }

        // GET: /Account/UserDashboard/5
        public IActionResult UserDashboard(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.UserName = user.Name;
            ViewBag.UserId = user.Id;

            return View();
        }
    }
}
