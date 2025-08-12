using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Models;

namespace RecruitmentSystem.Controllers
{
    public class RegisterController : Controller
    {
        HrdataContext db = new HrdataContext();
        public IActionResult signup()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
    }
}
