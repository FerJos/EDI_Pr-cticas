using Microsoft.AspNetCore.Mvc;
using Lab05.Models;
namespace Lab05.Controllers
{
   
    public class CarsController : Controller


    {

        ADT arboles = new ADT();
        
        List<DataCarsModel> equipo = new List<DataCarsModel>();
        public List<DataCarsModel> DatosCarros()
        {

            return new List<DataCarsModel>
            

               

            {
                
                new DataCarsModel { Placa = 123456, Color = "Azul", Propietario = "Luis", CoordenadasLat = 1, CoordenadasLong = 6 },
                 new DataCarsModel { Placa = 789012, Color = "Rojo", Propietario = "Fnachesco", CoordenadasLat = 2, CoordenadasLong = 7 },
                   new DataCarsModel { Placa = 345678, Color = "Tuch", Propietario = "Sammer", CoordenadasLat = 3, CoordenadasLong = 8 },
                     new DataCarsModel { Placa = 901234, Color = "Rag", Propietario = "Alejandro", CoordenadasLat = 4, CoordenadasLong = 9 },
                       new DataCarsModel { Placa = 567890, Color = "PEll", Propietario = "Alemana", CoordenadasLat = 5, CoordenadasLong = 10 }
                       
                       

            };
        

        }


        
        

        [Route("Controller")]
        
        public IActionResult Index2()
        {
            var carros = from a in DatosCarros()
                           orderby a.Placa
                           select a;
            foreach (var carro in DatosCarros())
            {
                arboles.Insertar(carro, arboles.Root);
            }
            arboles.Buscar(567890, arboles.Root);
            arboles.Remover(789012, arboles.Root);

            return View(carros);


        }

        //[Route("Controller2")]
        //public IActionResult Index()
        //{
        //    var carros = from a in DatosCarros()
        //                 orderby a.Placa
        //                 select a;


        //    return View(carros);


        //}



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
                                Placa = Convert.ToInt32(data[0]),
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
