using System;
using System.Collections.Generic;
using System.IO;

namespace practice_17
{
    class Money
    {
        public int first, second; // 1. Номинал и количество купюр
        public Money(int first, int second) // 2. Конструктор
        {
            this.first = first;
            this.second = second;
        }

        public void Show() // 3. Вывести номинал и количество купюр
        {
            Console.WriteLine("Nominal value - {0}, quantity - {1}", first, second);
        }

        public string ByTheProduct(int n)
        { // 3. Хватит ли средств на покупку товара стоимостью N
            if (n <= (first * second))
                return "Can buy";
            else
                return "Can't buy";
        }

        public int ProductQuantity(int n) // 3. Сколько можно купить
        { // товара на деньги
            int count = 0;
            int res = (first * second) - n;
            while (res > 0)
            {
                count++;
                res -= n;
            }

            return count;
        }

        public int First // 4. Получить-установить зн-е поля
        {
            get { return first; }
            set { first = value; }
        }

        public int Second // 4. Получить-установить зн-е поля
        {
            get { return second; }
            set { second = value; }
        }

        public int CalculateTheMoney // 4. Свойство - рассчитать сумму денег
        {
            get { return first * second; }
        }

        public int this[int i] // 5. Индексатор
        {
            get
            {
                if (i == 0)
                {
                    return first;
                }
                else if (i == 1)
                {
                    return second;
                }
                else
                {
                    Console.WriteLine("Unacceptable index.");
                    return 0;
                }
            }
            set
            {
                if (i == 0)
                {
                    first = value;
                }
                else if (i == 1)
                {
                    second = value;
                }
                else
                {
                    Console.WriteLine("Unacceptable index.");
                }
            }
        }

        public static Money operator ++(Money x) // 6. Перегрузка ++
        {
            x.first++;
            x.second++;

            return x;
        }

        public static Money operator --(Money x) // 6. Перегрузка --
        {
            x.first--;
            x.second--;

            return x;
        }

        public static bool operator !(Money x) // 6. Перегрузка оператора !
        {
            if (x.second != 0)
                return true;
            return false;
        }

        public static int operator +(Money x, int scalar) // 6. Перегрузка оператора +
        {
            return x.second + scalar;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file_input = new StreamReader("C:/Users/sonya/source/repos/practice_15/practice_15/input.txt"))
            {
                string[] s = file_input.ReadLine().Split(' ');
                Money amountOfMoney = new Money(int.Parse(s[0]), int.Parse(s[1]));

                Console.WriteLine("Output the denomination and number of banknotes.");
                amountOfMoney.Show();

                Console.Write("\nEnter the amount of the item: ");
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLine(amountOfMoney.ByTheProduct(amount));

                Console.Write("\nEnter the cost of the item: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("You can buy {0} pieces of this product.", amountOfMoney.ProductQuantity(price));

                // Свойство set для поля first
                amountOfMoney.First = 500;
                Console.WriteLine("\nOutput field second: {0}", amountOfMoney.Second);
                Console.WriteLine("\nAmount of money - {0}", amountOfMoney.CalculateTheMoney);

                Console.WriteLine("\nIncrease the first and second fields by overloading ++.");
                amountOfMoney++;
                amountOfMoney.Show();

                Console.WriteLine("\nReducing the first and second fields by overloading --.");
                amountOfMoney--;
                amountOfMoney.Show();

                Console.WriteLine("\nOverloading +. Adds a second scalar to the field.");
                amountOfMoney.Second = amountOfMoney.Second + 10;
                amountOfMoney.Show();

                Console.WriteLine("\nOverloading !");
                if(!amountOfMoney)
                    Console.WriteLine("second != 0");
                else
                    Console.WriteLine("second == 0");

                Money adds = new Money(100, 0);
                Console.WriteLine("\nOverloading !");
                if (!adds)
                    Console.WriteLine("second != 0");
                else
                    Console.WriteLine("second == 0");

            }

        }
    }
}
