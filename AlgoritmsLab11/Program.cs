using System;

namespace alg8
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            tree.Add(4);
            tree.Add(5);
            //tree.Add(3);
            //tree.Add(4);

            Console.Clear();
            ConsoleKey key = ConsoleKey.Z;

            do
            {
                Console.Clear();
                Console.WriteLine("Please, choise the action:\n" +
                    "Press \"A\" - to add an element to the tree\n" +
                    "Press \"D\" - to delete an element from the tree\n" +
                    "Press \"S\" - to show the tree\n" +
                    "Press \"E\" - to exit\n");

                key = Console.ReadKey().Key;
                Console.Write("\b \b");

                switch (key)
                {
                    case ConsoleKey.E:
                        break;

                    case ConsoleKey.A:
                        AddElementTo(tree);
                        break;

                    case ConsoleKey.D:
                        DeleteElement(tree);
                        break;

                    case ConsoleKey.S:
                        ShowTree(tree);
                        break;

                }
            } while (key != ConsoleKey.E);

            Console.Clear();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void ShowTree(AVLTree<int> tree)
        {
            Console.Clear();

            Console.WriteLine(tree);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void AddElementTo(AVLTree<int> tree)
        {
            Console.Clear();

            Console.Write("Enter an element: ");
            int addElement = Convert.ToInt32(Console.ReadLine());

            tree.Add(addElement);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void DeleteElement(AVLTree<int> tree)
        {
            Console.Clear();

            Console.Write("Enter an element: ");
            int deleteElement = Convert.ToInt32(Console.ReadLine());

            tree.Remove(deleteElement);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
