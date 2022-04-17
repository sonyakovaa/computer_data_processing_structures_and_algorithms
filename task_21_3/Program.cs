using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_21_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            BinaryTree treeDelete = new BinaryTree();
            using (StreamReader file_input = new StreamReader("C:/Users/sonya/source/repos/task_21/input.txt"))
            {
                string[] text = file_input.ReadLine().Split(' ');

                for (int i = 0; i < text.Length; i++)
                {
                    tree.Add(int.Parse(text[i]));
                }
                tree.Preorder();
                tree.outputInformation();
            }
        }
    }
}
