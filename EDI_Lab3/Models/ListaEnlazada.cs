namespace EDI_Lab3.Models
{
    public class ListaEnlazada<T> : IEstructuraDeDatos<T>
    {
        int Contador { get; set; }
        bool Vacia { get; set; }
        public Nodo<T> PrimerNodo { get; set; }
        public Nodo<T> UltimoNodo { get; set; }
        public void Actualizar(int pos)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int pos)
        {
            throw new NotImplementedException();
        }

        public void Insertar(T valor)
        {
            var nodoInsertar = new Nodo<T>(valor);
            if (Contador == 0)
            {
                PrimerNodo = nodoInsertar;
                Contador = 1;
                Vacia = false;
                UltimoNodo = nodoInsertar;

            }
            else
            {
                UltimoNodo.Siguiente = nodoInsertar;
                UltimoNodo = nodoInsertar;
                Contador++;
            }
        }

        public T Obtener(int pos)
        {
            throw new NotImplementedException();
        }
    }
}
