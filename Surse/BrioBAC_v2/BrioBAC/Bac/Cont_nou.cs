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
    public partial class Inregistrare : Form
    {
        public Inregistrare()
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


                SqlCommand cmd1 = new SqlCommand(@"SELECT * from Conturi where Utilizator=@Utilizator", con);
                cmd1.Parameters.AddWithValue("@Utilizator",textBox5.Text);
                SqlDataReader reader = cmd1.ExecuteReader();
                if (!reader.Read())
                {
                    cmd1.Parameters.Clear();
                    reader.Dispose();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Conturi VALUES(@Utilizator, @Parola,@TestIQ,@Timp,@TimpTotalStudiu,@DataInregistrarii,@Nume,@Prenume,@Oras,@Scoala,@Conectat)", con);
                    var myDateTime = DateTime.Now;


                    if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBoxParola.Text))
                    {

                        cmd.Parameters.AddWithValue("@Utilizator", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Parola", textBoxParola.Text);
                        cmd.Parameters.AddWithValue("@Nume", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Prenume", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Oras", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Scoala", textBox4.Text);

                        cmd.Parameters.AddWithValue("@TestIQ", 0);
                        cmd.Parameters.AddWithValue("@Timp", 0);
                        cmd.Parameters.AddWithValue("@TimpTotalStudiu", 0);
                        cmd.Parameters.AddWithValue("@DataInregistrarii", myDateTime);
                        cmd.Parameters.AddWithValue("@Conectat", 0);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cont creat cu succes!");

                        button3.Visible = false;
                        button1.Visible = true;
                        button2.Visible = false;


                    }
                    else
                    {
                        MessageBox.Show("Inserati date in toate campurile.");
                    }
                }
                else
                {
                    MessageBox.Show("Exista deja acest utilizator!");
                }
               

            
      

               

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Autentificare f = new Autentificare();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Autentificare f = new Autentificare();
            f.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox3.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox4.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox5.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBoxParola.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox4.Focus();
            }
        }

        private void textBoxParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              button2_Click(this, new EventArgs());
            }
          
            if (e.KeyCode == Keys.Escape)
            {
                button3_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                textBox5.Focus();
            }
        
        }
    }
}
