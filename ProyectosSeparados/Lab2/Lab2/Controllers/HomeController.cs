using Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private MovieDBContext db = new MovieDBContext();

        // GET: /Movies/
        public ActionResult Indexx()
        {
            return View(db.Teams.ToList());
        }

        List<Modelo> equipo = new List<Modelo>();
        

        public IActionResult Index(string BusEqu, string searchString)
        {
            List<Modelo> personas = new List<Modelo>()
            {
                new Modelo {Equipo = "Barsa", Coach = "Guar", Liga = "Espanola", Fecha = "21/12/2022", RequestId = "True"},
                 new Modelo {Equipo = "Real", Coach = "Zizu", Liga = "Inglesa", Fecha = "21/11/2022", RequestId = "True"},
                   new Modelo {Equipo = "Chelsea", Coach = "Tuch", Liga = "Holandesa", Fecha = "21/11/2022", RequestId = "True"},
                     new Modelo {Equipo = "MANU", Coach = "Rag", Liga = "Francesa", Fecha = "21/11/2022", RequestId = "True"},
                       new Modelo {Equipo = "MANC", Coach = "PEll", Liga = "Alemana", Fecha = "21/11/2022", RequestId = "True"}
            };

           

           
            return View(personas);
        }



        //public async Task<ActionResult> Delete(int Id)
        //{
        //    var entry = db.Teams(x => x.Id == Id);
        //    if (entry != null)
        //    {
        //        db.Teams.RemoveAsync(entry);
        //        db.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}



        [Route("Carga")]
        public IActionResult CargarArch()
        {
            return View(equipo);
        }


       [HttpPost("Carga")]

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
                            equipo.Add(new Modelo()
                            {
                               Equipo = data[0],
                               Coach = data[1],
                               Liga = data[2],
                               Fecha = data[3],
                               RequestId=data[4]
                            });
                        }
                    }

                }
                catch(Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View(equipo);
        }
        public IActionResult Busc(string Equipo)
        {
            var busqueda = from s in db.Teams select s;

            if (!String.IsNullOrEmpty(Equipo))
            {
                busqueda = busqueda.Where(s => s.Equipo.Contains(Equipo)
                                       || s.Coach.Contains(Equipo));
            }
            return View(busqueda.ToList());




        }
        [HttpPost]
        public string Equipos(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

    }
}
