namespace EDI_Lab3.Models
{
    public interface IEstructuraDeDatos<T>
    {
        void Insertar(T valor);
        void Actualizar(int pos);
        void Eliminar(int pos);
        T Obtener(int pos);
    }
}
