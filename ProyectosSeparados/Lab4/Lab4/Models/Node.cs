namespace Lab4.Models
{
    public class Node<T>
    {
        public T Value { get; set; }
        public int Prioridad { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, int prioridad)
        {
            Value = value;
            Prioridad = prioridad;           
        }
    }
}
