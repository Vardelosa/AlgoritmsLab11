using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab11
{
    class AVLTree
    {
        Node Root;

        public int count;

        private Node RotateRight(Node root)
        {
            Node left = root.Left;

            root.Left = left.Right;
            left.Right = root;

            return left;
        }
        private Node RotateLeft(Node root)
        {
            Node right = root.Right;

            root.Right = right.Left;
            right.Left = root;

            return right;
        }
        private Node Balance(Node root)
        {
            if (root.BalanceFactor == -2)
            {
                if (root.Right.BalanceFactor > 0)
                {
                    root.Right = RotateRight(root.Right);
                }

                return RotateLeft(root);
            }

            if (root.BalanceFactor == 2)
            {
                if (root.Left.BalanceFactor < 0)
                {
                    root.Left = RotateLeft(root.Left);
                }

                return RotateRight(root);
            }

            return root;
        }
        public void Add(int value)
        {
            if (Root == null)
                Root = new Node(value);

            else
                StepAdd(Root, value);

            count++;
        }
        public void StepAdd(Node node, int value)
        {
            if (value < node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    StepAdd(node.Left, value);
                }
            }
            if (value > node.Data)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    StepAdd(node.Right, value);
                }
            }
        }
        public bool Contains(int value)
        {
            Node parent;

            return Find(value, out parent) != null;
        }
        private Node Find(int value, out Node parent)
        {
            Node current = Root;

            parent = null;

            while (current != null)
            {
                if (current.Data > value)//Если искомое меньше
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.Data < value)//Если искомое больше
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }
        public bool Delete(int value)
        {
            Node current, parent;

            current = Find(value, out parent);

            if (current == null)
                return false;

            count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = current.Left;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = current.Right;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node leftmost = current.Right.Left;
                Node leftmostparent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostparent = leftmost;
                    leftmost = leftmost.Left;
                }
                leftmostparent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    Root = current.Left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = leftmost;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        public void PryamoiObhodFind(int element)
        {
            Steps = 0;
            PryamoiObhodFind(element, Root);
        }
        int Steps;
        private void PryamoiObhodFind(int element, Node node)
        {
            if (node != null)
            {
                if (element == node.Data)
                {
                    Console.WriteLine($"Element '{node.Data}' has been found. Steps was made: {Steps}");
                }
                Steps++;
                PryamoiObhodFind(element, node.Left);
                PryamoiObhodFind(element, node.Right);
            }
        }
        public void ObratniyObhodFind(int element)
        {
            Steps = 0;
            ObratniyObhodFind(element, Root);
        }

        private void ObratniyObhodFind(int element, Node node)
        {
            if (node != null)
            {
                ObratniyObhodFind(element, node.Left);
                ObratniyObhodFind(element, node.Right);
                if (element == node.Data)
                {
                    Console.WriteLine($"Element '{node.Data}' has been found. Steps was made: {Steps}");
                }
                Steps++;
            }
        }
        public void FindTheWayPryamoi()
        {
            Steps = 0;
            FindTheWayPryamoi(Root);
        }
        private void FindTheWayPryamoi(Node node)
        {
            if (node != null)
            {
                if (node.Right == null & node.Left == null)
                {
                    Console.WriteLine("The way: {0}", Steps);
                    Steps = 0;
                }
                Steps++;
                FindTheWayPryamoi(node.Left);
                FindTheWayPryamoi(node.Right);
            }
        }
        public void FindTheWayObratniy()
        {
            Steps = 0;
            FindTheWayObratniy(Root);
        }
        private void FindTheWayObratniy(Node node)
        {
            if (node != null)
            {
                FindTheWayObratniy(node.Left);
                FindTheWayObratniy(node.Right);
                if (node.Right == null & node.Left == null)
                {
                    Console.WriteLine("The way: {0}", Steps);
                    Steps = 0;
                }
                Steps++;
                
            }
        }
    }
}
