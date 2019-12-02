using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab11
{
    class Node
    {
        public int Data { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Height
        {
            get
            {
                int leftHeight = Left != null ? Left.Height : 0;
                int rightHeight = Right != null ? Right.Height : 0;

                return (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
            }
        }
        public int BalanceFactor
        {
            get
            {
                int leftHeight = Left != null ? Left.Height : 0;
                int rightHeight = Right != null ? Right.Height : 0;

                return leftHeight - rightHeight;
            }
        }
        public Node() : this(default(int))
        { }

        public Node(int data) : this(data, null, null)
        { }

        public Node(int data, Node left, Node right)
        {
            Data = data;
            this.Left = left;
            this.Right = right;
        }




    }
}
