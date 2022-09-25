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
            this.SuspendLayout();
            // 
            // Form1
            // 
            //this.carsleft.Location = new Point()

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1980, 1020);
            this.Name = "Form1";
            this.Text = "Intersection Disection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

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
    }
}

