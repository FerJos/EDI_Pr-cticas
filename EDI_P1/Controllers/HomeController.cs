using EDI_P1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EDI_P1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Persona> personaList;
        Persona cliente1;
        Persona cliente2;
        Persona cliente3;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            cliente1 = new Persona
            {
                Name = "Pedro",
                LastName = "Aucob",
                Phone = 1234567890,
                Description = "Actor",
            };
            cliente2 = new Persona
            {
                Name = "Juan",
                LastName = "López",
                Phone = 1234567890,
                Description = "Pintor",
            };
            cliente3 = new Persona
            {
                Name = "Jane",
                LastName = "Doe",
                Phone = 1234567890,
                Description = "Comediante",
            };
            personaList = new List<Persona>();
            personaList.Add(cliente1);
            personaList.Add(cliente2);
            personaList.Add(cliente3);
        }

        /*public IActionResult Index()
        {
            return View();
        }*/
        public List<Persona> Index()
        {
            return personaList;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}