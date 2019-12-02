using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            tree.Add(5);
            tree.Add(32);
            tree.Add(17);
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.PryamoiObhodFind(17);
            tree.FindTheWayPryamoi();
            tree.FindTheWayObratniy();
            Console.ReadKey();
        }
    }
}
