using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intersectionDisection
{
    public partial class Form1 : Form
    {
        public Intersection intersection;
        public TrafficLights trafficLights;

        public delegate void delUpdateTextBox(string text);

        Thread updateThread;
        ThreadStart threadStart;

        public Form1()
        {
            this.trafficLights = new TrafficLights(1.0, 10, this.intersection);
            this.intersection = new Intersection(new int[] { 6, 6, 6, 6 }, 6, this.trafficLights);
            this.trafficLights.intersection = this.intersection;
            this.InitializeComponent();
            threadStart = new ThreadStart(StartSimulation);
            updateThread = new Thread(threadStart);
            updateThread.Start();
        }

        public void StartSimulation()
        {
            while (intersection.cyclesPassed<=100)
            {
                this.intersection.Model();
                this.AsyncUpdate();
                this.Invalidate();
                Thread.Sleep(10);
            }
            CountOccurrencesWaitTime(this.intersection.waitingTimes);
            ;
        }

        //SD = Standard diviation
        private void CalculateSDAndMean(List<int> waitingTimes)
        {
            float mean = this.intersection.totalWaitTime / this.intersection.totalCarsPassed;
            List<double> deviations = new List<double>();
            for(int i = 0; i < waitingTimes.Count; i++)
            {
                deviations.Add(Math.Pow((waitingTimes[i] - mean),2));
            }
            double sumDeviations =  deviations.Sum();
            double standardDeviation = Math.Sqrt(sumDeviations / this.intersection.totalCarsPassed);
        }

        private void CountOccurrencesWaitTime(List<int> waitingTimes)
        {
            //Make frequency table
            int maxValue = waitingTimes.Max();
            int[] frequencyArray = new int[maxValue + 1];
            for(int i = 0; i<= maxValue; i++)
            {
                frequencyArray[waitingTimes[i]]++;
            }//Ook de autos die nog wachten ergens bij optellen
        }

        private string MakeString()
        {
            string str = "";
            for (int i = 0; i<intersection.lanes.Length; i++)
            {
                str+= intersection.lanes[i].Count.ToString();
                if (i < intersection.lanes.Length - 1)
                    str += "|";
            }
            return str;
        }

        private void AsyncUpdate()
        {
            delUpdateTextBox delUpdateTextBox = new delUpdateTextBox(UpdateLabel1);
            string str = MakeString();
            this.label1.BeginInvoke(delUpdateTextBox, str);
            
        }
        private void UpdateLabel1(string text)
        {
            string[] str = text.Split('|');
            this.label1.Text = str[0];
            this.label2.Text = str[1];
            this.label3.Text = str[2];
            this.label4.Text = str[3];
        }

        void Teken(object obj, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            Brush hor = Brushes.Black;
            Brush ver = Brushes.Black;


            if (this.intersection.HorizontalLight)
            {
                hor = Brushes.Green;
                ver = Brushes.Red;
            }
            else
            {
                hor = Brushes.Red;
                ver = Brushes.Green;
            }

            gr.DrawLine(Pens.Black, 400, 100, 400, 400); //   |
            gr.DrawLine(Pens.Black, 100, 400, 400, 400); // --

            gr.DrawLine(Pens.Black, 600, 100, 600, 400); //     |
            gr.DrawLine(Pens.Black, 600, 400, 900, 400); //      --

            gr.DrawLine(Pens.Black, 400, 600, 400, 900); //   |
            gr.DrawLine(Pens.Black, 100, 600, 400, 600); // --

            gr.DrawLine(Pens.Black, 600, 600, 600, 900); //     |
            gr.DrawLine(Pens.Black, 600, 600, 900, 600); //      --

            gr.FillEllipse(hor, 425, 325, 50, 50);
            gr.FillEllipse(hor, 525, 625, 50, 50);

            gr.FillEllipse(ver, 325, 525, 50, 50);
            gr.FillEllipse(ver, 625, 425, 50, 50);
        }

    }
}
