using Lab4.Models;
using LaCola;
using Microsoft.AspNetCore.Mvc;


namespace Lab4.Controllers
{
    [Route("[controlador]")]
    public class PacienteController : Controller
    {
        public static Prioridadess<Paciente> LaCola;

        private List<Paciente> Pac = new List<Paciente>()
        {
            new Paciente(){Nombre = "Raul", Apellido = "Porres", FechaDeNacimiento = "12/04/2002", EstaSiendoAtendido=false, Sexo="Macho", Edad =18, Espec="Neumologia", Ingreso="Camilla"},
            new Paciente(){Nombre = "Sandra", Apellido = "Porres", FechaDeNacimiento = "12/04/2002", EstaSiendoAtendido=false, Sexo="Macho", Edad =30, Espec="Anato", Ingreso="Camilla"},
            new Paciente(){Nombre = "Paul", Apellido = "Porres", FechaDeNacimiento = "12/04/2002", EstaSiendoAtendido=false, Sexo="Macho", Edad =10, Espec="Link", Ingreso="Camilla"}

        };

        public PacienteController()
        {
            LaCola = new Prioridadess<Paciente>(25);
        }
        
        public Prioridadess<Paciente> Index()
        {
            int inicilzador = 0;
            foreach(var PAct in Pac)
            {
                if(PAct.Edad >= 18  && PAct.Edad <= 49)
                {
                    inicilzador = inicilzador + 3;
                }
                if (PAct.Edad >= 6 && PAct.Edad <= 17)
                {
                    inicilzador = inicilzador + 5;
                }
                LaCola.Encolar(PAct, inicilzador);
            }
            
            return LaCola;
        }
    }
}
