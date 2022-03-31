using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCola
{
    public class QueueNodo<T>
    {
        public T Val;
        public int Prioridad { get; set; }
        public QueueNodo<T> Siguiente { get; set; }

        private List<T> ListaInterna { get; set; }

        public QueueNodo(int prioridad)
        {
            ListaInterna = new List<T>();
            Prioridad = prioridad;
        }

        public QueueNodo(T val, int prioridad)
        {
            ListaInterna = new List<T>();
            Val = val;
            Prioridad = prioridad;
        }    
        public void AggVal(T val)
        {
            ListaInterna.Add(val);
        }
        public T ObtenerValorSiguiente()
        {
            var retornarVal = ListaInterna[ListaInterna.Count -1];
            ListaInterna.RemoveAt(ListaInterna.Count - 1);
            return retornarVal;

        }
        public T TomarValor()
        {
            return ListaInterna[ListaInterna.Count - 1];
        }

    }
}
