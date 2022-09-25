using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace intersectionDisection
{
    public partial class Form1 : Form
    {
        public Intersection intersection;
        private Label carsleft;
        private Label carsright;
        private Label carstop;
        private Label carsbottom;

        private Label carspassedleft;
        private Label carspassedright;
        private Label carspassedtop;
        private Label carspassedbottom;

        public Form1()
        {
            InitializeComponent();
            this.intersection = new Intersection();
            this.Panel();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
