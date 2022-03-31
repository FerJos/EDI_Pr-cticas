namespace Lab4.Models
{
    public class Node<T>
    {
        //Propiedades
        public T Value { get; set; }
        public int Prioridad { get; set; }
        public Node<T> Next { get; set; }
        public Node(int prioridad)
        {
            InternalList = new List<T>();
            Prioridad = prioridad;
        }
        public Node(T value, int prioridad)
        {
            InternalList = new List<T>();
            Value = value;
            Prioridad = prioridad;           
        }

        //lista
        private List<T> InternalList { get; set; }

        //Metodos
        public void AddValue(T value)
        {
            InternalList.Add(value);
        }
        public T GetNextValue()
        {
            var returnValue = InternalList[InternalList.Count - 1];
            InternalList.RemoveAt(InternalList.Count - 1);
            return returnValue;
        }
        public T PeekNextValue()
        {
            return InternalList[InternalList.Count - 1];
        }
    }
}
