using System;
using System.Diagnostics;

namespace Practice6_4
{
    class Program
    {
        static void addColumn(int[][] matrix, int column, ref int m, int n)
        {
            ++m;

            for (int j = m - 1; j >= column + 1; j--)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i][j] = matrix[i][j - 1];
                }
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i][column] = 1111;
            }
        }
        static void outputArray(int[][] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Enter the size of the square matrix: ");
            int n = int.Parse(Console.ReadLine());
            int m = n;

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[2 * n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = random.Next(1, 10);
                }
            }

            Console.WriteLine("The entered array: ");
            outputArray(matrix, n, m);

            Console.Write("Enter the specified x: ");
            int x = int.Parse(Console.ReadLine());

            for (int j = 0; j < m; j++)
            {
                bool flag = true;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i][j] == x)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == false)
                {
                    addColumn(matrix, j, ref m, n);
                    j++;
                }
            }

            Console.WriteLine("Modified array: ");
            outputArray(matrix, n, m);
        }
    }
}
