using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intersectionDisection
{
    public class Car
    {
        public int arrivalCycle;
        public int waitingTime = 0;
        public Car(int a)
        {
            this.arrivalCycle = a;
        }
    }
}
