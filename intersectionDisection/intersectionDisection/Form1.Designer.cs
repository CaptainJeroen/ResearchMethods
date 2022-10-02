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

        private void InitializeComponent()
        {
            this.ClientSize = new System.Drawing.Size(1320, 663);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelnorth = new System.Windows.Forms.Label();
            this.labeleast  = new System.Windows.Forms.Label();
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
            this.labelnorthwaitnumber.Location = new System.Drawing.Point(435, 70);
            this.labelnorthwaitnumber.Name = "labelnorthwaitnumber";
            this.labelnorthwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelnorthwaitnumber.TabIndex = 12;
            this.labelnorthwaitnumber.Text = "0";
            // 
            // labeleastwaitnumber
            // 
            this.labeleastwaitnumber.AutoSize = true;
            this.labeleastwaitnumber.Location = new System.Drawing.Point(985, 470);
            this.labeleastwaitnumber.Name = "labeleastwait";
            this.labeleastwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labeleastwaitnumber.TabIndex = 13;
            this.labeleastwaitnumber.Text = "0";
            // 
            // labelsouthwaitnumber
            // 
            this.labelsouthwaitnumber.AutoSize = true;
            this.labelsouthwaitnumber.Location = new System.Drawing.Point(535, 970);
            this.labelsouthwaitnumber.Name = "labelsouthwait";
            this.labelsouthwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelsouthwaitnumber.TabIndex = 14;
            this.labelsouthwaitnumber.Text = "0";
            // 
            // labelwestwaitnumber
            // 
            this.labelwestwaitnumber.AutoSize = true;
            this.labelwestwaitnumber.Location = new System.Drawing.Point(85, 570);
            this.labelwestwaitnumber.Name = "labelwestwait";
            this.labelwestwaitnumber.Size = new System.Drawing.Size(35, 13);
            this.labelwestwaitnumber.TabIndex = 15;
            this.labelwestwaitnumber.Text = "0";
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.Paint += this.Teken;
            //this.Shown += StartSimulation;
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion


        


    }
}

