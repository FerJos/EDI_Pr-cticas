using Lab4.Models;
namespace Lab4.Models
{
    
    public class ColaDePrioridad<T>
    {
        internal class Nodo<T>
        {
            public T Value { get; set; }
            public Nodo<T> HijoIzq { get; set; }
            public Nodo<T> HijoDer { get; set; }

            internal Nodo (T value)
            {
                this.Value = value
            }
        }
        
    }
}
