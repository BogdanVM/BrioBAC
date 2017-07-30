using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;


namespace Bac
{
    public partial class Meniu : Form
    {
        private SoundPlayer soundplayer;
        Timer t = new Timer();
        public Meniu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            soundplayer = new SoundPlayer("Study Music.wav");
           
           
           
        }

        public static int id_intrebare = 1, corect, corecte = 0, gresite = 0;
        public static float[] array = new float[350];
        public static int nr = 0, nr_rasp = 0, nr_corect = 0;
        public static int[] rasp = new int[350];
        public static int[] rasp_corect = new int[350];

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            Date.Text = DateTime.Now.ToLongDateString();
            
           
                
        }
     
    
        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;

            }
            else
            {
                time += ss;
            }
            Clock.Text = time;
        }

     
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setari x = new Setari();
            x.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reguli f2 = new Reguli();
            f2.Show();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TesteSiExamene x = new TesteSiExamene();
            
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModInvatare x = new ModInvatare();
           
            x.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProgramaSiVariante x = new ProgramaSiVariante();
            x.Show();
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
       
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand(@"update Conturi set Conectat = @con, TimpTotalStudiu = @timpSt WHERE Conectat = 1", con);

                DateTime now = DateTime.Now;

                string timpTrecut = (Autentificare.conectare - now).ToString();

                string secunde = "";
                for (int i = 7; i < 12; i++)
                {
                    secunde += timpTrecut[i];
                }

                double timp_total_studiu = double.Parse(secunde) + double.Parse(Autentificare.timp_studiu);

                cmd.Parameters.AddWithValue("@con", 0);
                cmd.Parameters.AddWithValue("@timpSt", timp_total_studiu / 100);

                cmd.ExecuteNonQuery();
            }


            soundplayer.Stop();
            this.Hide();
            Autentificare x = new Autentificare();
            x.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            Browser x = new Browser();
            x.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProfilUtilizator x = new  ProfilUtilizator();
            x.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        
        {
            this.Hide();
            Formule x = new Formule();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CalculatorStiintific x = new CalculatorStiintific();
            x.Show();
        }

        private void Meniu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the application?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
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
                    SqlCommand cmd = new SqlCommand(@"update Conturi set TimpTotalStudiu = @timpSt WHERE Conectat = 1", con);

                    DateTime now = DateTime.Now;

                    string timpTrecut = (Autentificare.conectare - now).ToString();

                    string secunde = "";
                    for (int i = 7; i < 12; i++)
                    {
                        secunde += timpTrecut[i];
                    }

                    double timp_total_studiu = double.Parse(secunde) + double.Parse(Autentificare.timp_studiu);

                    cmd.Parameters.AddWithValue("@timpSt", timp_total_studiu / 100);

                    cmd.ExecuteNonQuery();
                }

                Application.ExitThread();
            }
            else
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Date_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Meniu_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

    
      
     

       

        
    }
}
