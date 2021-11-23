using System;
using System.IO;

namespace practice_14_1
{
    struct SPoint
    {
        public int x, y, z;
        public SPoint(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double Distance()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }        
    }
    class Program
    {
        static public double minDistance(SPoint[] arrPoints)
        {
            double minD = Double.MaxValue;

            foreach (SPoint item in arrPoints)
            {
                if (minD > item.Distance())
                {
                    minD = item.Distance();
                }
            }

            return minD;
        }

        static public void FindMin(SPoint[] arrPoints, double minD)
        {
            foreach (SPoint item in arrPoints)
            {
                if (minD == item.Distance())
                {
                    Console.WriteLine(item.x + " " + item.y + " " + item.z);
                }
            }
        }
        static public SPoint[] inputSPoint()
        {
            using (StreamReader fileIn = new StreamReader("C:/Users/sonya/source/repos/practice_14_1/practice_14_1/task.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                SPoint[] arrayStruct = new SPoint[n];
                for (int i = 0; i < n; i++)
                {
                    string[] text = fileIn.ReadLine().Split(' ');
                    arrayStruct[i] = new SPoint(int.Parse(text[0]), int.Parse(text[1]), int.Parse(text[2]));

                }

                return arrayStruct;
            }

        }
        static void Main(string[] args)
        {
            SPoint[] arr = inputSPoint();
            double minD = minDistance(arr);

            FindMin(arr, minD);
        }
    }
}
