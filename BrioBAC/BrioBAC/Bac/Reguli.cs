using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bac
{
    public partial class Reguli : Form
    {
        public Reguli()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Show();
            this.progressBar1.Increment(11);
            if (Convert.ToInt32(progressBar1.Value) > 99)
            {
                timer1.Enabled = false;
                this.Close();
                TestIQ x = new TestIQ();
                x.Show();

            }

        
        }
        private void button1_Click(object sender, EventArgs e)
        {
           this.timer1.Start();

           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void Reguli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox8_Click(this,new EventArgs());
            }
        }

       

        
    }
}
