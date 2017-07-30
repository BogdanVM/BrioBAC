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
    public partial class TestNefinalizat : Form
    {
        public TestNefinalizat()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            progressBar2.Hide();
            float procentaj = (Autentificare.score * 100) / 30;
            label5.Text = Autentificare.score + " intrebari corecte din 30 (" + procentaj + "%)";
            label6.Text = TestIQ.timp_total/1000 + " secunde";
            label7.Text = TestIQ.timp_mediu/1000 + " secunde";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Meniu.corecte = 0;
            Meniu.gresite = 0;

            TestIQ.timp_total = 0;
            TestIQ.timp_mediu = 0;
            Autentificare.score = 0;
           
            Meniu.nr_rasp = 0;
            Meniu.id_intrebare = 1;
            if (button1WasClicked)
            {
                button1WasClicked = false;
            }
            this.timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.timer1.Start();
            TestIQ.timp_total = 0;
            TestIQ.timp_mediu = 0;
            Autentificare.score = 0;
            Meniu.corecte = 0;
            Meniu.gresite = 0;
            Meniu.nr_rasp = 0;
            Meniu.id_intrebare = 1;
        }
        private bool button1WasClicked = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar2.Show();
            this.progressBar2.Increment(11);
            if (Convert.ToInt32(progressBar2.Value) > 99)
            {
                timer1.Enabled = false;
                if (button1WasClicked)
                {
                    this.Close();
                    TestIQ x = new TestIQ();
                    x.Show();
                    
                }
                else
                {
                    this.Close();
                    Meniu x = new Meniu();
                    x.Show();
                  
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void TestNefinalizat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(this,new EventArgs());
            }

        }
    }
}
