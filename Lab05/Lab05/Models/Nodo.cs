namespace Lab05.Models
{
    public class Nodo<T>
    {
        public T MinValue;
        public T MaxValue;
        public Nodo<T> subIzq;
        public Nodo<T> subMid;
        public Nodo<T> subDer;
        public Nodo(T value)
        {
            MinValue = value;
        }
    }
}
