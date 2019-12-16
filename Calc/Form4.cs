using System;

namespace Calc
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4(int i)
        {
            InitializeComponent();
            if (i == 1) {
                pictureBox3.Visible = true;
                pictureBox2.Visible = true;
            }
            else {
                pictureBox7.Visible = true;
                pictureBox8.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible=true;
            timer1.Interval = 3500;
            timer1.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible = true;
            timer1.Interval = 3500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            timer1.Stop();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            metroPanel1.Visible = true;
            timer1.Interval = 3500;
            timer1.Start();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            metroPanel2.Visible = true;
            timer1.Interval = 3500;
            timer1.Start();
        }
    }
}
