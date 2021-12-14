using System;
using System.Collections.Generic;
using System.IO;

namespace practice_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Money amountOfMoney = new Money(first, second);

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
            Console.WriteLine("\nOutput field first: {0}", amountOfMoney.First);
            Console.WriteLine("\nAmount of money - {0}", amountOfMoney.CalculateTheMoney);

            Console.WriteLine("\nIncrease the first and second fields by overloading ++.");
            Money z = ++amountOfMoney;
            z.Show();
            z.first = 1000000;
            z.Show();
            amountOfMoney.Show();

            Console.WriteLine("\nReducing the first and second fields by overloading --.");
            amountOfMoney--;
            amountOfMoney.Show();

            Console.WriteLine("\nOverloading +. Adds a second scalar to the field.");
            amountOfMoney = amountOfMoney + 10;
            amountOfMoney.Show();

            Console.WriteLine("\nOverloading !");
            if (!amountOfMoney)
                Console.WriteLine("second != 0");
            else
                Console.WriteLine("second == 0");

            Money adds = new Money(100, 0);
            Console.WriteLine("\nOverloading !");
            if (!adds)
                Console.WriteLine("second != 0");
            else
                Console.WriteLine("second == 0");

            Money amountOfMoneySecond = new Money(-50, 2);
            amountOfMoneySecond.Show();
            amountOfMoneySecond[0] = -60;
            amountOfMoneySecond[1] = -9;
            Console.WriteLine("Output the denomination and number of banknotes.");
            amountOfMoneySecond.Show();


        }

    }
}
