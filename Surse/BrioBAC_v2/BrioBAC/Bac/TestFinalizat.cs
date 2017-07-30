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
    public partial class TestFinalizat : Form
    {
        public TestFinalizat()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            progressBar2.Hide();
            float procentaj = (Autentificare.score * 100) / 30;
            label5.Text = Autentificare.score + " intrebari corecte din 30 (" + procentaj + "%)";
            label6.Text = TestIQ.timp_total / 1000 + " secunde";
            label7.Text = TestIQ.timp_mediu / 1000 + " secunde";

            if (Autentificare.iq < Autentificare.score)
            {
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

                path += "Bac.mdf"; // La calea catre fiserul unde se afla baza de date adaugam si denumirea acesteia
                using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + path + ";Integrated Security=True;User Instance=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(@"update Conturi set TestIQ = @iqT, Timp = @timp WHERE Conectat = 1", con);


                    cmd.Parameters.AddWithValue("@iqT", Autentificare.score);
                    cmd.Parameters.AddWithValue("@timp", TestIQ.timp_total / 1000);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button1WasClicked)
            {
                button1WasClicked = false;
            }
            this.timer3.Start();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1WasClicked = true;
            this.timer3.Start();

           
        }
        private bool button1WasClicked = false;

        
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            progressBar2.Show();
            this.progressBar2.Increment(11);
            if (Convert.ToInt32(progressBar2.Value) > 99)
            {
                timer3.Enabled = false;
                if (button1WasClicked)
                {
                    this.Close();
                    Informatii x = new Informatii();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TestFinalizat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(this,new EventArgs());
            }
        }

    }
}
