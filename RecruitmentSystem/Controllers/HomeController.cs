using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Models;
using System.Diagnostics;

namespace RecruitmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecruitmentSystemDbContext _context;

        public HomeController(ILogger<HomeController> logger, RecruitmentSystemDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Vacancies(string search, string location, string[] types)
        {
            var query = _context.Vacancies.AsQueryable();

            // Search filter
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(v => v.Title.Contains(search) || v.Description.Contains(search));
            }

            // Location filter
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(v => v.Location.Contains(location));
            }

            // Employment type filter
            if (types != null && types.Length > 0)
            {
                query = query.Where(v => types.Contains(v.EmploymentType));
            }

            var vacancies = query.ToList();
            return View(vacancies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
