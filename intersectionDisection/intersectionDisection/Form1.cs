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
        private Thread model;

        public Form1()
        {


            model = new Thread(test);
            model.Start();
        }

        public void test()
        {
            InitializeComponent();

            this.trafficLights = new TrafficLights(1.3, 0.7, this.intersection);
            this.intersection = new Intersection(new int[] { 2, 3, 4, 1 }, 10, this.trafficLights);
            this.trafficLights.intersection = this.intersection;
            this.Panel();

            while (intersection.cyclesPassed<=100)
            {
                intersection.Model();
                this.label1.Text = intersection.lanes[0].Count.ToString();
                this.label2.Text = intersection.lanes[1].Count.ToString();
                this.label3.Text = intersection.lanes[2].Count.ToString();
                this.label4.Text = intersection.lanes[3].Count.ToString();//denk ik
                
                this.Invalidate();
                Thread.Sleep(100);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
