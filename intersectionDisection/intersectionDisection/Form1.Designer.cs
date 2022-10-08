using System;
using System.Drawing;
using System.Windows.Forms;

namespace intersectionDisection
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelnorth;
        private Label labeleast;
        private Label labelsouth;
        private Label labelwest;
        private Label labelnorthwait;
        private Label labeleastwait;
        private Label labelsouthwait;
        private Label labelwestwait;
        private Label labelnorthwaitnumber;
        private Label labeleastwaitnumber;
        private Label labelsouthwaitnumber;
        private Label labelwestwaitnumber;
        private Label labeltotalcarspassed;
        private Label labeltotalwaittime;
        private Label labelcyclespassed;
        private Label labelcycleswithoutchange;
        private Label labeltotalcarspassednumber;
        private Label labeltotalwaittimenumber;
        private Label labelcyclespassednumber;
        private Label labelcycleswithoutchangenumber;

        //private void InitializeComponent()
        private ComboBox comboBox1 = new ComboBox();

        private void InitializeComponent(string whatIntersection)
        {
            Init(whatIntersection);
        }

        private void Init(string whatIntersection)
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea2";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend2";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(850, 500);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea2";
            series2.Legend = "Legend2";
            series2.Name = "Series2";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(400, 400);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(850, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(400, 400);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1320, 663);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart2);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            switch (whatIntersection)
            {
                case "fourwayIntersection":
                    this.fourwayIntersection();
                    this.Paint += this.TekenFourWay;
                    break;
                case "fourwayWithLeftLane":
                    this.fourwayWithLeftLane();
                    this.Paint += this.TekenFourWayWithLeftLane;
                    break;
                default:
                    this.fourwayIntersection();
                    this.Paint += this.TekenFourWay;
                    break;
            }

            //this.Shown += StartSimulation;
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void fourwayIntersection()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelnorth = new System.Windows.Forms.Label();
            this.labeleast = new System.Windows.Forms.Label();
            this.labelsouth = new System.Windows.Forms.Label();
            this.labelwest  = new System.Windows.Forms.Label();
            this.labelnorthwait = new System.Windows.Forms.Label();
            this.labeleastwait = new System.Windows.Forms.Label();
            this.labelsouthwait = new System.Windows.Forms.Label();
            this.labelwestwait = new System.Windows.Forms.Label();
            this.labelnorthwaitnumber = new System.Windows.Forms.Label();
            this.labeleastwaitnumber = new System.Windows.Forms.Label();
            this.labelsouthwaitnumber = new System.Windows.Forms.Label();
            this.labelwestwaitnumber = new System.Windows.Forms.Label();
            this.labeltotalcarspassed = new System.Windows.Forms.Label();
            this.labeltotalwaittime = new System.Windows.Forms.Label();
            this.labelcyclespassed = new System.Windows.Forms.Label();
            this.labelcycleswithoutchange = new System.Windows.Forms.Label();
            this.labeltotalcarspassednumber = new System.Windows.Forms.Label();
            this.labeltotalwaittimenumber = new System.Windows.Forms.Label();
            this.labelcyclespassednumber = new System.Windows.Forms.Label();
            this.labelcycleswithoutchangenumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "North: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(985, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "East: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 950);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "South: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "West: ";
            // 
            // labelnorth
            // 
            this.labelnorth.AutoSize = true;
            this.labelnorth.Location = new System.Drawing.Point(150, 50);
            this.labelnorth.Name = "labelnorth";
            this.labelnorth.Size = new System.Drawing.Size(35, 13);
            this.labelnorth.TabIndex = 4;
            this.labelnorth.Text = "North: ";
            // 
            // labeleast
            // 
            this.labeleast.AutoSize = true;
            this.labeleast.Location = new System.Drawing.Point(350, 180);
            this.labeleast.Name = "labeleast";
            this.labeleast.Size = new System.Drawing.Size(35, 13);
            this.labeleast.TabIndex = 5;
            this.labeleast.Text = "East: ";
            // 
            // labelsouth
            // 
            this.labelsouth.AutoSize = true;
            this.labelsouth.Location = new System.Drawing.Point(310, 350);
            this.labelsouth.Name = "labelsouth";
            this.labelsouth.Size = new System.Drawing.Size(35, 13);
            this.labelsouth.TabIndex = 6;
            this.labelsouth.Text = "South: ";
            // 
            // labelwest
            // 
            this.labelwest.AutoSize = true;
            this.labelwest.Location = new System.Drawing.Point(50, 210);
            this.labelwest.Name = "labelwest";
            this.labelwest.Size = new System.Drawing.Size(35, 13);
            this.labelwest.TabIndex = 7;
            this.labelwest.Text = "West: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelnorth);
            this.Controls.Add(this.labeleast);
            this.Controls.Add(this.labelsouth);
            this.Controls.Add(this.labelwest);
        }

        private void fourwayWithLeftLane()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelnorth = new System.Windows.Forms.Label();
            this.labeleast = new System.Windows.Forms.Label();
            this.labelsouth = new System.Windows.Forms.Label();
            this.labelwest = new System.Windows.Forms.Label();
            this.labelnorthwait = new System.Windows.Forms.Label();
            this.labeleastwait = new System.Windows.Forms.Label();
            this.labelsouthwait = new System.Windows.Forms.Label();
            this.labelwestwait = new System.Windows.Forms.Label();
            this.labelnorthwaitnumber = new System.Windows.Forms.Label();
            this.labeleastwaitnumber = new System.Windows.Forms.Label();
            this.labelsouthwaitnumber = new System.Windows.Forms.Label();
            this.labelwestwaitnumber = new System.Windows.Forms.Label();
            this.labeltotalcarspassed = new System.Windows.Forms.Label();
            this.labeltotalwaittime = new System.Windows.Forms.Label();
            this.labelcyclespassed = new System.Windows.Forms.Label();
            this.labelcycleswithoutchange = new System.Windows.Forms.Label();
            this.labeltotalcarspassednumber = new System.Windows.Forms.Label();
            this.labeltotalwaittimenumber = new System.Windows.Forms.Label();
            this.labelcyclespassednumber = new System.Windows.Forms.Label();
            this.labelcycleswithoutchangenumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "North: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(985, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "East: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 950);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "South: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "West: ";
            // 
            // labelnorth
            // 
            this.labelnorth.AutoSize = true;
            this.labelnorth.Location = new System.Drawing.Point(400, 50);
            this.labelnorth.Name = "labelnorth";
            this.labelnorth.Size = new System.Drawing.Size(35, 13);
            this.labelnorth.TabIndex = 4;
            this.labelnorth.Text = "North: ";
            // 
            // labeleast
            // 
            this.labeleast.AutoSize = true;
            this.labeleast.Location = new System.Drawing.Point(950, 450);
            this.labeleast.Name = "labeleast";
            this.labeleast.Size = new System.Drawing.Size(35, 13);
            this.labeleast.TabIndex = 5;
            this.labeleast.Text = "East: ";
            // 
            // labelsouth
            // 
            this.labelsouth.AutoSize = true;
            this.labelsouth.Location = new System.Drawing.Point(500, 950);
            this.labelsouth.Name = "labelsouth";
            this.labelsouth.Size = new System.Drawing.Size(35, 13);
            this.labelsouth.TabIndex = 6;
            this.labelsouth.Text = "South: ";
            // 
            // labelwest
            // 
            this.labelwest.AutoSize = true;
            this.labelwest.Location = new System.Drawing.Point(50, 550);
            this.labelwest.Name = "labelwest";
            this.labelwest.Size = new System.Drawing.Size(35, 13);
            this.labelwest.TabIndex = 7;
            this.labelwest.Text = "West: ";
            // 
            // labelnorthwait
            // 
            this.labelnorthwait.AutoSize = true;
            this.labelnorthwait.Location = new System.Drawing.Point(400, 70);
            this.labelnorthwait.Name = "labelnorthwait";
            this.labelnorthwait.Size = new System.Drawing.Size(35, 13);
            this.labelnorthwait.TabIndex = 8;
            this.labelnorthwait.Text = "WaitCycles: ";
            // 
            // labeleastwait
            // 
            this.labeleastwait.AutoSize = true;
            this.labeleastwait.Location = new System.Drawing.Point(950, 470);
            this.labeleastwait.Name = "labeleastwait";
            this.labeleastwait.Size = new System.Drawing.Size(35, 13);
            this.labeleastwait.TabIndex = 9;
            this.labeleastwait.Text = "WaitCycles: ";
            // 
            // labelsouthwait
            // 
            this.labelsouthwait.AutoSize = true;
            this.labelsouthwait.Location = new System.Drawing.Point(500, 970);
            this.labelsouthwait.Name = "labelsouthwait";
            this.labelsouthwait.Size = new System.Drawing.Size(35, 13);
            this.labelsouthwait.TabIndex = 10;
            this.labelsouthwait.Text = "WaitCycles: ";
            // 
            // labelwestwait
            // 
            this.labelwestwait.AutoSize = true;
            this.labelwestwait.Location = new System.Drawing.Point(50, 570);
            this.labelwestwait.Name = "labelwestwait";
            this.labelwestwait.Size = new System.Drawing.Size(35, 13);
            this.labelwestwait.TabIndex = 11;
            this.labelwestwait.Text = "WaitCycles: ";
            // 
            // labelnorthwaitnumber
            // 
            this.labelnorthwaitnumber.AutoSize = true;
            this.labelnorthwaitnumber.Location = new System.Drawing.Point(470, 70);
            this.labelnorthwaitnumber.Name = "labelnorthwaitnumber";
            this.labelnorthwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelnorthwaitnumber.TabIndex = 12;
            this.labelnorthwaitnumber.Text = "0";
            // 
            // labeleastwaitnumber
            // 
            this.labeleastwaitnumber.AutoSize = true;
            this.labeleastwaitnumber.Location = new System.Drawing.Point(1020, 470);
            this.labeleastwaitnumber.Name = "labeleastwait";
            this.labeleastwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labeleastwaitnumber.TabIndex = 13;
            this.labeleastwaitnumber.Text = "0";
            // 
            // labelsouthwaitnumber
            // 
            this.labelsouthwaitnumber.AutoSize = true;
            this.labelsouthwaitnumber.Location = new System.Drawing.Point(570, 970);
            this.labelsouthwaitnumber.Name = "labelsouthwait";
            this.labelsouthwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelsouthwaitnumber.TabIndex = 14;
            this.labelsouthwaitnumber.Text = "0";
            // 
            // labelwestwaitnumber
            // 
            this.labelwestwaitnumber.AutoSize = true;
            this.labelwestwaitnumber.Location = new System.Drawing.Point(120, 570);
            this.labelwestwaitnumber.Name = "labelwestwait";
            this.labelwestwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelwestwaitnumber.TabIndex = 15;
            this.labelwestwaitnumber.Text = "0";
            // 
            // labeltotalcarspassed
            // 
            this.labeltotalcarspassed.AutoSize = true;
            this.labeltotalcarspassed.Location = new System.Drawing.Point(1000, 100);
            this.labeltotalcarspassed.Name = "labeltotalcarspassed";
            this.labeltotalcarspassed.Size = new System.Drawing.Size(35, 13);
            this.labeltotalcarspassed.TabIndex = 16;
            this.labeltotalcarspassed.Text = "Total Cars Passed: ";
            // 
            // labeltotalwaittime
            // 
            this.labeltotalwaittime.AutoSize = true;
            this.labeltotalwaittime.Location = new System.Drawing.Point(1000, 130);
            this.labeltotalwaittime.Name = "labeltotalwaittime";
            this.labeltotalwaittime.Size = new System.Drawing.Size(35, 13);
            this.labeltotalwaittime.TabIndex = 17;
            this.labeltotalwaittime.Text = "Total Wait Time: ";
            // 
            // labelcyclespassed
            // 
            this.labelcyclespassed.AutoSize = true;
            this.labelcyclespassed.Location = new System.Drawing.Point(1000, 160);
            this.labelcyclespassed.Name = "labelcyclespassed";
            this.labelcyclespassed.Size = new System.Drawing.Size(35, 13);
            this.labelcyclespassed.TabIndex = 18;
            this.labelcyclespassed.Text = "Cycles Passed: ";
            // 
            // labelcycleswithoutchange
            // 
            this.labelcycleswithoutchange.AutoSize = true;
            this.labelcycleswithoutchange.Location = new System.Drawing.Point(1000, 190);
            this.labelcycleswithoutchange.Name = "labelcycleswithoutchange";
            this.labelcycleswithoutchange.Size = new System.Drawing.Size(35, 13);
            this.labelcycleswithoutchange.TabIndex = 19;
            this.labelcycleswithoutchange.Text = "Cycles Without Change: ";
            // 
            // labeltotalcarspassednumber
            // 
            this.labeltotalcarspassednumber.AutoSize = true;
            this.labeltotalcarspassednumber.Location = new System.Drawing.Point(1150, 100);
            this.labeltotalcarspassednumber.Name = "labeltotalcarspassednumber";
            this.labeltotalcarspassednumber.Size = new System.Drawing.Size(35, 13);
            this.labeltotalcarspassednumber.TabIndex = 20;
            this.labeltotalcarspassednumber.Text = "0";
            // 
            // labeltotalwaittimenumber
            // 
            this.labeltotalwaittimenumber.AutoSize = true;
            this.labeltotalwaittimenumber.Location = new System.Drawing.Point(1150, 130);
            this.labeltotalwaittimenumber.Name = "labeltotalwaittimenumber";
            this.labeltotalwaittimenumber.Size = new System.Drawing.Size(35, 13);
            this.labeltotalwaittimenumber.TabIndex = 21;
            this.labeltotalwaittimenumber.Text = "0";
            // 
            // labelcyclespassednumber
            // 
            this.labelcyclespassednumber.AutoSize = true;
            this.labelcyclespassednumber.Location = new System.Drawing.Point(1150, 160);
            this.labelcyclespassednumber.Name = "labelcyclespassednumber";
            this.labelcyclespassednumber.Size = new System.Drawing.Size(35, 13);
            this.labelcyclespassednumber.TabIndex = 22;
            this.labelcyclespassednumber.Text = "0";
            // 
            // labelcycleswithoutchangenumber
            // 
            this.labelcycleswithoutchangenumber.AutoSize = true;
            this.labelcycleswithoutchangenumber.Location = new System.Drawing.Point(1150, 190);
            this.labelcycleswithoutchangenumber.Name = "labelcycleswithoutchangenumber";
            this.labelcycleswithoutchangenumber.Size = new System.Drawing.Size(35, 13);
            this.labelcycleswithoutchangenumber.TabIndex = 23;
            this.labelcycleswithoutchangenumber.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelnorth);
            this.Controls.Add(this.labeleast);
            this.Controls.Add(this.labelsouth);
            this.Controls.Add(this.labelwest);
            this.Controls.Add(this.labelnorthwait);
            this.Controls.Add(this.labeleastwait);
            this.Controls.Add(this.labelsouthwait);
            this.Controls.Add(this.labelwestwait);
            this.Controls.Add(this.labelnorthwaitnumber);
            this.Controls.Add(this.labeleastwaitnumber);
            this.Controls.Add(this.labelsouthwaitnumber);
            this.Controls.Add(this.labelwestwaitnumber);
            this.Controls.Add(this.labeltotalcarspassed);
            this.Controls.Add(this.labeltotalwaittime);
            this.Controls.Add(this.labelcyclespassed);
            this.Controls.Add(this.labelcycleswithoutchange);
            this.Controls.Add(this.labeltotalcarspassednumber);
            this.Controls.Add(this.labeltotalwaittimenumber);
            this.Controls.Add(this.labelcyclespassednumber);
            this.Controls.Add(this.labelcycleswithoutchangenumber);

            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.Paint += this.TekenFourWay;
            //this.Shown += StartSimulation;
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

