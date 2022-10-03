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
        private void InitializeComponent()
        {


            Init();
        }

        private void Init()
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
            this.ResumeLayout(false);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.FourwayIntersection();
            this.Paint += this.Teken;
            this.ResumeLayout(false);
            this.PerformLayout();
            //string temp = "fourwayIntersection";
            //switch (temp)
            //{
            //    case "fourwayIntersection":

            //        break;
            //    case "fourwayWithLeftLane":
            //        this.fourwayWithLeftLane();
            //        break;
            //    default:
            //        this.fourwayIntersection();
            //        this.Paint += this.Teken;
            //        break;
            //}
        }
        private void FourwayIntersection()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelnorth = new System.Windows.Forms.Label();
            this.labeleast = new System.Windows.Forms.Label();
            this.labelsouth = new System.Windows.Forms.Label();
            this.labelwest = new System.Windows.Forms.Label();
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
            throw new NotImplementedException();
        }
        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

