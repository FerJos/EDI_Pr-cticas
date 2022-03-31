namespace Lab4.Models
{
    public class Paciente
    {
        //Datos de paciente
        public string Nombre { get; set; }
        public string Apellido { get; set; }
<<<<<<< HEAD
        public string FechaDeNacimiento { get; set; }

=======
        public DateTime FechaDeNacimiento { get; set; }
>>>>>>> origin
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

<<<<<<< HEAD
        public string Ingreso { get; set; }
        //Ambulancia: +5
        //Asistido: +3

        //public Paciente(string n, string a, string fdn, string s,  int e, string sp, string i)
        //{
        //    this.Nombre = n;
        //    this.Apellido = a;
        //    this.FechaDeNacimiento = fdn;
        //    this.Sexo = s;
        //    this.Edad = e;
        //    this.Espec = sp;
        //    this.Ingreso = i;
        //    this.EstaSiendoAtendido = false;
        //}

        //int CalcularPrioridad(string sexo, int edad, string spec, string ingreso)
        //{
        //    return -1;
        //}
=======
        public string MetodoIngreso { get; set; }
        //Ambulancia: +5
        //Asistido: +3

        int CalcularPrioridad(string sexo, int edad, string spec, string ingreso)
        {
            return -1;
        }
>>>>>>> origin
    }
}
