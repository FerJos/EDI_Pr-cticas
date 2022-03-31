using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    [Route("[controller]")]
    public class PacienteController : Controller
    {
        public static ColaDePrioridad<Paciente> ColaPrio;
        public PacienteController()
        {
            ColaPrio = new ColaDePrioridad<Paciente>(10);
        }
        //TEST
        private List<Paciente> TESTColaPrio = new List<Paciente>() 
        { 
            new Paciente(){Nombre = "Raul", Apellido="Porres", Edad=18, Espec="Neumologia"},
            new Paciente(){Nombre = "Maria", Apellido="Gonzales", Edad=15, Espec="Cardiologia"}
        };
        public ColaDePrioridad<Paciente> Index()
        {
            
            foreach(var PacienteActual in TESTColaPrio)
            {
                int prioridad = 0;
                //Edad
                if (PacienteActual.Edad >= 70)
                {
                    prioridad = prioridad + 10;
                }
                if (PacienteActual.Edad >= 50 && PacienteActual.Edad <= 69)
                {
                    prioridad = prioridad + 8;
                }
                if (PacienteActual.Edad >= 18 && PacienteActual.Edad <= 49)
                {
                    prioridad = prioridad + 3;
                }
                if (PacienteActual.Edad >= 6 && PacienteActual.Edad <= 17)
                {
                    prioridad = prioridad + 5;
                }
                if (PacienteActual.Edad >= 0 && PacienteActual.Edad <= 5)
                {
                    prioridad = prioridad + 8;
                }
                //Sexo
                if (PacienteActual.Sexo == "Masculino")
                {
                    prioridad = prioridad + 3;
                }
                if (PacienteActual.Sexo == "Femenino")
                {
                    prioridad = prioridad + 5;
                }
                //Especializacion
                if (PacienteActual.Espec == "Traumatología(interna)")
                {
                    prioridad = prioridad + 3;
                }
                if (PacienteActual.Espec == "Traumatología(expuesta)")
                {
                    prioridad = prioridad + 8;
                }
                if (PacienteActual.Espec == "Ginecología")
                {
                    prioridad = prioridad + 5;
                }
                if (PacienteActual.Espec == "Cardiología")
                {
                    prioridad = prioridad + 10;
                }
                if (PacienteActual.Espec == "Neumología")
                {
                    prioridad = prioridad + 8;
                }
                //Metodo de ingreso
                if (PacienteActual.MetodoIngreso == "Ambulancia")
                {
                    prioridad = prioridad + 5;
                }
                if (PacienteActual.MetodoIngreso == "Asistido")
                {
                    prioridad = prioridad + 3;
                }
                ColaPrio.Enqueue(PacienteActual, prioridad);
            }
            return ColaPrio;
        }
    }
}
