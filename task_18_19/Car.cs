using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_18
{
    class Car : Transport
    {
        public Car(string number, string brand, int speed, int capacity)
        {
            this.number = number;
            this.brand = brand;
            this.speed = speed;
            this.capacity = capacity;
        }

        public override void Show()
        {
            Console.WriteLine("Brand - {0}, number - {1}, speed - {2}, capacity - {3}", brand, number, speed, capacity);
        }

        public override int determineCapacity()
        {
            return capacity;
        }
    }
}
