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
        private ComboBox comboBox1 = new ComboBox();

        private void InitializeComponent(string whatIntersection)
        {
            this.ClientSize = new System.Drawing.Size(1320, 663);


            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";



            switch (whatIntersection)
            {
                case "fourwayIntersection":
                    this.fourwayIntersection();
                    this.Paint += this.Teken;
                    break;
                case "fourwayWithLeftLane":
                    this.fourwayWithLeftLane();
                    break;
                default:
                    this.fourwayIntersection();
                    this.Paint += this.Teken;
                    break;
            }

            //this.Shown += StartSimulation;
            //this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

