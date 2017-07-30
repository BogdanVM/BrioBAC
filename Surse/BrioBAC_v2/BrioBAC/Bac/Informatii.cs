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
    public partial class Informatii : Form
    {
        public Informatii()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void Form6_Load(object sender, EventArgs e)
        {
          
            for (int i = 1; i <= 30; i++)
            {
                this.chart1.Series["Progres"].Points.AddXY(i, Meniu.array[i]);
            }
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = false;
            int nr = 1;
            label20.Text = Meniu.rasp[nr].ToString();
            label18.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label26.Text = Meniu.rasp[nr].ToString();
            label27.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label23.Text = Meniu.rasp[nr].ToString();
            label24.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label10.Text = Meniu.rasp[nr].ToString();
            label11.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label3.Text = Meniu.rasp[nr].ToString();
            label8.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label16.Text = Meniu.rasp[nr].ToString();
            label14.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label13.Text = Meniu.rasp[nr].ToString();
            label28.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label45.Text = Meniu.rasp[nr].ToString();
            label43.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label42.Text = Meniu.rasp[nr].ToString();
            label46.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label51.Text = Meniu.rasp[nr].ToString();
            label49.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label48.Text = Meniu.rasp[nr].ToString();
            label40.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label33.Text = Meniu.rasp[nr].ToString();
            label31.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label30.Text = Meniu.rasp[nr].ToString();
            label34.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label39.Text = Meniu.rasp[nr].ToString();
            label37.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label36.Text = Meniu.rasp[nr].ToString();
            label7.Text = Meniu.rasp_corect[nr].ToString(); nr++;

            label64.Text = Meniu.rasp[nr].ToString();
            label62.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label67.Text = Meniu.rasp[nr].ToString();
            label71.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label70.Text = Meniu.rasp[nr].ToString();
            label68.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label54.Text = Meniu.rasp[nr].ToString();
            label55.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label6.Text = Meniu.rasp[nr].ToString();
            label52.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label60.Text = Meniu.rasp[nr].ToString();
            label61.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label57.Text = Meniu.rasp[nr].ToString();
            label58.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label89.Text = Meniu.rasp[nr].ToString();
            label90.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label86.Text = Meniu.rasp[nr].ToString();
            label87.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label95.Text = Meniu.rasp[nr].ToString();
            label96.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label92.Text = Meniu.rasp[nr].ToString();
            label93.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label77.Text = Meniu.rasp[nr].ToString();
            label78.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label74.Text = Meniu.rasp[nr].ToString();
            label75.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label83.Text = Meniu.rasp[nr].ToString();
            label84.Text = Meniu.rasp_corect[nr].ToString(); nr++;
            label80.Text = Meniu.rasp[nr].ToString();
            label81.Text = Meniu.rasp_corect[nr].ToString(); nr++;

            

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

       

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
           
            
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel2.Visible = true;
              
                label97.Text = "Pagina 2/2";
                button5.Visible = false;
                button2.Visible = true;
            
        
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = false;

            label97.Text = "Pagina 1/2";
            button2.Visible = false;
            button5.Visible = true;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Meniu f = new Meniu();
            f.Show();
            this.Close();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Informatii_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button1_Click_1(this, new EventArgs());
            }
        }

       
    }
}
