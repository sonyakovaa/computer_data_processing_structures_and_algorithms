using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace practice_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());

            using (StreamReader file_input = new StreamReader("C:/Users/sonya/source/repos/practice_15/practice_15/input.txt"))
            {
                string[] text = file_input.ReadLine().Split(' ');
                List<int> numbers = new List<int>();

                for (int i = 0; i < text.Length; i++)
                {
                    numbers.Add(int.Parse(text[i]));
                }

                // LINQ-запрос
                /* var sortedNumbers =
                    from n in numbers
                    where n < a || n > b
                    orderby n descending
                    select n;
                */

                // Метод расширений
                var sortedNumbers = numbers.Where(n => (n < a || n > b)).OrderByDescending(n => n).Select(n => n);

                foreach (var item in sortedNumbers)
                {
                    Console.Write(item + " ");
                }

            }
        }
    }
}
