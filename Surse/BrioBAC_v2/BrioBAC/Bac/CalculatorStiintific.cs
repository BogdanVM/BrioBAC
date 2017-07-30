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
    public partial class CalculatorStiintific : Form
    {
       Double results = 0;
       String operation = "";
       bool enter_value = false;
       float iCelsius, iFahrenheit, iKelvin;
      
       char iOperation;
        public CalculatorStiintific()
        {
            InitializeComponent();
        }

       

        private void stiintificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 523;
            textBox1.Width = 484;
        }

        private void Calculator1_Load(object sender, EventArgs e)
        {
            this.Width = 270;
            textBox1.Width = 230;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 270;
            textBox1.Width = 230;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

   

        private void temperaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 940;
            textBox1.Width = 484;
            textBox2.Focus();
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = false;

            groupBox1.Location = new Point(515, 27);
            groupBox1.Width = 403;
            groupBox1.Height = 334;
        }

        private void transformariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 940;
            textBox1.Width = 484;
        }

        private void multiplicariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 940;
            textBox1.Width = 484;
            textBoxMultiply.Focus();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true ;
            groupBox3.Location = new Point (515,27);
            groupBox3.Width = 403;
            groupBox3.Height = 334;
        }

        private void Button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text =="0") ||( enter_value))
                textBox1.Text = "";
            enter_value = false;
            Button num = (Button)sender;
            if (num.Text == ",")
            {
                if (!textBox1.Text.Contains(","))
                    textBox1.Text = textBox1.Text + num.Text;
            }
            else
                textBox1.Text = textBox1.Text + num.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            lblShiwOp.Text = "";
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
          
            lblShiwOp.Text = "";
                  
            switch (operation)
            {
                case"+":
                    textBox1.Text=(results+Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (results - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (results * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (results / Double.Parse(textBox1.Text)).ToString();
                    break;
                case "Mod":
                    textBox1.Text = (results % Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
                  
                
            }
      
        }

        private void button40_Click(object sender, EventArgs e)
        {
            textBox1.Text = "3.1415926535";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("log" + "(" + (textBox1.Text) + ")");
            ilog = Math.Log10(ilog);
            textBox1.Text = System.Convert.ToString(ilog);
           
        }

        private void button38_Click(object sender, EventArgs e)
        {
            double sq = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("sqrt" + "(" + (textBox1.Text) + ")");
            sq = Math.Sqrt(sq);
            textBox1.Text = System.Convert.ToString(sq);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            double sinh1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("sinh" + "(" + (textBox1.Text) + ")");
            sinh1 = Math.Sinh(sinh1);
            textBox1.Text = System.Convert.ToString(sinh1);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            double sin1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("sin" + "(" + (textBox1.Text) + ")");
            sin1 = Math.Sin(sin1);
            textBox1.Text = System.Convert.ToString(sin1);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            double cosh1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("cosh" + "(" + (textBox1.Text) + ")");
            cosh1 = Math.Sinh(cosh1);
            textBox1.Text = System.Convert.ToString(cosh1);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            double cos1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("cos" + "(" + (textBox1.Text) + ")");
            cos1 = Math.Cos(cos1);
            textBox1.Text = System.Convert.ToString(cos1);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            double tanh1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("tanh" + "(" + (textBox1.Text) + ")");
            tanh1 = Math.Tanh(tanh1);
            textBox1.Text = System.Convert.ToString(tanh1);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            double tan1 = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("tan" + "(" + (textBox1.Text) + ")");
            tan1 = Math.Tan(tan1);
            textBox1.Text = System.Convert.ToString(tan1);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a, 2);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a, 16);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a, 8);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(1.0/ Convert.ToDouble(textBox1.Text));
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("log" + "(" + (textBox1.Text) + ")");
            ilog = Math.Log(ilog);
            textBox1.Text = System.Convert.ToString(ilog);
           
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Double a;
            a = Convert.ToDouble(textBox1.Text) / Convert.ToDouble(100);
            textBox1.Text = System.Convert.ToString(a);
        }

        private void rbCtoF_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'C';
        }

        private void rbFtoC_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'F';
        }

        private void rbK_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'K';
        }

        private void button42_Click(object sender, EventArgs e)
        {
            switch (iOperation)
            {
                case 'C':
                iCelsius=float.Parse(textBox2.Text);
                textBox3.Text=((((9*iCelsius)/5)+32).ToString());
                break;
                case 'F':
                iFahrenheit = float.Parse(textBox2.Text);
                textBox3.Text = ((((iFahrenheit-32) *5)/9).ToString());
                break;
                case 'K':
                iKelvin = float.Parse(textBox2.Text);
                textBox3.Text = ((((iKelvin + 459.67) *5) /9).ToString());
                break;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Text = "";
            rbCtoF.Checked = false;
            rbFtoC.Checked = false;
            rbK.Checked = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(textBoxMultiply.Text);
            for (int i = 1; i < 21; i++)
            {

                listMultiply.Items.Add(i + "x" + a + "=" + a * i);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void button44_Click(object sender, EventArgs e)
        {
            listMultiply.Items.Clear();
            textBoxMultiply.Clear() ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(textBox1.Text);
            a = -a;
            textBox1.Text = System.Convert.ToString(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text;
            results = Double.Parse(textBox1.Text);
            textBox1.Text = "";
            enter_value = true;
            lblShiwOp.Text = System.Convert.ToString(results) + " " + operation;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            double exp=1;
            double a = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("10^" + "(" + (textBox1.Text) + ")");
            for(int i=1;i<=a;i++)
            exp =exp*10;
            textBox1.Text = System.Convert.ToString(exp);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(textBox1.Text);
            lblShiwOp.Text = System.Convert.ToString("mod" + "(" + (textBox1.Text) + ")");
            double b = Double.Parse(textBox1.Text);
            while (a > b)
                a = a - b;
            textBox1.Text = System.Convert.ToString(a);
        
        }

        private void deschidetiFereastraDeAjutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajutor x = new Ajutor();
            x.Show();
        }

        private void CalculatorStiintific_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

     
        
      
       
        

       

       

     
    }
}
