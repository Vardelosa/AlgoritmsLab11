using System;
using System.Collections.Generic;
using System.Text;

namespace alg8
{
    class AVLTree<T> where T: IComparable<T>
    {
        private Node<T> Root { get; set; }

        private Node<T> RotateRight(Node<T> root)
        {
            Node<T> left = root.Left;

            root.Left = left.Right;
            left.Right = root;

            return left;
        }

        private Node<T> RotateLeft(Node<T> root)
        {
            Node<T> right = root.Right;

            root.Right = right.Left;
            right.Left = root;

            return right;
        }

        private Node<T> Balance(Node<T> root)
        {
            if (root.BalanceFactor == -2)
            {
                if (root.Right.BalanceFactor > 0)
                {
                    root.Right = RotateRight(root.Right);
                }

                return RotateLeft(root);
            }

            if(root.BalanceFactor == 2)
            {
                if(root.Left.BalanceFactor < 0)
                {
                    root.Left = RotateLeft(root.Left);
                }

                return RotateRight(root);
            }

            return root;
        }

        public void Add(T item)
        {
            Root = InsertNode(Root, item);
        }

        public void Remove(T item)
        {
            Root = RemoveNode(Root, item);
        }

        private Node<T> RemoveNode(Node<T> root, T item)
        {
            if (root == null)
                return null;

            if (item.CompareTo(root.Item) == -1)
                root.Left = RemoveNode(root.Left, item);
            else if (item.CompareTo(root.Item) == 1)
                root.Right = RemoveNode(root.Right, item);
            else
            {
                if (root.Right == null)
                    return root.Left;

                if (root.Left == null)
                    return root.Right;

                Node<T> rightMinimum = FindMinimum(root.Right);
                rightMinimum.Right = RemoveNode(root.Right, rightMinimum.Item);
                rightMinimum.Left = root.Left;

                return Balance(rightMinimum);
            }

            return Balance(root);
        }

        private Node<T> InsertNode(Node<T> root, T item)
        {
            if (root == null)
                return new Node<T>(item);

            if (item.CompareTo(root.Item) == -1)
            {
                root.Left = InsertNode(root.Left, item);
            }
            else if (item.CompareTo(root.Item) == 1)
            {
                root.Right = InsertNode(root.Right, item);
            }

            return Balance(root);
        }

        private Node<T> FindMinimum(Node<T> root)
        {
            return root.Left != null ? FindMinimum(root.Left) : root;
        }

        private Node<T> Search(T item, Node<T> node)
        {
            if (node == null || item.CompareTo(node.Item) == 0)
                return node;

            if (item.CompareTo(node.Item) == - 1)
                return Search(item, node.Left);
            else
                return Search(item, node.Right);
        }
        private void Traverse(Node<T> node, ref string info, int n = 0)
        {
            if (node == null)
                return;

            Traverse(node.Right, ref info, n + 5);

            string temp = "";
            for (int i = 0; i < n; ++i)
                temp += " ";
            info += temp + node + "\n";

            Traverse(node.Left, ref info, n + 5);
        }

        public override string ToString()
        {
            string info = "";
            Traverse(Root, ref info);

            return info;
        }
    }
}
