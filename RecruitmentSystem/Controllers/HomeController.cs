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

        public IActionResult Vacancies(string search, string city, string country, string status)
        {
            var query = _context.Vacancies.AsQueryable();

            // Search filter (JobTitle or JobDescription)
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(v =>
                    (v.JobTitle != null && v.JobTitle.Contains(search)) ||
                    (v.JobDescription != null && v.JobDescription.Contains(search)));
            }

            // City filter
            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(v => v.City != null && v.City.Contains(city));
            }

            // Country filter
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(v => v.Country != null && v.Country.Contains(country));
            }

            // Status filter
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(v => v.Status != null && v.Status.Contains(status));
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
