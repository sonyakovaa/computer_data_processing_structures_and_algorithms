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

            int sizeGraph = g.graphSize();
            for (int i = 0; i < sizeGraph; i++)
            {
                g.Dijkstr(i);
            }
        }
    }
}
