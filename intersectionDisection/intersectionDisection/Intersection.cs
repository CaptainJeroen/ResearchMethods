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
        public int[] lanes;
        public bool[] trafficLights;
        public bool lighthorizontal;
        public bool lightvertical;
        public int totalCarsPassed;
        public int cyclesPassed = 0;

        public Intersection(int l = 4)
        {
            this.lanes = new int[l];
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
                    if (this.trafficLights[i])//En misschien configuraties aan stoplichten maken
                    {
                        this.lanes[i] = Math.Min(this.lanes[i] - carsThrough, 0);// Misschien dat autos ook sneller voorbij kunnen rijden als een stoplicht op groen blijft
                                                                                 // Ook tijd tussen rood en groen 
                        passed += Math.Min(this.lanes[i], carsThrough);
                    }
                }
                //Elke cycle komen er bij elke baan auto's bij
                for (int i = 0; i < lanes.Length; i++)
                {
                    this.lanes[i] += carsIn[i];
                }
                this.cyclesPassed++;
            }
            this.totalCarsPassed += passed; 
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
                scores[i] = calcScores();
            }
            Array.Sort(scores);

            
            return new bool[] { false};
        }

        private float calcScores()
        {
            throw new NotImplementedException();
        }
    }
}
