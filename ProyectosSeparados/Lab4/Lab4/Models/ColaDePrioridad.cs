using Lab4.Models;
namespace Lab4.Models
{

    public class ColaDePrioridad<T>
    {
        public Node<T> Root { get; set; }
        public int MaxPrio { get; set; }
        public ColaDePrioridad(int n)
        {
            if (n < 1)
                throw new Exception("La maxima prioridad debe ser mayor a 0");
            
            MaxPrio = n;
        }
        public void Add(Node<T> newNode)
        {
            if (newNode.Prioridad > 0 && newNode.Prioridad <= MaxPrio)
            {
                if (Root == null)
                {
                    Root = newNode;
                    return;
                }
                if (Root.Prioridad < newNode.Prioridad)
                {
                    newNode.Next = Root;
                    Root = newNode;
                    return;
                }
                if(Root.Prioridad > MaxPrio)
                {
                    Node<T> temp = Root;
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
