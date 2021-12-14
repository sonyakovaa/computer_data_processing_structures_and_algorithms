using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_15
{
    class Money
    {
        public int first, second; // 1. Номинал и количество купюр
        public Money(int first, int second) // 2. Конструктор
        {
            if (first <= 0 || second <= 0)
            {
                throw new Exception("Нельзя записывать отрицательные значения.");
            }

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
            while (res >= 0)
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
                if (i == 0 && value > 0)
                {
                    first = value;
                }
                else if (i == 1 && value > 0)
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
            Money temp = new Money(x.first, x.second);
            temp.first++;
            temp.second++;

            return temp;
        }

        public static Money operator --(Money x) // 6. Перегрузка --
        {
            Money temp = new Money(x.first, x.second);
            temp.first--;
            temp.second--;

            return temp;
        }

        public static bool operator !(Money x) // 6. Перегрузка оператора !
        {
            if (x.second != 0)
                return true;
            return false;
        }

        public static Money operator +(Money x, int scalar) // 6. Перегрузка оператора +
        {
            Money temp = new Money(x.first, x.second);
            temp.second += scalar;

            return temp;
        }
    }
}
