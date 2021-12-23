using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_18
{
    class Truck : Car
    {
        protected string trailer_availability;
        public Truck(string number, string brand, int speed, int capacity, string trailer_availability) : base(number, brand, speed, capacity)
        {
            this.trailer_availability = trailer_availability;

            if (trailer_availability == "YES")
            {
                this.capacity = capacity * 2;
            }
        }
        public override void Show()
        {
            Console.WriteLine("Brand - {0}, number - {1}, speed - {2}, capacity - {3}, trailer availabilityy - {4}", brand, number, speed, capacity, trailer_availability);
        }

        public override int determineCapacity()
        {
            return capacity;
        }
    }
}
