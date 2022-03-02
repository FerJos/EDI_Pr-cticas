namespace EDI_Lab3.Models
{
    public class Nodo<T>
    {
        //El valor puede ser un int, string, objeto, etc
        internal T Valor { get; set; }
        //se puede referenciar a si misma como una clase normal
        internal Nodo<T> Siguiente { get; set; }

        //Constructor
        internal Nodo(T valor)
        {
            Valor = valor;
            //explicar This aqui
            Siguiente = null;
        }
    }
}
