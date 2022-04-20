using Lab05.Models;
namespace Lab05.Models
{
    public class Arbol23
    {
        Nodo<DataCarsModel> raiz;
        public Arbol23()
        {
            raiz = null;
        }

        //Las comparaciones se hacen con el valor de la placa
         public void Insertar(DataCarsModel newValue)
        {
            //caso 1: raiz es null
            if(raiz == null)
            {
                raiz.MinValue = newValue;
            }
            //caso 2: hay 1 solo valor en el nodo
            if (raiz.MinValue != null && raiz.MaxValue == null)
            {
                if(newValue.Placa < raiz.MinValue.Placa)
                {
                    raiz.MaxValue = raiz.MinValue;
                    raiz.MinValue = newValue;
                }
                else
                {
                    raiz.MaxValue = newValue;
                }
            }
            //caso 3: hay 2 valores en el nodo
            if (raiz.MinValue != null && raiz.MaxValue != null)
            {
                //nuevo valor es menor a los 2
                if (raiz.MinValue.Placa < newValue.Placa)
                {
                    Nodo<DataCarsModel> nuevaRaiz = new Nodo<DataCarsModel>(raiz.MinValue);
                    nuevaRaiz.subIzq = new Nodo<DataCarsModel>(newValue);
                    nuevaRaiz.subDer = new Nodo<DataCarsModel>(raiz.MaxValue);
                    raiz = nuevaRaiz;
                }
                //nuevo valor es mayor a los 2
                if (raiz.MaxValue.Placa < newValue.Placa)
                {
                    Nodo<DataCarsModel> nuevaRaiz = new Nodo<DataCarsModel>(raiz.MaxValue);
                    nuevaRaiz.subIzq = new Nodo<DataCarsModel>(raiz.MinValue);
                    nuevaRaiz.subDer = new Nodo<DataCarsModel>(newValue);
                    raiz = nuevaRaiz;
                }
                //nuevo valor es mayor al menor y menor al mayor
                if (raiz.MinValue.Placa < newValue.Placa&& newValue.Placa < raiz.MaxValue.Placa)
                {
                    Nodo<DataCarsModel> nuevaRaiz = new Nodo<DataCarsModel>(newValue);
                    nuevaRaiz.subIzq = new Nodo<DataCarsModel>(raiz.MinValue);
                    nuevaRaiz.subDer = new Nodo<DataCarsModel>(raiz.MaxValue);
                    raiz = nuevaRaiz;
                }                
            }
        }
        
    }
}
