using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
