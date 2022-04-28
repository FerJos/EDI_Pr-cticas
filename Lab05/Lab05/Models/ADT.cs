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
                NodeValues = new List<DataCarsModel>();
                ChildNodes = new List<Node>();
                NodeValues.Add(newValue);
            }
            public Node(DataCarsModel newValue, Node parent)
            {
                ParentNode = parent;
                NodeValues = new List<DataCarsModel>();
                ChildNodes = new List<Node>();
                NodeValues.Add(newValue);
            }
            public Node()
            {
                ParentNode = null;
                NodeValues = new List<DataCarsModel>();
                ChildNodes = new List<Node>();
               
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


       public Node Root;
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
         public DataCarsModel Buscar(int placa, Node raiz)
        {
            for(int i = 0; i < raiz.NodeValues.Count-1; i++)
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
        public Node Insertar2(DataCarsModel newValue, DataCarsModel newValues2, Node raiz) {
            for (int i = 0; i < 3; i++)
            {
                raiz.ChildNodes.Add(new Node());

}
            raiz.ChildNodes[0].Insert(newValue);
            raiz.ChildNodes[2].Insert(newValues2);
            return raiz;
        }
            
        public Node Insertar(DataCarsModel newValue, Node raiz)
        {
            //es nulo
            if(raiz == null)
            {
                raiz = new Node(newValue);
                Root = raiz;
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
                    Root = raiz;
                    return raiz;
                }
                if (raiz.NodeValues.Count == 2)
                {
                    var temp = raiz;
                    raiz = null;
                    temp.Insert(newValue);
                    var nuevaRaiz = temp.ParentNode;
                    if(nuevaRaiz == null)
                    {
                        nuevaRaiz = new Node(temp.NodeValues[1]);
                    }

                    Insertar2(temp.NodeValues[0], temp.NodeValues[2], nuevaRaiz);
                    Root = nuevaRaiz;
                    return nuevaRaiz;
                }
            }
            
            return raiz;
        }
        //Para el valor mas a la izquierda 
        //Node masderecha(Node raiz, int placa)
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        if (raiz == null)
        //        {
        //            return null;
        //        }
        //       if ( raiz.NodeValues[1].Placa == placa)
        //        {
        //            return masderecha(raiz.ChildNodes[1], placa);
        //        }
        //        else if (raiz.NodeValues[0].Placa == placa)
        //        {
        //            return masderecha(raiz.ChildNodes[1], placa);
        //        }
        //    }
        //    return raiz;
        //}
        //Eliminar
        public Node Remover(int placa, Node raiz)
        {
            //No hay elementos
            if (raiz == null)
            {
                return null ;
            }
            for (int i = 0; i < 1; i++)
            {
                if (raiz.NodeValues[0].Placa == placa) //Si eliminamos padre izquierdo  
                {

                    raiz.NodeValues.Remove(raiz.NodeValues[0]);
                }
                else if (raiz.NodeValues[1].Placa == placa) //Si elminamos padre derecho
                {
                    raiz.NodeValues.Remove(raiz.NodeValues[1]);
                }
            }

                //Si tiene dos valores el padre
             
           
            //if (raiz.ChildNodes[0] != null && raiz.ChildNodes[1] == null) //Si elminamos hijo izquierdo
            //{
            //    menor = masderecha(raiz.ChildNodes[1], placa);
            //    raiz = menor;
            //    return (menor);
            //}
            //else if (raiz.ChildNodes[0] == null && raiz.ChildNodes[1] != null) //Si elminamos hijo derecho
            //{
            //    menor = masderecha(raiz.ChildNodes[1], placa);
            //    raiz = menor;
            //    return (menor);
            //}
            //else
            {
                return raiz;
            }
           
        }       
        
    }
}
