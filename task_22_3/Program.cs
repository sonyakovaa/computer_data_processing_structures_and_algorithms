using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph_1
{
    struct SPoint //описание структуры
    {
        public int x, y; //поля структуры
        public SPoint(int x, int y) //конструктор структуры
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(@"C:\Users\sonya\source\repos\graph_1\document.txt");
            Console.WriteLine("Graph:");
            g.Show();

            int sizeGraph = g.graphSize();
            Console.Write("Enter A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter B: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter towns: ");
            string line = Console.ReadLine();
            List<String> towns = line.Split().ToList();

            g.Dijkstr(a, b, towns);

        }
    }
}
