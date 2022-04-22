namespace Lab05.Models
{
    public class ADT//Arbol Dos-Tres
    {
        public class Node
        {
            public List<DataCarsModel> NodeValues;
            public Node ParentNode;
            public List<Node> ChildNodes;

            public Node(DataCarsModel newValue)
            {
                ParentNode = null;
                NodeValues.Add(newValue);
            }
            public Node(DataCarsModel newValue, Node parent)
            {
                ParentNode = parent;
                NodeValues.Add(newValue);
            }

            public void Sort()
            {
                bubbleSort(NodeValues);
            }
            void bubbleSort(List<DataCarsModel> ValuesList)
            {// sacado de geeksforgeeks
                int n = ValuesList.Count;
                bool swapped;
                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (ValuesList[j].Placa > ValuesList[j + 1].Placa)
                        {
                            var temp = ValuesList[j];
                            ValuesList[j] = ValuesList[j + 1];
                            ValuesList[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (swapped == false)
                        break;
                }
            }

            public void Insert(DataCarsModel newValue) { NodeValues.Add(newValue); Sort(); } 
        }


        Node Root;
        public ADT()
        {
            Root = null;
        }

        Node BuscarNodo(int placa, Node raiz)
        {
            for (int i = 0; i < 2; i++)
            {
                if (raiz.NodeValues[i].Placa == placa)
                {
                    return raiz;
                }
            }
            if (placa < raiz.NodeValues[0].Placa)
            {
                return BuscarNodo(placa, raiz.ChildNodes[0]);
            }
            if (raiz.NodeValues.Count == 1 && raiz.NodeValues[0].Placa < placa)
            {
                return BuscarNodo(placa, raiz.ChildNodes[2]);
            }
            if (raiz.NodeValues.Count == 2)
            {
                if (raiz.NodeValues[0].Placa < placa && placa < raiz.NodeValues[1].Placa)
                {
                    return BuscarNodo(placa, raiz.ChildNodes[1]);
                }
                else
                {
                    return BuscarNodo(placa, raiz.ChildNodes[2]);
                }
            }
            else return null;
        }
         DataCarsModel Buscar(int placa, Node raiz)
        {
            for(int i = 0; i < 2; i++)
            {
                if (raiz.NodeValues[i].Placa == placa)
                {
                    return raiz.NodeValues[i];
                }                
            }
            if(placa < raiz.NodeValues[0].Placa)
            {
                return Buscar(placa, raiz.ChildNodes[0]);
            }
            if(raiz.NodeValues.Count == 1 && raiz.NodeValues[0].Placa < placa)
            {
                return Buscar(placa, raiz.ChildNodes[2]);
            }
            if(raiz.NodeValues.Count == 2)
            {
                if(raiz.NodeValues[0].Placa < placa && placa < raiz.NodeValues[1].Placa)
                {
                    return Buscar(placa, raiz.ChildNodes[1]);
                }
                else
                {
                    return Buscar(placa, raiz.ChildNodes[2]);
                }
            }
            else return null;

        }
        public Node Insertar(DataCarsModel newValue, Node raiz)
        {
            //es nulo
            if(raiz == null)
            {
                raiz = new Node(newValue);
                return raiz;
            }
            // es nodo
            if(raiz.ChildNodes.Count != 0)
            {
                if (newValue.Placa < raiz.NodeValues[0].Placa)
                {
                    return Insertar(newValue, raiz.ChildNodes[0]);
                }
                if (raiz.NodeValues.Count == 1 && raiz.NodeValues[0].Placa < newValue.Placa)
                {
                    return Insertar(newValue, raiz.ChildNodes[2]);
                }
                if (raiz.NodeValues.Count == 2)
                {                    
                    if (raiz.NodeValues[0].Placa < newValue.Placa && newValue.Placa < raiz.NodeValues[1].Placa)
                    {
                        return Insertar(newValue, raiz.ChildNodes[1]);
                    }
                    else
                    {
                        return Insertar(newValue, raiz.ChildNodes[2]);
                    }
                }                
            }
            //es hoja
            if(raiz.ChildNodes.Count == 0)
            {
                if (raiz.NodeValues.Count == 1)
                {
                    raiz.Insert(newValue);
                    return raiz;
                }
                if (raiz.NodeValues.Count == 2)
                {
                    var temp = raiz;
                    raiz = null;
                    temp.Insert(newValue);
                    var nuevaRaiz = temp.ParentNode;
                    nuevaRaiz.Insert(temp.NodeValues[1]);
                    Insertar(temp.NodeValues[0], nuevaRaiz);
                    Insertar(temp.NodeValues[2], nuevaRaiz);                    
                    return nuevaRaiz;
                }
            }
            
            return raiz;
        }
        bool Remover(int placa, Node raiz)
        {
            


        }       
        
    }
}
