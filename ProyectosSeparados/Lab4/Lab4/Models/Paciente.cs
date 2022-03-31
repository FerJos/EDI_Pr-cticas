namespace Lab4.Models
{
    public class Paciente
    {
        //Datos de paciente
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public bool EstaSiendoAtendido { get; set; }

        //Datod de priorizacion
        public string Sexo { get; set; }
        //Masculino: +3
        //Femenino: +5

        public int Edad { get; set; }
        //70+: +10
        //50-69: +8
        //18-49: +3
        //0-5: +8
        //6-17: +5

        public string Espec { get; set; }
        //Traumatología(interna): +3
        //Traumatología(expuesta): +8
        //Ginecología: +5
        //Cardiología: +10
        //Neumología: +8

        public string MetodoIngreso { get; set; }
        //Ambulancia: +5
        //Asistido: +3

        int CalcularPrioridad(string sexo, int edad, string spec, string ingreso)
        {
            return -1;
        }
    }
}
