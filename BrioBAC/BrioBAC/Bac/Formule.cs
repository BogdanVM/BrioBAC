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
    public partial class Formule : Form
    {
        public Formule()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("2016iuliemateinfosub.pdf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"CalculPrescurtat.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Ecuatia.png");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Puteri.jpg");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Combinatorica1.png");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Combinatorica2.png");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Combinatorica3.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Progresii.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Trigonometrie.png");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button15.Visible = true;
            button16.Visible = true;
            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Derivate1.png");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Derivate2.png");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Matrici1.png");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Matrici2.png");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button17.Visible = true;
            button18.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
          
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button19.Visible = true;
            button20.Visible = true;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Integrale1.png");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Integrale2.png");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void Formule_Load(object sender, EventArgs e)
        {

        }

        private void Formule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox2_Click(this,new EventArgs());
            }
        }
    }
}
