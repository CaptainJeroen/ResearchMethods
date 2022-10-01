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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1161, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "North: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1161, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "East: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1161, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "South: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1161, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "West: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 663);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public void Panel()
        {
            this.Paint += this.Teken;
        }

        void Teken(object obj, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
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

            g.DrawLine(Pens.Black, 400, 100, 400, 400);
            g.DrawLine(Pens.Black, 100, 400, 400, 400);

            g.DrawLine(Pens.Black, 600, 100, 600, 400);
            g.DrawLine(Pens.Black, 600, 400, 900, 400);

            g.DrawLine(Pens.Black, 400, 600, 400, 900);
            g.DrawLine(Pens.Black, 100, 600, 400, 600);

            g.DrawLine(Pens.Black, 600, 600, 600, 900);
            g.DrawLine(Pens.Black, 600, 600, 900, 600);

            g.FillEllipse(hor, 425, 325, 50, 50);
            g.FillEllipse(hor, 525, 625, 50, 50);

            g.FillEllipse(ver, 325, 525, 50, 50);
            g.FillEllipse(ver, 625, 425, 50, 50);

        }

        private Label label1 = new Label();
        private Label label2;
        private Label label3;
        private Label label4;
    }
}

