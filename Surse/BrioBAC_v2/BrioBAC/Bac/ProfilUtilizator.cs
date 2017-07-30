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
    public partial class ProfilUtilizator : Form
    {
        public ProfilUtilizator()
        {
            InitializeComponent();
        }

        private void ProfilUtilizator_Load(object sender, EventArgs e)
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
               


               SqlCommand cmd = new SqlCommand(@"SELECT * FROM Conturi WHERE Conectat = @Conectat", con);
               cmd.Parameters.AddWithValue("@Conectat", 1);

               SqlDataReader reader = cmd.ExecuteReader();
 

                    if (reader.Read())
                    {
                        string x, c = "";
                        x = reader["DataInregistrarii"].ToString();
                        for (int i = 0; i <= 10; i++)
                        {
                            c += x[i];
                        }

                       

                        label3.Text = reader["TestIQ"].ToString();
                       
                        label6.Text = c.ToString();
                        

                        label9.Text = reader["Timp"].ToString();
                        label14.Text = reader["utilizator"].ToString();
                        label15.Text = reader["Nume"].ToString();
                        label16.Text = reader["Prenume"].ToString();
                        label17.Text = reader["Oras"].ToString();
                        label18.Text = reader["Scoala"].ToString();
                        
                 
                        cmd.Parameters.Clear();
                        reader.Dispose();


                        cmd.CommandText = "update  conturi set TimpTotalStudiu = @timpSt WHERE Conectat = 1";
                        DateTime now = DateTime.Now;

                        string timpTrecut = (Autentificare.conectare - now).ToString();

                        string secunde = "";
                        for (int i = 7; i < 12; i++)
                        {
                            secunde += timpTrecut[i];
                        }

                        double timp_total_studiu = double.Parse(secunde) + double.Parse(Autentificare.timp_studiu);
                       
                        cmd.Parameters.AddWithValue("@timpSt", timp_total_studiu);
                        label4.Text = (timp_total_studiu).ToString();
                        cmd.ExecuteNonQuery();


                       
                      
                    
                        
                    }
                  
                  

               



            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ProfilUtilizator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       
    }
}
