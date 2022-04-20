using Microsoft.AspNetCore.Mvc;
using Lab05.Models;
namespace Lab05.Controllers
{
    [Route("Controller")]
    public class CarsController : Controller
    {
        List<DataCarsModel> equipo = new List<DataCarsModel>();
        public IActionResult Index(string BusEqu, string searchString)
        {
            

            List<DataCarsModel> personas = new List<DataCarsModel>()
            {
                new DataCarsModel {Placa = "Barsa", Color = "Guar", Propietario = "Espanola", CoordenadasLat = 1, CoordenadasLong = 6},
                 new DataCarsModel {Placa = "Real", Color = "Zizu", Propietario = "Inglesa", CoordenadasLat = 2, CoordenadasLong = 7},
                   new DataCarsModel {Placa = "Chelsea", Color = "Tuch", Propietario = "Holandesa", CoordenadasLat = 3, CoordenadasLong = 8},
                     new DataCarsModel {Placa = "MANU", Color = "Rag", Propietario = "Francesa", CoordenadasLat = 4, CoordenadasLong = 9},
                       new DataCarsModel {Placa = "MANC", Color = "PEll", Propietario = "Alemana", CoordenadasLat = 5, CoordenadasLong = 10}
            };




            return View(personas);
        }




        [Route("Carga")]
        public IActionResult CargarArch()
        {
            return View(equipo);
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
                            equipo.Add(new DataCarsModel()
                            {
                                Placa = data[0],
                                Color = data[1],
                                Propietario = data[2],
                                CoordenadasLat = Convert.ToDouble(data[3]),
                                CoordenadasLong = Convert.ToDouble(data[4])
                            });
                        }
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View(equipo);
        }
       
    }
}
