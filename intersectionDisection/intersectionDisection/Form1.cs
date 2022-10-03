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
        private string whatInt = "fourwayWithLeftLane"; // fourwayWithLeftLane, fourwayIntersection

        public delegate void delUpdateTextBox(string text);

        Thread updateThread;
        ThreadStart threadStart;

        public Form1()
        {
            this.trafficLights = new TrafficLights(1.1, 3, this.intersection);
            this.intersection = new Intersection(new int[] { 4, 3, 4, 1, 5, 2, 7, 3 }, 10, this.trafficLights, 8);
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
                this.AsyncUpdate();
                this.Invalidate();
                Thread.Sleep(1000);
            }
        }

        //SD = Standard diviation
        private void CalculateSD(List<int> waitingTimes)
        {
            float mean = this.intersection.totalWaitTime / this.intersection.totalCarsPassed;
            List<float> standardDev = new List<float>();
            for(int i = 0; i < waitingTimes.Count; i++)
            {
                standardDev.Add(waitingTimes[i] - mean);
            }
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
            gr.FillEllipse(horSt, 350, 210, 20, 20);
            gr.FillEllipse(horLt, 180, 270, 20, 20);
            gr.FillEllipse(horLt, 350, 260, 20, 20);


            gr.FillEllipse(verSt, 210, 180, 20, 20);
            gr.FillEllipse(verSt, 320, 350, 20, 20);
            gr.FillEllipse(verLt, 260, 180, 20, 20);
            gr.FillEllipse(verLt, 270, 350, 20, 20);

        }

    }
}
