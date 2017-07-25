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
    public partial class ModInvatare : Form
    {
        public ModInvatare()
        {
            InitializeComponent();
        }

        
       



          
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            System.Diagnostics.Process.Start("11.pdf"); }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Meniu f = new Meniu();
            f.Show();


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("9.pdf");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("10.pdf");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("12.pdf");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculatorStiintific x = new CalculatorStiintific();
            x.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu f = new Meniu();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("10.pdf");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("11.pdf");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("12.pdf");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            CalculatorStiintific x = new CalculatorStiintific();
            x.Show();
        }

        private void ModInvatare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox8_Click(this,new EventArgs());
            }
        }
            
            
        }

     
    }

