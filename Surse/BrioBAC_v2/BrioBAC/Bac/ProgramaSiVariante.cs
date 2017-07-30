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
    public partial class ProgramaSiVariante : Form
    {
        public ProgramaSiVariante()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        

       
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Programa.pdf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Variante.pdf");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalculatorStiintific x = new CalculatorStiintific();
            x.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CalculatorStiintific x = new CalculatorStiintific();
            x.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("SolutiiVariante.pdf");
        }

        private void ProgramaSiVariante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox7_Click(this,new EventArgs());
            }

        }
    }
}
