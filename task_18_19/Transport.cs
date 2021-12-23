using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_18
{
    abstract class Transport : IComparable<Transport>
    {
        protected string number;
        protected string brand;
        protected int speed;
        protected int capacity;

        public abstract void Show();
        public abstract int determineCapacity();

        public int CompareTo(Transport obj)
        {
            if (this.determineCapacity() == obj.determineCapacity())
            {
                return 0;
            }
            else
            {
                if (this.determineCapacity() > obj.determineCapacity())
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
}
