using EDI_Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDI_Lab3.Controllers
{
    [Route("[controller]")]
    public class PersonasController : Controller
    {
        //Lista Global desde archivo
        List<Persona> personaList = new List<Persona>();
        public IActionResult Index()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Persona { Id = 1, Name = "Paola"},
                new Persona { Id = 2, Name = "Alex"},
                new Persona { Id = 3, Name = "Maria"}
            };
            return View(personas);
        }
        [Route("SubirArchivo")]
        public IActionResult SubirArchivos()
        {
            return View();
        }

        [HttpPost("SubirArchivo")]
        public IActionResult SubirArchivos(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    // Subir archivo a una carpeta temporal
                    string ruta = Path.Combine(Path.GetTempPath(), file.Name);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    //Leer Archivo
                    string allFileData = System.IO.File.ReadAllText(ruta);
                    //Recorrer Archivo
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion = lineaActual.Split(',');

                            //var personaActual = new Persona();
                            //personaActual.Id = Convert.ToInt32( informacion[0]);
                            //personaActual.Name = informacion[1];
                            //personaList.Add(personaActual);

                            //Guardar informacion
                            personaList.Add(new Persona()
                            {
                                Id = Convert.ToInt32(informacion[0]),
                                Name = informacion[1]
                            });
                        }
                    }

                }
                catch (Exception e)
                {

                    ViewBag.Error = e.Message;
                }
            }
            return View(personaList);
        }
    }
}
