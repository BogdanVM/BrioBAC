using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bac
{ 
    public partial class TestIQ : Form
    {
       public static string c="0";
       public static float timp_total = 0;
  
       public static float timp_mediu = 0;
       
       float duration = 60000;
       
       
        public TestIQ()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        public void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 6;
            if (Meniu.id_intrebare <= 30)
            {
                if (Meniu.corect == 6)
                {
                

                    Autentificare.score++;
                    Meniu.corecte++;
                  
                    
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {

                    Meniu.gresite++;
                  
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                
                if (Meniu.corect == 6)
                {
                    Meniu.corecte++;

                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2= new TestFinalizat();
                f2.Show();

            }
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 0;
            if (Meniu.id_intrebare == 31)
            {
                label3.Click -= label3_Click;
            }
            else
            {
                this.Close();

                TestIQ f2 = new TestIQ();
                f2.Show();
            }
        }

        public void label5_Click(object sender, EventArgs e)
        {

        }

        public void Form2_Load(object sender, EventArgs e)
        {

            timer1.Start();

            if (Meniu.id_intrebare == 31)
            {
                timp_total = 0;
                timp_mediu = 0;
                Autentificare.score = 0;
                Meniu.corecte = 0;
                Meniu.gresite = 0;

                Meniu.nr_rasp = 0;
                Meniu.id_intrebare = 1;
            }
                label6.Text = "intrebarea " + Meniu.id_intrebare + "/30";

                //string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //string path = (System.IO.Path.GetDirectoryName(executable));
                //string conStringPath = path + "\\Bac.mdf";

                string location = System.Reflection.Assembly.GetEntryAssembly().Location;  //Scoatem locatia proiectului (inclusiv /bin/debug)
                string[] paths = location.Split('\\');/* Impartim calea in mai multe siruri de caractere in functie de caracterul '\'.De exemplu, location = "C:\My Documents\Proiect\..."
                                                   * Atunci, paths[0] = "C:";
                                                   * paths[1] = "My Documents";
                                                   * paths[2] = "Proiect" etc.
                                                   */

                string path = ""; // Initializam sirul de caractere in care vom memora calea catre baza de date

                for (int index = 0; index < paths.Length - 3; index++) // Parcurgem fiecare sir de caractere in afara de "bin" si "Debug"
                {
                    path += paths[index] + '\\';  // Completam calea catre baza de date
                }

                path += "Bac.mdf";
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + path + ";Integrated Security=True;User Instance=True"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM Intrebari WHERE ID = @id", con);
                    cmd.Parameters.AddWithValue("@id", Meniu.id_intrebare);

                    SqlDataReader reader = cmd.ExecuteReader();


                    if (reader.Read())
                    {

                        Image intrebare = Image.FromFile(reader["Intrebare"].ToString());
                        Image raspuns1 = Image.FromFile(reader["Raspuns_1"].ToString());
                        Image raspuns2 = Image.FromFile(reader["Raspuns_2"].ToString());
                        Image raspuns3 = Image.FromFile(reader["Raspuns_3"].ToString());
                        Image raspuns4 = Image.FromFile(reader["Raspuns_4"].ToString());
                        Image raspuns5 = Image.FromFile(reader["Raspuns_5"].ToString());
                        Image raspuns6 = Image.FromFile(reader["Raspuns_6"].ToString());

                        intrebarePic.Image = intrebare;
                        Rasp_1.Image = raspuns1;
                        Rasp_2.Image = raspuns2;
                        Rasp_3.Image = raspuns3;
                        Rasp_4.Image = raspuns4;
                        Rasp_5.Image = raspuns5;
                        Rasp_6.Image = raspuns6;

                        Meniu.corect = Convert.ToInt32(reader["Raspuns_corect"].ToString());

                        Meniu.rasp_corect[++Meniu.nr_corect] = Meniu.corect;

                        Meniu.id_intrebare++;
                    }
                    else
                    {
                        MessageBox.Show("Ai raspuns corect la " + Autentificare.score + " intrebari din 30");
                    }
                    label8.Text = Meniu.corecte.ToString();
                    label10.Text = Meniu.gresite.ToString();
                    reader.Dispose();
                }

               

            
        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        public void label6_Click(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void label2_Click(object sender, EventArgs e)
        {

        }


        public void timer1_Tick(object sender, EventArgs e)
        {
            duration -= timer1.Interval;
            timp_total += timer1.Interval;
            textBox4.Text = (duration / 1000).ToString();
            if (duration == 0)
            {
                Meniu.id_intrebare = 1;
                timer1.Stop();
                this.Close();
                TestNefinalizat f2 = new TestNefinalizat();
                f2.Show();
            }

            
                
               
            
            
            timp_mediu = (float)timp_total / 30;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 1;
            if (Meniu.id_intrebare <= 30)
            {

                if (Meniu.corect == 1)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {
                    Meniu.gresite++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                if (Meniu.corect == 1)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2 = new TestFinalizat();
                f2.Show();

            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 2;
            if (Meniu.id_intrebare <= 30)
            {
                if (Meniu.corect == 2)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {
                    Meniu.gresite++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                if (Meniu.corect == 2)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2 = new TestFinalizat();
                f2.Show();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 3;
            if (Meniu.id_intrebare <= 30)
            {
                if (Meniu.corect == 3)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {
                    Meniu.gresite++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                if (Meniu.corect == 3)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2 = new TestFinalizat();
                f2.Show();

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 4;
            if (Meniu.id_intrebare <= 30)
            {
                if (Meniu.corect == 4)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {
                    Meniu.gresite++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                if (Meniu.corect == 4)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2 = new TestFinalizat();
                f2.Show();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Meniu.array[++Meniu.nr] = 60 - (duration / 1000);
            Meniu.rasp[++Meniu.nr_rasp] = 5;
            if (Meniu.id_intrebare <= 30)
            {
                if (Meniu.corect == 5)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }

                else
                {
                    Meniu.gresite++;
                    this.Close();

                    TestIQ f2 = new TestIQ();
                    f2.Show();
                }
            }
            else
            {
                if (Meniu.corect == 5)
                {
                    Meniu.corecte++;
                    Autentificare.score++;
                    this.Close();
                }
                this.Close();
                TestFinalizat f2 = new TestFinalizat();
                f2.Show();

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        
    }
}
