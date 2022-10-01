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
            this.trafficLights = new TrafficLights(1.3, 0.7, this.intersection);
            this.intersection = new Intersection(new int[] { 2, 3, 4, 1 }, 1, this.trafficLights);
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
            str += intersection.lanes[0].Count.ToString() + "|";
            str += intersection.lanes[1].Count.ToString() + "|";
            str += intersection.lanes[2].Count.ToString() + "|";
            str +=  intersection.lanes[3].Count.ToString();
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



    }
}
