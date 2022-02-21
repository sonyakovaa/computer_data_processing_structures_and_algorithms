using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            using (StreamReader file_input = new StreamReader("C:/Users/sonya/source/repos/task_21/input.txt"))
            {
                string[] text = file_input.ReadLine().Split(' ');

                for (int i = 0; i < text.Length; i++)
                {
                    tree.Add(int.Parse(text[i]));
                }
                tree.Preorder();
                Console.WriteLine();

                for (int i = 1; i < text.Length; i++)
                {
                    int res = 0;
                    tree.DepthBinaryTree(int.Parse(text[0]), int.Parse(text[i]), ref res);
                    Console.WriteLine("{0} - {1}", text[i], res);
                }
            }
        }
    }
}
