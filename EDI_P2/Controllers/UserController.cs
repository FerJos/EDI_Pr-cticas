using Microsoft.AspNetCore.Mvc;

namespace EDI_P2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
