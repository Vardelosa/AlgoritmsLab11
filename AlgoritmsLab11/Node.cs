using System;
using System.Collections.Generic;
using System.Text;

namespace alg8
{
    class Node<T> : IComparable<Node<T>> where T : IComparable<T>
    {
        public T Item { get; set; }

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

        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node() : this(default(T))
        { }

        public Node(T item): this(item, null, null)
        { }

        public Node(T item, Node<T> left, Node<T> right)
        {
            Item = item;
            Left = left;
            Right = right;
        }

        public int CompareTo(Node<T> other)
        {
            return Item.CompareTo(other.Item);
        }

        public override string ToString()
        {
            return Item.ToString();
        }
    }
}
