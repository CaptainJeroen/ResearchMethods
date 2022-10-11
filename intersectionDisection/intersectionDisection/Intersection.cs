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
        public List<Car>[] lanes; // north, east, south, west
        public bool[] trafficLights; // north, east, south, west
        public int totalCarsPassed;
        public float totalWaitTime = 0; //totale wachttijd van auto's die er voorbij zijn
        public int cyclesPassed = 0; 
        public int cyclesWithoutChange = 1;
        private int[] carsIn;
        private int carsThrough;
        TrafficLights trafficL;
        public int switchedTrafficLight = 0;
        public List<float> waitingTimes = new List<float>(); // wachtijden van alle auto's voordat ze door konden rijden
        public List<int[]> carsInLane = new List<int[]>(); // hoeveel auto's in lanes van alle rondes

        public Intersection( int[] ci, int ct, TrafficLights tl, int l = 4)// l = 4 of 8 of 12 niks anders
        {
            this.lanes = new List<Car>[l];
            for(int i = 0; i < l; i++)
            {
                lanes[i] = new List<Car>();
            }
            this.carsIn = ci;
            this.trafficL = tl;
            this.carsThrough = ct;
            this.trafficLights = new bool[l];
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
            int[] currentLanes = new int[this.lanes.Length]; 
            //Elke cycle komen er bij elke baan auto's bij
            for (int i = 0; i < this.lanes.Length; i++)
            {
                this.AddCars(this.lanes[i], carsIn[i]);
                 currentLanes[i] = this.lanes[i].Count;

            }
            var newLights = this.trafficL.Behaviour();


            if (!Enumerable.SequenceEqual(newLights, trafficLights))
            {
                switchedTrafficLight++;
                //Add waiting time of x to everyone
                for (int i = 0; i < this.lanes.Length; i++)
                {
                    for (int j = 0; j < this.lanes[i].Count; j++)
                    {
                        this.lanes[i][j].waitingTime+= 1.0f/ carsThrough * 5;
                    }
                }
            }
            this.trafficLights = newLights;


            //Elke cycle gaan er autos af, bij de stoplichten die op groen staan
            for (int i = 0; i < this.lanes.Length; i++)
            {
                if (this.trafficLights[i])//En misschien configuraties van stoplichten maken
                {
                    // Ook tijd tussen rood en groen?
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

            this.carsInLane.Add(currentLanes);
            this.cyclesPassed++;
            this.totalCarsPassed += passed;

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
                totalWaitTime += cars[0].waitingTime;// In een aparte list
                waitingTimes.Add(cars[0].waitingTime);
                cars.RemoveAt(0);
            }
        }

        private float GetTotalCurrentWaitingTimeLane(List<Car> lane)
        {
            float res = 0;
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
        int maxCyclesWithoutGreen;
        public int[] cyclesWithoutChange;

        public TrafficLights(int max, Intersection i, int l)
        {

            maxCyclesWithoutGreen = max;
            intersection = i;
            cyclesWithoutChange = new int[l]; 
        }

        public bool[] Behaviour()
        {
            switch (intersection.lanes.Length)
            {
                case 4:
                    return FourWayIntersection();
                case 8:
                    return fourWayWithLeftLane();
                default:
                    return FourWayIntersection();
            }
        }

        private bool[] FourWayIntersection()
        {
            bool[] newTrafficLights = new bool[] { false, false, false, false };
            int res = OneAboveMaxWaitTime2();//Moet anders
            if (res >= 0)
            {
                newTrafficLights[res] = true;
                newTrafficLights[res+2] = true;
            }
            else
            {
                double[] scores = new double[intersection.lanes.Length];
                for (int i = 0; i < intersection.lanes.Length; i++)
                {
                    scores[i] = intersection.lanes[i].Count();
                }

                if ((scores[0] + scores[2]) > (scores[1] + scores[3]))
                {
                    newTrafficLights[0] = true;
                    newTrafficLights[2] = true;
                }
                else
                {
                    newTrafficLights[1] = true;
                    newTrafficLights[3] = true;
                }
            }
            this.UpdateCyclesWithoutChange(newTrafficLights);
            return newTrafficLights;
        }
        private int OneAboveMaxWaitTime2()
        {
            for (int i = 0; i < cyclesWithoutChange.Length; i++)
            {
                if (cyclesWithoutChange[i] >= maxCyclesWithoutGreen)
                    return i;
            }
            return -1;
        }
        private (int,int) OneAboveMaxWaitTime()
        {
            var configs = new[] { (0, 4), (1,5), (2, 6),(3,7),(0,1), (2,3), (4,5), (6,7) };
            (int, int) biggest = (-1,-1);
            for (int i = 0; i < configs.Length; i++)
            {
                if (cyclesWithoutChange[configs[i].Item1] >= maxCyclesWithoutGreen || cyclesWithoutChange[configs[i].Item2] >= maxCyclesWithoutGreen)
                    if (cyclesWithoutChange[configs[i].Item1] + cyclesWithoutChange[configs[i].Item2] > biggest.Item1 + biggest.Item2)
                    {
                        biggest = configs[i];
                    }
            }
            return biggest;
        }

        private bool[] fourWayWithLeftLane()
        {
            bool[] newTrafficLights = new bool[] { false, false, false, false, false, false, false, false };
            (int,int) res = OneAboveMaxWaitTime();
            if (res.Item1>=0)
            {
                newTrafficLights[res.Item1] = true;
                newTrafficLights[res.Item2] = true;
            }
            else
            {
                double[] scores = new double[intersection.lanes.Length];
                for (int i = 0; i < intersection.lanes.Length; i++)
                {
                    scores[i] = intersection.lanes[i].Count();
                }

                List<(double, (int,int))> means = new List<(double, (int, int))> { 
                    (scores[0] + scores[4], (0,4)),
                    (scores[1] + scores[5], (1,5)), 
                    (scores[2] + scores[6], (2,6)), 
                    (scores[3] + scores[7], (3,7)),
                    (scores[0] + scores[1], (0,1)), 
                    (scores[2] + scores[3], (2,3)), 
                    (scores[4] + scores[5], (4,5)), 
                    (scores[6] + scores[7], (6,7))};

                means.Sort((x, y) => y.Item1.CompareTo(x.Item1));

                newTrafficLights[means[0].Item2.Item1] = true;
                newTrafficLights[means[0].Item2.Item2] = true;
            }


            //this.CompairTrafficLights(newTrafficLights, this.intersection.trafficLights);
            this.UpdateCyclesWithoutChange(newTrafficLights);

            return newTrafficLights;
        }


        
        private void UpdateCyclesWithoutChange(bool[] lights)
        {
            for (int i = 0; i < this.cyclesWithoutChange.Length; i++)
            {
                if (lights[i])
                {
                    cyclesWithoutChange[i] = 0;
                }
                else
                {
                    cyclesWithoutChange[i]++;
                }
            }
        }

    }
}
