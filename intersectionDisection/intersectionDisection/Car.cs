using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intersectionDisection
{
    public class Car
    {
        public int waitingTime;
        public int arrivalTime;
        public Car(int arrival)
        {
            this.arrivalTime = arrival;
            this.waitingTime = 0;
        }
    }
}
