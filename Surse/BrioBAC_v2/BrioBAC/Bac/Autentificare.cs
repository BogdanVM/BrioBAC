using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
namespace Bac
{
    public partial class Autentificare : Form
    {
        private SoundPlayer soundplayer;

        public static int iq;
        public static int score = 0;
        public static string timp, timp_studiu;
        public static DateTime conectare;

        public Autentificare()
        {
            

            InitializeComponent();

            soundplayer = new SoundPlayer("Study Music.wav");
            
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand(@"select * from conturi where utilizator = @utilizator and parola=@parola", con);
             
                cmd.Parameters.AddWithValue("@utilizator", textBoxUtilizator.Text);
                cmd.Parameters.AddWithValue("@parola", textBoxParola.Text);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    iq = int.Parse(reader["TestIQ"].ToString());
                    timp = reader["Timp"].ToString();
                    timp_studiu = reader["TimpTotalStudiu"].ToString();

                    cmd.Parameters.Clear();
                    reader.Dispose();

                    cmd.CommandText = "update  conturi set Conectat=@Conectat where Utilizator=@utilizator";

                    cmd.Parameters.AddWithValue("@Conectat", 1);
                    cmd.Parameters.AddWithValue("@utilizator", textBoxUtilizator.Text);

                    cmd.ExecuteNonQuery();

                    conectare = DateTime.Now;

                    this.Hide();
                    Meniu f = new Meniu();
                    f.Show();
                    soundplayer.Play();
                    
                }
                else
                {

                    MessageBox.Show("Utilizatorul nu exista");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inregistrare f = new Inregistrare();
            f.Show();

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inregistrare f = new Inregistrare();
           
            f.Show();
        }

        private void Autentificare_Shown(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand(@"select * from conturi where Conectat = 1", con);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    iq = int.Parse(reader["TestIQ"].ToString());
                    timp = reader["Timp"].ToString();
                    timp_studiu = reader["TimpTotalStudiu"].ToString();

                    conectare = DateTime.Now;

                    this.Hide();
                    Meniu f = new Meniu();
                    f.Show();
                    soundplayer.Play();
                }
            }
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
           
        }

        private void textBoxUtilizator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Down)
            {

                textBoxParola.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(this, new EventArgs());
            }
        }

        private void textBoxParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBoxUtilizator.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this,new EventArgs());
            }
            if (e.KeyCode == Keys.Escape)
            {
                button2_Click(this, new EventArgs());
            }

        }

       

      

     

    


       
    }
}
