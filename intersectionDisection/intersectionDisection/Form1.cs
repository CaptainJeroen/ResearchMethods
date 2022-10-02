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
        public delegate void delUpdateTextBox(string text);


        Thread updateThread;
        ThreadStart threadStart;

        public Form1()
        {
            this.trafficLights = new TrafficLights(1.1, 1.7, this.intersection);
            this.intersection = new Intersection(new int[] { 2, 3, 4, 1 }, 10, this.trafficLights);
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
                Thread.Sleep(1000);
            }
        }

        private string MakeString()//We willen trouwens niet de labels update maar er tekstboxes naast plaatsen
        {
            //
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

        private void UpdateOtherLabels(string text)
        {

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
