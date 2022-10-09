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

        //Standard labels
        private Label labelnorth;
        private Label labeleast;
        private Label labelsouth;
        private Label labelwest;
        private Label labelnorthnumber;
        private Label labeleastnumber;
        private Label labelsouthnumber;
        private Label labelwestnumber;

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
        private Label labeltotalcyclespassed;
        private Label labeltotalcycleswithoutchange;
        private Label labeltotalcarspassednumber;
        private Label labeltotalwaittimenumber;
        private Label labeltotalcyclespassednumber;
        private Label labeltotalcycleswithoutchangenumber;

        //Only needed for extra left lanes intersection
        private Label labelnorthnumber2;
        private Label labeleastnumber2;
        private Label labelsouthnumber2;
        private Label labelwestnumber2;
        private Label labelnorthwaitnumber2;
        private Label labeleastwaitnumber2;
        private Label labelsouthwaitnumber2;
        private Label labelwestwaitnumber2;


        //private void InitializeComponent()
        private ComboBox comboBox1 = new ComboBox();

        private void InitializeComponent(string whatIntersection)
        {
            Init(whatIntersection);
        }

        private void Init(string whatIntersection)
        {
            this.labelnorth = new System.Windows.Forms.Label();
            this.labelnorth.Name = "labelnorth";
            this.labelnorth.Text = "North: ";
            this.labeleast = new System.Windows.Forms.Label();
            this.labeleast.Name = "labeleast";
            this.labeleast.Text = "East: ";
            this.labelsouth = new System.Windows.Forms.Label();
            this.labelsouth.Name = "labelsouth";
            this.labelsouth.Text = "South: ";
            this.labelwest = new System.Windows.Forms.Label();
            this.labelwest.Name = "labelwest";
            this.labelwest.Text = "West: ";
            this.labelnorthnumber = new System.Windows.Forms.Label();
            this.labelnorthnumber.Name = "labelnorthnumber";
            this.labeleastnumber = new System.Windows.Forms.Label();
            this.labeleastnumber.Name = "labeleastnumber";
            this.labelsouthnumber = new System.Windows.Forms.Label();
            this.labelsouthnumber.Name = "labelsouthnumber";
            this.labelwestnumber = new System.Windows.Forms.Label();
            this.labelwestnumber.Name = "labelwestnumber";

            this.labelnorthwait = new System.Windows.Forms.Label();
            this.labelnorthwait.Name = "labelnorthwait";
            this.labelnorthwait.Text = "WaitCyles";
            this.labeleastwait = new System.Windows.Forms.Label();
            this.labeleastwait.Name = "labeleastwait";
            this.labeleastwait.Text = "WaitCyles";
            this.labelsouthwait = new System.Windows.Forms.Label();
            this.labelsouthwait.Name = "labelsouthwait";
            this.labelsouthwait.Text = "WaitCyles";
            this.labelwestwait = new System.Windows.Forms.Label();
            this.labelwestwait.Name = "labelwestwait";
            this.labelwestwait.Text = "WaitCyles";
            this.labelnorthwaitnumber = new System.Windows.Forms.Label();
            this.labelnorthwaitnumber.Name = "labelnorthwaitnumber";
            this.labeleastwaitnumber = new System.Windows.Forms.Label();
            this.labeleastwaitnumber.Name = "labeleastwaitnumber";
            this.labelsouthwaitnumber = new System.Windows.Forms.Label();
            this.labelsouthwaitnumber.Name = "labelsouthwaitnumber";
            this.labelwestwaitnumber = new System.Windows.Forms.Label();
            this.labelwestwaitnumber.Name = "labelwestwaitnumber";

            this.labeltotalcarspassed = new System.Windows.Forms.Label();
            this.labeltotalcarspassed.Name = "labeltotalcarspassed";
            this.labeltotalcarspassed.Text = "Total Cars Passed: ";
            this.labeltotalwaittime = new System.Windows.Forms.Label();
            this.labeltotalwaittime.Name = "labeltotalwaittime";
            this.labeltotalwaittime.Text = "Total Wait Time: ";
            this.labeltotalcyclespassed = new System.Windows.Forms.Label();
            this.labeltotalcyclespassed.Name = "labeltotalcyclespassed";
            this.labeltotalcyclespassed.Text = "Total Cycles Passed: ";
            this.labeltotalcycleswithoutchange = new System.Windows.Forms.Label();
            this.labeltotalcycleswithoutchange.Name = "labeltotalcycleswithoutchange";
            this.labeltotalcycleswithoutchange.Text = "Total Cycles Without Change: ";
            this.labeltotalcarspassednumber = new System.Windows.Forms.Label();
            this.labeltotalcarspassednumber.Name = "labeltotalcarspassednumber";
            this.labeltotalwaittimenumber = new System.Windows.Forms.Label();
            this.labeltotalwaittimenumber.Name = "labeltotalwaittimenumber";
            this.labeltotalcyclespassednumber = new System.Windows.Forms.Label();
            this.labeltotalcyclespassednumber.Name = "labeltotalcyclespassednumber";
            this.labeltotalcycleswithoutchangenumber = new System.Windows.Forms.Label();
            this.labeltotalcycleswithoutchangenumber.Name = "labeltotalcycleswithoutchangenumber";

            this.Controls.Add(this.labelnorth);
            this.Controls.Add(this.labeleast);
            this.Controls.Add(this.labelsouth);
            this.Controls.Add(this.labelwest);
            this.Controls.Add(this.labelnorthnumber);
            this.Controls.Add(this.labeleastnumber);
            this.Controls.Add(this.labelsouthnumber);
            this.Controls.Add(this.labelwestnumber);
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
            this.Controls.Add(this.labeltotalcyclespassed);
            this.Controls.Add(this.labeltotalcycleswithoutchange);
            this.Controls.Add(this.labeltotalcarspassednumber);
            this.Controls.Add(this.labeltotalwaittimenumber);
            this.Controls.Add(this.labeltotalcyclespassednumber);
            this.Controls.Add(this.labeltotalcycleswithoutchangenumber);

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
                    this.fourwayIntersection();
                    this.fourwayWithLeftLane();
                    this.Paint += this.TekenFourWayWithLeftLane;
                    break;
                default:
                    //this.fourwayIntersection();
                    this.Paint += this.TekenFourWay;
                    break;
            }

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;


            //this.Shown += StartSimulation;
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        //Defines the labels for a standard fourway intersection
        private void fourwayIntersection()
        {
            int x = 600;
            int x2 = 680;
            int y = 100;
            int k = 20;
            int k2 = 500;

            int controlmin = 0;
            int countname = 1;
            int countnamenumber = 1;
            int countcycles = 1;
            int countcyclesnumber = 1;
            int counttotals = 1;
            int counttotalsnumber = 1;

            for (int t = 0; t < Controls.Count; t++)
            {
                Control c = this.Controls[t];


                if (c is Label)
                {
                    c.AutoSize = true;
                    c.Size = new System.Drawing.Size(35, 13);
                    c.TabIndex = t - controlmin;

                    if (c.Name.Contains("total"))
                    {
                        if (c.Name.Contains("number"))
                        {
                            c.Location = new System.Drawing.Point(x2 + 80, counttotalsnumber * k + k2 );
                            counttotalsnumber++;
                        }
                        else
                        {
                            c.Location = new System.Drawing.Point(x, counttotals * k + k2);
                            counttotals++;
                        }
                    }
                    else
                    {
                        if (c.Name.Contains("wait"))
                        {
                            if (c.Name.Contains("number"))
                            {
                                c.Location = new System.Drawing.Point(x2, countcyclesnumber * y + k);
                                c.Text = "0";
                                countcyclesnumber++;
                            }
                            else
                            {
                                c.Location = new System.Drawing.Point(x, countcycles * y + k);
                                countcycles++;
                            }
                        }
                        else
                        {
                            if (c.Name.Contains("number"))
                            {
                                c.Location = new System.Drawing.Point(x2, countnamenumber * y);
                                c.Text = "0";
                                countnamenumber++;
                            }
                            else
                            {
                                c.Location = new System.Drawing.Point(x, countname * y);
                                countname++;
                            }
                        }
                    }                    
                }
                else
                {
                    controlmin++;
                }
            }
        }

        //Defines the extra lanes needed for a fourlane intersection with extra left lane.
        private void fourwayWithLeftLane()
        {
            this.labelnorthnumber2 = new System.Windows.Forms.Label();
            this.labelnorthnumber2.Name = "labelnorthnumber2";
            this.labeleastnumber2 = new System.Windows.Forms.Label();
            this.labeleastnumber2.Name = "labeleastnumber2";
            this.labelsouthnumber2 = new System.Windows.Forms.Label();
            this.labelsouthnumber2.Name = "labelsouthnumber2";
            this.labelwestnumber2 = new System.Windows.Forms.Label();
            this.labelwestnumber2.Name = "labelwestnumber2";

            this.labelnorthwaitnumber2 = new System.Windows.Forms.Label();
            this.labelnorthwaitnumber2.Name = "labelnorthwaitnumber2";
            this.labeleastwaitnumber2 = new System.Windows.Forms.Label();
            this.labeleastwaitnumber2.Name = "labeleastwaitnumber2";
            this.labelsouthwaitnumber2 = new System.Windows.Forms.Label();
            this.labelsouthwaitnumber2.Name = "labelsouthwaitnumber2";
            this.labelwestwaitnumber2 = new System.Windows.Forms.Label();
            this.labelwestwaitnumber2.Name = "labelwestwaitnumber2";

            this.Controls.Add(this.labelnorthnumber2);
            this.Controls.Add(this.labeleastnumber2);
            this.Controls.Add(this.labelsouthnumber2);
            this.Controls.Add(this.labelwestnumber2);

            this.Controls.Add(this.labelnorthwaitnumber2);
            this.Controls.Add(this.labeleastwaitnumber2);
            this.Controls.Add(this.labelsouthwaitnumber2);
            this.Controls.Add(this.labelwestwaitnumber2);

            int x = 600;
            int x2 = 680;
            int x3 = 760;
            int y = 100;
            int k = 20;

            int controlmin = 0;
            int countx4 = 1;
            int countx3 = 1;
            int countx2 = 1;
            int countx = 1;

            for (int t = 0; t < Controls.Count; t++)
            {
                Control c = this.Controls[t];

                if (c is Label && c.Location.IsEmpty)
                {
                    c.AutoSize = true;
                    c.Size = new System.Drawing.Size(35, 13);
                    c.TabIndex = t - controlmin;

                    if (c.Name.Contains("2"))
                    {
                        if (c.Name.Contains("wait"))
                        {
                            c.Location = new System.Drawing.Point(x3, countx3 * y + k);
                            c.Text = "0";
                            countx3++;
                        }
                        else
                        {
                            c.Location = new System.Drawing.Point(x3, countx4 * y);
                            c.Text = "0";
                            countx4++;
                        }
                    }
                    else
                    {
                        if (c.Name.Contains("wait"))
                        {
                            if (c.Name.Contains("number"))
                            {
                                c.Location = new System.Drawing.Point(x2, countx2 * y + k);
                                c.Text = "0";
                                countx2++;
                            }
                            else
                            {
                                c.Location = new System.Drawing.Point(x, countx * y + k);
                                countx++;
                            }
                        }
                        else
                        {
                            if (c.Name.Contains("number"))
                            {
                                c.Location = new System.Drawing.Point(x2, countx2 * y);
                                c.Text = "0";
                                countx2++;
                            }
                            else
                            {
                                c.Location = new System.Drawing.Point(x, countx * y);
                                countx++;
                            }
                        }
                    }
                }
                else
                {
                    controlmin++;
                }
            }
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

