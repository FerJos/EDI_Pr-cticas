using Lab4.Models;
namespace Lab4.Models
{

    public class ColaDePrioridad<T>
    {
        public Node<T> MaxPrioNode { get; set; }
        public int MaxPrio { get; set; }
        public ColaDePrioridad(int n)
        {
            if (n < 1)
                throw new Exception("La maxima prioridad debe ser mayor a 0");
            
            MaxPrio = n;

            Node<T> NodoAnterior = null;
            Node<T> NodoActual = null;
            for(int i = 1; i <= MaxPrio; i++)
            {
                NodoActual = new Node<T>(i);
                NodoActual.Next = NodoAnterior;
                NodoAnterior = NodoActual;
            }
            MaxPrioNode = NodoActual;
        }
        public void Enqueue(T value, int prio)
        {
            Node<T> root = MaxPrioNode;
            if (MaxPrioNode == null)
            { 
                MaxPrioNode = new Node<T>(prio);
                MaxPrioNode.AddValue(value);
                return;
            }
            if (prio > 0 && prio  <= MaxPrio)
            {
                for(int i = 0; i <MaxPrio; i++)
                {
                    if (prio == root.Prioridad)
                    {
                        root.AddValue(value);
                        return;
                    }
                    root = root.Next;
                }
            }
            else
            {
                throw new Exception("Prioridad fuera de rango");
            }
        }

        public void Add(Node<T> newNode)
        {
            if (newNode.Prioridad > 0 && newNode.Prioridad <= MaxPrio)
            {
                if (MaxPrioNode == null)
                {
                    MaxPrioNode = newNode;
                    return;
                }
                if (MaxPrioNode.Prioridad < newNode.Prioridad)
                {
                    newNode.Next = MaxPrioNode;
                    MaxPrioNode = newNode;
                    return;
                }
                if(MaxPrioNode.Prioridad > MaxPrio)
                {
                    Node<T> temp = MaxPrioNode;
                    while (temp != null)
                    {
                        if(temp.Prioridad < newNode.Prioridad)
                        {
                            newNode.Next = temp;
                            temp = newNode;
                        }
                    }
                }
            }
        }


    }
}
