using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProyect
{
    internal class TreeAVL<T> where T : IComparable
    {
        public int Height { get; set; }
        public TreeAVL<T> SubTree_Right { get; set; }
        public TreeAVL<T> SubTree_Left { get; set; }

        //public T Value

        public TreeAVL() { }

        public TreeAVL(TreeAVL<T> right = null, TreeAVL<T> left = null)
        {
            SubTree_Right = right;
            SubTree_Left = left;

            /*Value = value,
             * Nodo.Value = Value
            */
        }

        public int GetHeight(TreeAVL<T> subTree)
        {
            if (subTree == null)
                return -1;
            else
                return 0;   //return subTree.Height;
        }

        public void UpdateHeight(TreeAVL<T> subTree)
        {
            if (subTree != null)
            {
                if(subTree.SubTree_Right.Height > subTree.SubTree_Left.Height)
                    Height = subTree.SubTree_Right.Height + 1;
                else
                    Height = subTree.SubTree_Left.Height + 1;
            }
        }
    }
}
