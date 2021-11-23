using System;
using System.IO;
using System.Collections.Generic;

namespace practice
{
    struct Car : IComparable<Car>
    {
        public string brand, number, surname;
        public int year, mileage;
        public Car(string brand, string number, string surname, int year, int mileage)
        {
            this.brand = brand;
            this.number = number;
            this.surname = surname;
            this.year = year;
            this.mileage = mileage;
        }

        public string Show()
        {
            string s = brand + " " + number + " " + surname + " " + year.ToString() + " " + mileage.ToString();
            return s;
        }

        public int CompareTo(Car objectCar) // сравнение элементов по возрастанию
        {
            if (this.mileage == objectCar.mileage)
            {
                return 0;
            }
            else
            {
                if (this.mileage < objectCar.mileage)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

        }
    }
    class Program
    {
        static public Car[] inputCars()
        {
            using(StreamReader fileIn = new StreamReader("C:/Users/sonya/source/repos/practice/practice/task.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                Car[] arrayStruct = new Car[n];
                for (int i = 0; i < n; i++)
                {
                    string[] text = fileIn.ReadLine().Split(' ');
                    arrayStruct[i] = new Car(text[0], text[1], text[2], int.Parse(text[3]), int.Parse(text[4]));

                }

                return arrayStruct;
            }
        }
        static void Main(string[] args)
        {
            Car[] arr = inputCars();
            int year_car = int.Parse(Console.ReadLine());
            Array.Sort(arr);

            using (StreamWriter fileOut = new StreamWriter("C:/Users/sonya/source/repos/practice/practice/task_output.txt"))
            {
                List<Car> car_output = new List<Car>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].year < year_car)
                    {
                        car_output.Add(arr[i]);
                    }
                }

                foreach (Car item in car_output)
                {
                    fileOut.WriteLine(item.Show());
                }
            }
        }
    }
}