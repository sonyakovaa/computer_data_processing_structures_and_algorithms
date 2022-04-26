using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(@"C:\Users\sonya\source\repos\graph_1\document.txt");
            Console.WriteLine("Graph:");
            g.Show();
            Console.WriteLine();

            Console.Write("Input a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            int b = int.Parse(Console.ReadLine());

            g.addingEdge(a, b);
            g.Show();
        }
    }
}
