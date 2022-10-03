using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        public delegate void delUpdateChart();

        Thread updateThread;
        ThreadStart threadStart;

        public Form1()
        {
            this.trafficLights = new TrafficLights(10, 1, this.intersection);
            this.intersection = new Intersection(new int[] { 12, 6, 6, 6 }, 16, this.trafficLights);
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
            UpdateChart();
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
        private void UpdateChart()
        {
            delUpdateChart delUpdateChart = new delUpdateChart(UpdateCart1);
            this.chart1.BeginInvoke(delUpdateChart);
            ;
        }

        private void UpdateCart1()
        {
            var frequencyArray = CountOccurrencesWaitTime(this.intersection.waitingTimes);
            for (int i = 0; i < frequencyArray.Length; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY(i, frequencyArray[i]);
            }

            var axis = this.chart1.ChartAreas[0].AxisX;
            

            var minIndex = 0;
            for (int i = 0; i < frequencyArray.Length; i++)
            {
                if (frequencyArray[i] != 0)
                {
                    minIndex = i;
                    break;
                } 

            }

            var maxIndex = 0; 
            for (int i = frequencyArray.Length -1; i>=0; i--)
            {
                if (frequencyArray[i] != 0)
                {
                    maxIndex = i;
                    break;
                }
            }
            axis.Minimum = minIndex -1;
            axis.Maximum = maxIndex + 2;

            //update chart 2
            UpdateChart2();
        }


        private int[] CountOccurrencesWaitTime(List<int> waitingTimes)
        {
            //Make frequency table
            int maxValue = waitingTimes.Max();
            int[] frequencyArray = new int[maxValue + 1];
            for(int i = 0; i<= waitingTimes.Count() -1; i++)
            {
                frequencyArray[waitingTimes[i]]++;
            }
            return frequencyArray;


        }
        private void UpdateChart2()
        {
            var frequencyArray = CountOccurrencesWaitTime2();
            for (int i = 0; i < frequencyArray.Count(); i++)
            {
                this.chart2.Series["Series2"].Points.AddXY(i, frequencyArray[i]);
            }

            var axis = this.chart2.ChartAreas[0].AxisX;


            var minIndex = 0;
            for (int i = 0; i < frequencyArray.Count(); i++)
            {
                if (frequencyArray[i] != 0)
                {
                    minIndex = i;
                    break;
                }

            }

            var maxIndex = 0;
            for (int i = frequencyArray.Count() - 1; i >= 0; i--)
            {
                if (frequencyArray[i] != 0)
                {
                    maxIndex = i;
                    break;
                }
            }
            axis.Minimum = minIndex - 1;
            axis.Maximum = maxIndex + 2;
        }
        //Wachttijd van de auto's die nog wachten
        private int[] CountOccurrencesWaitTime2()
        {
            int totalWaitingCars = 0;
            int maxValue = 0;
            for (int i = 0; i < this.intersection.lanes.Length; i++)
            {
                totalWaitingCars += this.intersection.lanes[i].Count();
                for (int j = 0; j < this.intersection.lanes[i].Count(); j++)
                {
                    if (this.intersection.lanes[i][j].waitingTime > maxValue)
                        maxValue = this.intersection.lanes[i][j].waitingTime;
                }
            }
            int[] frequencyArray = new int[maxValue +1];
            for (int i = 0; i < this.intersection.lanes.Length; i++)
            {
                for (int j = 0; j < this.intersection.lanes[i].Count(); j++)
                {
                    frequencyArray[this.intersection.lanes[i][j].waitingTime]++;
                }
            }

            return frequencyArray;

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
