using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Lab3.Controllers
{
    public class SATController : Controller
    {

        List<LosNodos> nodo = new List<LosNodos>();


        public IActionResult Index()
        {
            List<LosNodos> classs = new List<LosNodos>()
            {
                new LosNodos {ID = "Barsa", email = "Guar", propietario = "Espanola", color = "21/12/2022", marca = "True", serie ="a8301df3-a381-4b57-9ee5-302c0694db99"},
                 new LosNodos {ID = "Real", email = "Zizu", propietario = "Inglesa", color = "21/11/2022", marca = "True", serie ="a8301df3-a381-4b57-9ee5-302c0694db99"},
                   new LosNodos {ID = "Chelsea", email = "Tuch", propietario = "Holandesa", color = "21/11/2022", marca = "True", serie ="a8301df3-a381-4b57-9ee5-302c0694db99"},
                     new LosNodos {ID = "MANU", email = "Rag", propietario = "Francesa", color = "21/11/2022", marca = "True", serie ="a8301df3-a381-4b57-9ee5-302c0694db99"},
                       new LosNodos {ID = "MANC", email = "PEll", propietario = "Alemana", color = "21/11/2022", marca = "True", serie ="a8301df3-a381-4b57-9ee5-302c0694db99"}
            };
            return View(classs);
        }


        [Route("Carga")]
        public IActionResult CargarArch()
        {
            return View(nodo);
        }


        [HttpPost("Carga")]

        public IActionResult CargarArch(IFormFile file)
        {
            if (file != null)
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
                            nodo.Add(new LosNodos()
                            {
                                ID = data[0],
                                email = data[1],
                                propietario = data[2],
                                color = data[3],
                                marca = data[4],
                                serie = data[5]
                            });
                        }
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View(nodo);
        }
    }
}
