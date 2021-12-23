using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_18
{
    class Bike : Car
    {
        protected string pram_availability;
        public Bike(string number, string brand, int speed, int capacity, string pram_availability) : base(number, brand, speed, capacity)
        {
            this.pram_availability = pram_availability;

            if (pram_availability == "NO")
            {
                this.capacity = 0;
            }
        }

        public override void Show()
        {
            Console.WriteLine("Brand - {0}, number - {1}, speed - {2}, capacity - {3}, pram availability - {4}", brand, number, speed, capacity, pram_availability);
        }

        public override int determineCapacity()
        {
            return capacity;
        }
    }
}
