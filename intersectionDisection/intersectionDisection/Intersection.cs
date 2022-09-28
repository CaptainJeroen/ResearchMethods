using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int cyclesWithoutChange = 1;

        public Intersection(int l = 4)// 4 of 8 of 12 niks anders
        {
            this.lanes = new List<Car>[l];
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
        private void Model(int[] carsIn, int carsThrough, TrafficLights tl)//Manier bedenken om de gemiddelde wachttijd te berekenen, misschien toch auto's als structs
        {
            Stopwatch cycle = null;//Tijdelijk
            int passed = 0;
            while (cycle == null) //Tijdseenheid 1 auto die een stoplicht passeert?
            {
                //Elke cycle gaan er autos af, bij de stoplichten die op groen staan
                for (int i = 0; i < lanes.Length; i++)
                {
                    if (this.trafficLights[i])//En misschien configuraties van stoplichten maken
                    {
                        // Ook tijd tussen rood en groen 
                        this.RemoveCars(this.lanes[i], carsThrough);// Als er maar 1 auto per cycle langs gaat zou Pop() wel goed werken
                        passed += Math.Min(this.lanes[i].Count, carsThrough);
                    }
                }
                //Elke cycle komen er bij elke baan auto's bij
                for (int i = 0; i < lanes.Length; i++)
                {
                    this.AddCars(this.lanes[i],carsIn[i]);
                }
                this.cyclesPassed++;
            }
            this.totalCarsPassed += passed; 
        }
        private void AddCars(List<Car> cars, int amount)
        {
            throw new NotImplementedException();    
        }
        private void RemoveCars(List<Car> cars, int amount)
        {
            throw new NotImplementedException();    
        }
    }

    class TrafficLights
    {
        int fairness, throughput;
        Intersection intersection;

        public TrafficLights(int fr, int thrP, Intersection i)
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
                    return fourWayIntersection();
                default:
                    return fourWayIntersection();
            }
        }

        private bool[] fourWayIntersection()
        {
            float[] scores = new float[intersection.lanes.Length];
            for (int i = 0; i<=intersection.lanes.Length; i++)
            {
                scores[i] = calcScores(intersection.lanes[i]);
            }

            if ((scores[0] + scores[2])/2 > (scores[1] + scores[3]) / 2)
            {
                return new bool[] { true, false, true, false };
            }
            else
            {
                return new bool[] { false, true, false, true };
            }
        }

        private float calcScores(int cars)
        {
            return cars * throughput / (intersection.cyclesWithoutChange ^ fairness);  
        }
    }
}
