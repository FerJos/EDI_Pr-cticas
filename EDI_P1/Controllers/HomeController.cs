using Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Controllers
{
   
    public class HomeController : Controller
    {
        List<ErrorViewModel> equipo = new List<ErrorViewModel>();
        public IActionResult Index()
        {

            List<ErrorViewModel> personas = new List<ErrorViewModel>()
            {
                new ErrorViewModel {Equipo = "FCB", Coach = "FFF", Liga = "Espanola", Fecha = "21/12/2022", RequestId = "True"},
                 new ErrorViewModel {Equipo = "RM", Coach = "MMM", Liga = "Espanola", Fecha = "21/11/2022", RequestId = "True"}
            };
            return View(personas);
        }

        [Route("Carga")]
        public IActionResult Carga()
        {
            return View(equipo);
        }


       [HttpPost("CargarArch")]

        public IActionResult CargarArch(IFormFile file)
        {
            if(file != null)
            {
                try
                {
                    string acceso = Path.Combine(Path.GetTempPath(), file.Name);
                    using (var stream = new FileStream(acceso, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                    string Todo = System.IO.File.ReadAllText(acceso);
                    foreach (string Actual in Todo.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(Actual))
                        {
                            string[] data = Actual.Split(',');
                            equipo.Add(new ErrorViewModel()
                            {
                               Equipo = data[1],
                               Coach = data[2],
                               Liga = data[3],
                               Fecha = data[4]
                            });
                        }
                    }

                }
                catch(Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View();
        }
    }
}
