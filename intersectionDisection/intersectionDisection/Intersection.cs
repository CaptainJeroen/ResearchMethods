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
        public Intersection(int l = 4)
        {
            this.lanes = new int[l];
            this.trafficLights = new bool[l];
            //Horizontal gets first green
            trafficLights[0] = true;
            trafficLights[2] = true;
        }
        public bool HorizontalLight 
        { 
            get 
            { 
                return trafficLights[0]; 
            } 
        }
        public bool VerticalLight 
        {
            get 
            { 
                return trafficLights[1]; 
            } 
        }

        private void Model(int[] carsIn, int carsThrough, TrafficLights tl)
        {
            Stopwatch cycle = null;//Kan ook wat anders
            while (cycle == null) //Tijdelijk
            {   
                //Elke cycle komen er bij elke baan auto's bij
                for (int i = 0; i < lanes.Length; i++)
                {
                    this.lanes[i] += carsIn[i];
                }
                //Elke cycle gaan er autos vanaf bij de stoplichten die op groen staan
                for (int i = 0; i < lanes.Length; i++)
                {
                    if (this.trafficLights[i])
                    {
                        this.lanes[i] -= carsThrough;
                    }
                }
            }
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
                    break;
                default:
                    return fourWayIntersection();
                    break;
            }
        }

        private bool[] fourWayIntersection()
        {
            float[] scores = new float[intersection.lanes.Length];
            for (int i = 0; i<=intersection.lanes.Length; i++)
            {
                scores[i] = calcScores();
            }
            scores.Sort();

            
            return false;
        }

        private float calcScore()
        {

        }

    }
}
