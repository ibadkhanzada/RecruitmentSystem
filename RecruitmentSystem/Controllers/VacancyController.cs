using Microsoft.AspNetCore.Mvc;

namespace RecruitmentSystem.Controllers
{
    public class VacancyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
