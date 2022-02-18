using EDI_P0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EDI_P0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*Clientes clientes1;
        Clientes clientes2;
        Clientes clientes3;
        List<Clientes> ListaClientes;*/

        public HomeController(ILogger<HomeController> logger)
        {
            /*clientes1 = new Clientes
            {
                Name = "Pedro",
                LastName = " Lopéz",
                Phone = 1234567890,
                Description = "Doctor",
            };
            clientes2 = new Clientes
            {
                Name = "Alex",
                LastName = "Smith",
                Phone = 1234567890,
                Description = "Artista",
            };
            clientes3 = new Clientes
            {
                Name = "Alex",
                LastName = "Smith",
                Phone = 1234567890,
                Description = "Artista",
            };
            ListaClientes = new List<Clientes>();
            ListaClientes.Add(clientes1);
            ListaClientes.Add(clientes2);
            ListaClientes.Add(clientes3);*/

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*public List<Clientes> Index()
        {
            return ListaClientes;
        }*/

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