using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class VacancyController : Controller
    {
        public IActionResult Vacancies()
        {
            return View();
        }
    }
}
