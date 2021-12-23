using System;
using System.Collections.Generic;
using System.IO;

namespace practice_18
{
    class Program
    {
        static public List<Transport> inputTransport()
        {
            using (StreamReader input_text = new StreamReader("C:/Users/sonya/source/repos/practice_18/practice_18/input.txt"))
            {
                List<Transport> transports = new List<Transport>();

                while (input_text.Peek() != -1)
                {
                    string[] s = input_text.ReadLine().Split(' ');

                    if (s[0] == "Car")
                    {
                        Car copy_item = new Car(s[1], s[2], int.Parse(s[3]), int.Parse(s[4]));
                        transports.Add(copy_item);
                    }

                    if (s[0] == "Bike")
                    {
                        Bike copy_item = new Bike(s[1], s[2], int.Parse(s[3]), int.Parse(s[4]), s[5]);
                        transports.Add(copy_item);
                    }

                    if (s[0] == "Truck")
                    {
                        Truck copy_item = new Truck(s[1], s[2], int.Parse(s[3]), int.Parse(s[4]), s[5]);
                        transports.Add(copy_item);
                    }
                }

                return transports;
            }
        }
        static void Main(string[] args)
        {
            List<Transport> transports = inputTransport();
            transports.Sort();

            foreach (Transport item in transports)
            {
                item.Show();
            }
        }
    }
}
