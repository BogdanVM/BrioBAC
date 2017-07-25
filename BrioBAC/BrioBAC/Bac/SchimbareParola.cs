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
    public partial class SchimbareParola : Form
    {
        public SchimbareParola()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand(@"select * from conturi where utilizator = @utilizator ", con);

                cmd.Parameters.AddWithValue("@utilizator", textBox1.Text);
                

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cmd.Parameters.Clear();
                    reader.Dispose();
                   cmd.CommandText="update  conturi set Parola=@Parola where Utilizator=@Utilizator";
                   cmd.Parameters.AddWithValue("@Utilizator", textBox1.Text);
                   cmd.Parameters.AddWithValue("@Parola", textBox3.Text);


                   cmd.ExecuteNonQuery();
                   MessageBox.Show("Parola schimbata cu succes");
                   Meniu meniu = new Meniu();
                   meniu.Close();
                   
                  
                   this.Close();
                 
                   Autentificare x = new Autentificare();
                   x.Show();

                }
            
                else
                {

                    MessageBox.Show("Utilizatorul nu exista");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Setari x = new Setari();
            x.Show();
        }

        private void SchimbareParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pictureBox7_Click(this,new EventArgs());
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Down)
            {
                textBox3.Focus();
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this,new EventArgs());
            }
        }

    }
}
