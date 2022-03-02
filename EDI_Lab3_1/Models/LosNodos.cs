namespace EDI_Lab3_1.Models
   
{
    public class LosNodos
    {

        public string ID { get; set; }
        public string email { get; set; }
        public string propietario { get; set; }
        public string color { get; set; }
        public string marca { get; set; }
        public string serie { get; set; }
    }
       public class Nodo

        {
            private int dato;
            private Nodo derecha;
            private Nodo izquierda;


            Nodo crearNodo(int n)
            {
                Nodo newNodo = new Nodo();
                newNodo.dato = n;
                newNodo.derecha = null;
                newNodo.izquierda = null;

                return newNodo;

            }
            void insertarNodo(Nodo arbol, int n)
            {
                if (arbol == null)
                {
                    Nodo newNodo = crearNodo(n);
                    arbol = newNodo;
                }
                else
                {
                    int raiz = arbol.dato;
                    if (n < raiz)
                    {
                        insertarNodo(arbol.izquierda, n);
                    }
                    else
                    {
                        insertarNodo(arbol.derecha, n);
                    }
                }
            }
        }

        



    
}
