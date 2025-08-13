using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Models;
using System.Linq;

namespace RecruitmentSystem.Controllers
{
    public class HrController : Controller
    {
        private readonly RecruitmentSystemDbContext _context;

        public HrController(RecruitmentSystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ---------- Department Management ----------
        public IActionResult Adddepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adddepartment(AddDepartment add)
        {
            if (ModelState.IsValid)
            {
                _context.AddDepartments.Add(add);
                _context.SaveChanges();
                return RedirectToAction(nameof(Adddepartment));
            }
            return View(add);
        }

        // ---------- Vacancy Management ----------
        public IActionResult Createvacancy()
        {
            ViewBag.adddepartment = new SelectList(_context.AddDepartments.ToList(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Createvacancy(Vacancy vc)
        {
            if (ModelState.IsValid)
            {
                _context.Vacancies.Add(vc);
                _context.SaveChanges();
                return RedirectToAction(nameof(viewvacancies));
            }
            ViewBag.adddepartment = new SelectList(_context.AddDepartments.ToList(), "DepartmentId", "DepartmentName");
            return View(vc);
        }

        public IActionResult viewvacancies()
        {
            var datashow = _context.Vacancies.ToList();
            return View(datashow);
        }

        public IActionResult delete(int id)
        {
            var dataitem = _context.Vacancies.FirstOrDefault(c => c.VacancyId == id);
            if (dataitem != null)
            {
                _context.Vacancies.Remove(dataitem);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(viewvacancies));
        }

        public IActionResult editvacancy(int id)
        {
            var dataitem = _context.Vacancies.FirstOrDefault(c => c.VacancyId == id);
            if (dataitem == null)
            {
                return NotFound();
            }
            ViewBag.adddepartment = new SelectList(_context.AddDepartments.ToList(), "DepartmentId", "DepartmentName");
            return View(dataitem);
        }

        [HttpPost]
        public IActionResult editvacancy(Vacancy vac, int id)
        {
            var existing = _context.Vacancies.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            // Updated properties to match new model
            existing.JobTitle = vac.JobTitle;
            existing.JobDescription = vac.JobDescription;
            existing.PostedDate = vac.PostedDate;
            existing.DepartmentId = vac.DepartmentId;
            existing.Status = vac.Status;
            existing.NoOfOpening = vac.NoOfOpening;
            existing.Owner = vac.Owner;
            existing.ClosingDate = vac.ClosingDate;
            existing.ListOfHired = vac.ListOfHired;
            existing.City = vac.City;
            existing.Country = vac.Country;

            _context.Vacancies.Update(existing);
            _context.SaveChanges();

            return RedirectToAction(nameof(viewvacancies));
        }

        // ---------- Other Views ----------
        public IActionResult ScheduleInterview()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Hrprofile()
        {
            return View();
        }

        public IActionResult ApplicantRq()
        {
            return View();
        }
    }
}
