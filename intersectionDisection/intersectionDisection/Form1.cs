using System;
using System.IO;
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
        private string whatInt = "fourwayWithLeftLane"; // fourwayWithLeftLane, fourwayIntersection


        private string fileName = "sim12fr100";
        private int maxWOGreen = 100;
        private int[] carsIn = new int[] { 9, 9, 1, 1, 1, 1, 1, 1 }; //24
        private int carsThrough = 15;


        public delegate void delUpdateTextBox(string text);
        //public delegate void delUpdateTextBox1(string text);
        public delegate void delUpdateChart();


        Thread updateThread;
        ThreadStart threadStart;

        public Form1()
        {
            int lanes = 8;
            this.trafficLights = new TrafficLights(this.maxWOGreen, this.intersection, lanes);
            this.intersection = new Intersection(this.carsIn, this.carsThrough, this.trafficLights, lanes);
                                                        
            //this.intersection = new Intersection(new int[] { 4, 3, 4, 1 }, 10, this.trafficLights);
            this.trafficLights.intersection = this.intersection;
            this.InitializeComponent(whatInt);

            threadStart = new ThreadStart(StartSimulation);
            updateThread = new Thread(threadStart);
            updateThread.Start();
        }

        public void StartSimulation()
        {
            while (intersection.cyclesPassed<=100)
            {
                this.intersection.Model();
                this.UpdateLaneCount();
                //this.UpdateLabels();
                this.Invalidate();
                Thread.Sleep(1);
            }
            UpdateChart();
            WriteToFile();
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
        }

        private void WriteToFile()
        {
            DateTime currentDateTime = DateTime.Now;
            string curpath = Directory.GetCurrentDirectory();
            string path = Path.GetFullPath(Path.Combine(curpath, @"..\..\..\..\")) + "simulationData\\" + this.fileName + ".txt";
            int[] waitingTimeCarsGone = CountOccurrencesWaitTime(this.intersection.waitingTimes);
            int[] waitingTimeCarsLeft = CountOccurrencesWaitTime2();

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(maxWOGreen);
                sw.WriteLine(string.Join(" ", carsIn));
                sw.WriteLine(carsThrough);
                sw.WriteLine(intersection.switchedTrafficLight);
                sw.WriteLine(intersection.totalCarsPassed);
                sw.WriteLine(intersection.totalWaitTime);

                sw.WriteLine("carsInLane");
                this.intersection.carsInLane.ForEach(e =>
                {
                    sw.WriteLine(string.Join(" ", e));
                });
                sw.WriteLine("*");
                sw.WriteLine("waitingTimeCarsGone");
                foreach(int i in waitingTimeCarsGone)
                {
                    sw.WriteLine(i);
                }
                sw.WriteLine("*");
                sw.WriteLine("waitingTimeCarsLeft");
                foreach (int i in waitingTimeCarsLeft)
                {
                    sw.WriteLine(i);
                }
            }
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


        private int[] CountOccurrencesWaitTime(List<float> waitingTimes)
        {
            //Make frequency table
            float maxValue = waitingTimes.Max();
            int[] frequencyArray = new int[(int)Math.Round(maxValue) + 1];
            for(int i = 0; i<= waitingTimes.Count() -1; i++)
            {
                frequencyArray[(int)Math.Round(waitingTimes[i])]++;
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
            float maxValue = 0;
            for (int i = 0; i < this.intersection.lanes.Length; i++)
            {
                totalWaitingCars += this.intersection.lanes[i].Count();
                for (int j = 0; j < this.intersection.lanes[i].Count(); j++)
                {
                    if (this.intersection.lanes[i][j].waitingTime > maxValue)
                        maxValue = this.intersection.lanes[i][j].waitingTime;
                }
            }
            int[] frequencyArray = new int[(int)Math.Round(maxValue) +1];
            for (int i = 0; i < this.intersection.lanes.Length; i++)
            {
                for (int j = 0; j < this.intersection.lanes[i].Count(); j++)
                {
                    frequencyArray[(int)Math.Round(this.intersection.lanes[i][j].waitingTime)]++;
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


        private void UpdateLaneCount()
        {
            delUpdateTextBox delUpdateTextBox = new delUpdateTextBox(UpdateLabel1);
            string str = MakeString();
            this.labelnorthnumber.BeginInvoke(delUpdateTextBox, str);
        }

        private void UpdateLabels()
        {
            delUpdateTextBox delUpdateTextBox1 = new delUpdateTextBox(UpdateOtherLabels);
            this.labelnorthwaitnumber.BeginInvoke(delUpdateTextBox1, "");
        }

        private void UpdateLabel1(string text)
        {
            switch (whatInt)
            {
                case "fourwayIntersection":
                    this.labelnorthnumber.Text = this.intersection.lanes[0].Count.ToString();
                    this.labeleastnumber.Text = this.intersection.lanes[1].Count.ToString();
                    this.labelsouthnumber.Text = this.intersection.lanes[2].Count.ToString();
                    this.labelwestnumber.Text = this.intersection.lanes[3].Count.ToString();
                    this.labelnorthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[0]).ToString();
                    this.labeleastwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[1]).ToString();
                    this.labelsouthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[2]).ToString();
                    this.labelwestwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[3]).ToString();
                    break;
                case "fourwayWithLeftLane":
                    this.labelnorthnumber.Text = this.intersection.lanes[0].Count.ToString();
                    this.labeleastnumber.Text = this.intersection.lanes[2].Count.ToString();
                    this.labelsouthnumber.Text = this.intersection.lanes[4].Count.ToString();
                    this.labelwestnumber.Text = this.intersection.lanes[6].Count.ToString();
                    this.labelnorthnumber2.Text = this.intersection.lanes[1].Count.ToString();
                    this.labeleastnumber2.Text = this.intersection.lanes[3].Count.ToString();
                    this.labelsouthnumber2.Text = this.intersection.lanes[5].Count.ToString();
                    this.labelwestnumber2.Text = this.intersection.lanes[7].Count.ToString();
                    this.labelnorthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[0]).ToString();
                    this.labeleastwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[2]).ToString();
                    this.labelsouthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[4]).ToString();
                    this.labelwestwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[6]).ToString();
                    this.labelnorthwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[1]).ToString();
                    this.labeleastwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[3]).ToString();
                    this.labelsouthwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[5]).ToString();
                    this.labelwestwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[7]).ToString();
                    break;
                default:
                    throw new OutOfMemoryException();
                    break;
            }
            this.labeltotalcarspassednumber.Text = this.intersection.totalCarsPassed.ToString();
            this.labeltotalwaittimenumber.Text = (this.intersection.totalWaitTime * (carsThrough / 10)).ToString();
            this.labeltotalcyclespassednumber.Text = this.intersection.cyclesPassed.ToString();
            this.labeltotalcycleswithoutchangenumber.Text = this.intersection.switchedTrafficLight.ToString();
        }

        private void UpdateOtherLabels(string text)
        {
            this.labelnorthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[0]).ToString();
            this.labeleastwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[1]).ToString();
            this.labelsouthwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[2]).ToString();
            this.labelwestwaitnumber.Text = GetTotalWaitingTimeLane(this.intersection.lanes[3]).ToString();

            this.labeltotalcarspassednumber.Text = this.intersection.totalCarsPassed.ToString();
            this.labeltotalwaittimenumber.Text = this.intersection.totalWaitTime.ToString();
            this.labeltotalcyclespassednumber.Text = this.intersection.cyclesPassed.ToString();
            this.labeltotalcycleswithoutchangenumber.Text = this.intersection.switchedTrafficLight.ToString();

            if (whatInt == "fourwayWithLeftLane")
            {
                this.labelnorthwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[4]).ToString();
                this.labeleastwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[5]).ToString();
                this.labelsouthwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[6]).ToString();
                this.labelwestwaitnumber2.Text = GetTotalWaitingTimeLane(this.intersection.lanes[7]).ToString();
            }
        }
        private float GetTotalWaitingTimeLane(List<Car> lane)
        {
            float res = 0;
            for (int i = 0; i < lane.Count; i++)
            {
                res += lane[i].waitingTime;
            }
            return res;
        }
        void TekenFourWay(object obj, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            Brush hor = this.intersection.trafficLights[0] ? Brushes.Green : Brushes.Red;
            Brush ver = this.intersection.trafficLights[1] ? Brushes.Green : Brushes.Red;

            Pen smalPen = new Pen(Color.Black, 1);
            Pen bigPen = new Pen(Color.Black, 2);


            gr.DrawLine(bigPen, 200, 50, 200, 200); //   |
            gr.DrawLine(bigPen, 50, 200, 200, 200); // --
            gr.DrawLine(smalPen, 50, 250, 200, 250);

            gr.DrawLine(bigPen, 300, 50, 300, 200); //     |
            gr.DrawLine(bigPen, 300, 200, 450, 200); //      --
            gr.DrawLine(smalPen, 250, 50, 250, 200);

            gr.DrawLine(bigPen, 200, 300, 200, 450); // --
            gr.DrawLine(bigPen, 50, 300, 200, 300); //   |
            gr.DrawLine(smalPen, 250, 300, 250, 450);

            gr.DrawLine(bigPen, 300, 300, 300, 450); //    --
            gr.DrawLine(bigPen, 300, 300, 450, 300); //   |  
            gr.DrawLine(smalPen, 300, 250, 450, 250);


            gr.FillEllipse(hor, 180, 270, 20, 20);
            gr.FillEllipse(hor, 300, 210, 20, 20);

            gr.FillEllipse(ver, 210, 180, 20, 20);
            gr.FillEllipse(ver, 270, 300, 20, 20);
        }

        void TekenFourWayWithLeftLane(object obj, PaintEventArgs pea)
        {
            Graphics gr = pea.Graphics;
            Brush verSt = this.intersection.trafficLights[0] ? Brushes.Green : Brushes.Red;
            Brush verLt = this.intersection.trafficLights[1] ? Brushes.Green : Brushes.Red;
            Brush horSt = this.intersection.trafficLights[2] ? Brushes.Green : Brushes.Red;
            Brush horLt = this.intersection.trafficLights[3] ? Brushes.Green : Brushes.Red;
            //
            Brush verSt2 = this.intersection.trafficLights[4] ? Brushes.Green : Brushes.Red;
            Brush verLt2 = this.intersection.trafficLights[5] ? Brushes.Green : Brushes.Red;
            Brush horSt2 = this.intersection.trafficLights[6] ? Brushes.Green : Brushes.Red;
            Brush horLt2 = this.intersection.trafficLights[7] ? Brushes.Green : Brushes.Red;

            Pen dashPen = new Pen(Color.Black, 1) { DashPattern = new[] { 5f, 5f } };
            Pen smalPen = new Pen(Color.Black, 1);
            Pen bigPen = new Pen(Color.Black, 2);


            gr.DrawLine(bigPen, 200, 50, 200, 200); //   |
            gr.DrawLine(bigPen, 50, 200, 200, 200); // --
            gr.DrawLine(smalPen, 50, 250, 200, 250);
            gr.DrawLine(dashPen, 125, 300, 200, 300);

            gr.DrawLine(bigPen, 350, 50, 350, 200); //     |
            gr.DrawLine(bigPen, 350, 200, 500, 200); //      --
            gr.DrawLine(smalPen, 300, 50, 300, 200);
            gr.DrawLine(dashPen, 250, 125, 250, 200);

            gr.DrawLine(bigPen, 200, 350, 200, 500); // --
            gr.DrawLine(bigPen, 50, 350, 200, 350); //   |
            gr.DrawLine(smalPen, 250, 350, 250, 500);
            gr.DrawLine(dashPen, 300, 350, 300, 425);

            gr.DrawLine(bigPen, 350, 350, 350, 500); //    --
            gr.DrawLine(bigPen, 350, 350, 500, 350); //   |  
            gr.DrawLine(smalPen, 350, 300, 500, 300);
            gr.DrawLine(dashPen, 350, 250, 425, 250);

            gr.FillEllipse(horSt, 180, 320, 20, 20);
            gr.FillEllipse(horSt2, 350, 210, 20, 20);
            gr.FillEllipse(horLt, 180, 270, 20, 20);
            gr.FillEllipse(horLt2, 350, 260, 20, 20);


            gr.FillEllipse(verSt, 210, 180, 20, 20);
            gr.FillEllipse(verSt2, 320, 350, 20, 20);
            gr.FillEllipse(verLt, 260, 180, 20, 20);
            gr.FillEllipse(verLt2, 270, 350, 20, 20);

        }

    }
}
