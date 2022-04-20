namespace Lab05.Models
{
    public class Nodo<T>
    {
        T MinValue;
        T MaxValue;
        Nodo<T> subIzq;
        Nodo<T> subMid;
        Nodo<T> subDer;
        public Nodo(T value)
        {
            MinValue = value;
        }
    }
}
