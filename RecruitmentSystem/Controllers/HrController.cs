using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Controllers
{
    public class HrController : Controller
    {
        HrdataContext db = new HrdataContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adddepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adddepartment(AddDepartment add)
        {
            db.AddDepartments.Add(add);
            db.SaveChanges();
            return RedirectToAction("Adddepartment");
        }

        // GET: Createvacancy
        public IActionResult Createvacancy()
        {
            var departments = db.AddDepartments.ToList();
            ViewBag.adddepartment = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Createvacancy
        [HttpPost]
        public IActionResult Createvacancy(Vacancy vc)
        {
            db.Vacancies.Add(vc);
            db.SaveChanges();
            return RedirectToAction("viewvacancies");

        }

        public IActionResult viewvacancies()
        {
            var datashow = db.Vacancies.ToList();
            return View(datashow);
        }

        public IActionResult delete(int id)
        {
            var dataitem = db.Vacancies.FirstOrDefault(c => c.VacancyId == id);
            if (dataitem != null)
            {
                db.Vacancies.Remove(dataitem);
                db.SaveChanges();
            }
            return RedirectToAction("viewvacancies");

            
        }

        public IActionResult editvacancy(int id)
        {
            var dataitem = db.Vacancies.FirstOrDefault(c => c.VacancyId == id);
            ViewBag.adddepartment = new SelectList(db.AddDepartments.ToList(), "DepartmentId", "DepartmentName");
            return View(dataitem);
        }

        [HttpPost]
        public IActionResult editvacancy(Vacancy vac, int id)
        {
            var existing = db.Vacancies.Find(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.JobTitle = vac.JobTitle;
            existing.DepartmentId = vac.DepartmentId;
            existing.Country = vac.Country;
            existing.City = vac.City;
            existing.JobDescription = vac.JobDescription;
            existing.ListOfHired = vac.ListOfHired;
            existing.Owner = vac.Owner;
            existing.Status = vac.Status;
            existing.PostedDate = vac.PostedDate;
            existing.ClosingDate = vac.ClosingDate;

            db.Vacancies.Update(existing);
            db.SaveChanges();

            return RedirectToAction("viewvacancies");
        }

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
