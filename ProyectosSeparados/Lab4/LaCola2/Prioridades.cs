using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCola2
{
    public class Prioridadess<T>
    {
        public QueueNodo<T> PrioridadMaxima { get; set; }
        public int PrioridadMax { get; set; }

        public Prioridadess(int valore)
        {
            if (valore < 1)

                throw new Exception("Falta al menos un 1");
            PrioridadMax = valore;

            QueueNodo<T> NAnt = null;
            QueueNodo<T> NAct = null;
            for (int a = 1; a < PrioridadMax; a++)
            {
                NAct = new QueueNodo<T>(a);
                NAct.Siguiente = NAnt;
                NAnt = NAct;

            }
            PrioridadMaxima = NAct;


        }
        public void Encolar(T valore, int prioridad)
        {
            var raiz = PrioridadMaxima;
            if (PrioridadMaxima == null)
            {
                PrioridadMaxima = new QueueNodo<T>(prioridad);
                PrioridadMaxima.AggVal(valore);
                return;
            }
            if (prioridad > 0 && prioridad <= PrioridadMax)
            {
                for (int a = 0; a < PrioridadMax; a++)
                {
                    if (prioridad == raiz.Prioridad)
                    {
                        raiz.AggVal(valore);
                        return;
                    }
                    raiz = raiz.Siguiente;
                }
            }
            else
            {
                throw new Exception("Rango de fuera");
            }
        }
    }

}
