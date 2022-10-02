using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intersectionDisection
{
    public class Intersection
    {
        public List<Car>[] lanes;
        public bool[] trafficLights;
        public bool lighthorizontal;
        public bool lightvertical;
        public int totalCarsPassed;
        public int cyclesPassed = 0;
        public int cyclesWithoutChange = 0;
        private int[] carsIn;
        private int carsThrough;
        TrafficLights trafficL;


        public Intersection( int[] ci, int ct, TrafficLights tl, int l = 4)// l = 4 of 8 of 12 niks anders
        {
            this.lanes = new List<Car>[l];
            for(int i = 0; i < l; i++)
            {
                lanes[i] = new List<Car>();
            }
            this.carsIn = ci;
            trafficL = tl;
            this.carsThrough = ct;
            this.trafficLights = new bool[l];
            //Horizontal gets first green
            trafficLights[0] = true;
            trafficLights[2] = true;
        }
        public bool HorizontalLight//Tijdelijk
        {
            get
            {
                return trafficLights[0];
            }
        }
        public bool VerticalLight//Tijdelijk
        {
            get
            {
                return trafficLights[1];
            }
        }
        /*
        What to measure:
        - Throughput
        - Avg waiting time
        ....
        */
        public void Model()//Manier bedenken om de gemiddelde wachttijd te berekenen, misschien toch auto's als structs
        {
            int passed = 0;

            //Elke cycle gaan er autos af, bij de stoplichten die op groen staan
            for (int i = 0; i < this.lanes.Length; i++)
            {
                if (this.trafficLights[i])//En misschien configuraties van stoplichten maken
                {
                    // Ook tijd tussen rood en groen 
                    passed += Math.Min(this.lanes[i].Count, carsThrough);
                    this.RemoveCars(this.lanes[i], carsThrough);// Als er maar 1 auto per cycle langs gaat zou Pop() wel goed werken
                }
            }
            //Wachttijd voor autos die nu nog staan te wachten verhogen
            for (int i = 0; i < this.lanes.Length; i++)
            {
                for (int j = 0; j < this.lanes[i].Count; j++)
                {
                    this.lanes[i][j].waitingTime++;
                }
            }

            //Elke cycle komen er bij elke baan auto's bij
            for (int i = 0; i < this.lanes.Length; i++)
            {
                this.AddCars(this.lanes[i],carsIn[i]);
            }
            this.cyclesPassed++;
            this.totalCarsPassed += passed;
            this.trafficLights = trafficL.Behaviour();
            
        }
        void AddCars(List<Car> cars, int amount)
        {
            for (int i = 0; i < amount; i++ )
            {
                cars.Add(new Car(cyclesPassed));
            }    
        }
        private void RemoveCars(List<Car> cars, int amount)
        {
            int amountToRemove = cars.Count < amount ? cars.Count : amount;  
            for(int i = 0; i< amountToRemove; i++)
            {
                cars.RemoveAt(0);
            }
        }

        private int GetTotalWaitingTimeLane(List<Car> lane)
        {
            int res = 0;
            for(int i = 0; i < lane.Count; i++)
            {
                res+= lane[i].waitingTime;
            }
            return res;
        }
    }

    public class TrafficLights
    {
        double fairness, throughput;
        public Intersection intersection;

        public TrafficLights(double fr, double thrP, Intersection i)
        {
            fairness = fr;
            throughput = thrP;
            intersection = i;
        }

        public bool[] Behaviour()
        {
            switch (intersection.lanes.Length)
            {
                case 4:
                    return FourWayIntersection();
                default:
                    return FourWayIntersection();
            }
        }

        private bool[] FourWayIntersection()
        {
            double[] scores = new double[intersection.lanes.Length];
            for (int i = 0; i<intersection.lanes.Length; i++)
            {
                scores[i] = CalcScores(intersection.lanes[i].Count());
            }

            if ((scores[0] + scores[2]) > (scores[1] + scores[3]))
            {
                bool[] newTrafficLights = new bool[] { true, false, true, false };
                this.CompairTrafficLights(newTrafficLights, this.intersection.trafficLights);
                return newTrafficLights;
            }
            else
            {
                bool[] newTrafficLights = new bool[] { false, true, false, true };
                this.CompairTrafficLights(newTrafficLights, this.intersection.trafficLights);
                return newTrafficLights;
            }
        }
        private void CompairTrafficLights(bool[] light1, bool[] light2)
        {
            if (Enumerable.SequenceEqual(light1, light2))
                this.intersection.cyclesWithoutChange++;
            else
                this.intersection.cyclesWithoutChange = 0;
        }
        private double CalcScores(int cars)
        {
            return cars * throughput / Math.Pow(intersection.cyclesWithoutChange, fairness);  
        }
    }
}
