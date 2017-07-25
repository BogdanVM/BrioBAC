using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace Bac
{
    public partial class Setari : Form
    {
        private SoundPlayer soundplayer;
        public Setari()
        {
            InitializeComponent();
            soundplayer = new SoundPlayer("Study Music.wav");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StergeCont x = new StergeCont();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SchimbareParola x = new SchimbareParola();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            soundplayer.Stop();
            button4.Visible = false;
            button3.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            soundplayer.Play();
            button3.Visible = false;
            button4.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
            Meniu x = new Meniu();
            x.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Setari_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                pictureBox7_Click(this,new EventArgs());

            }
        }
    }
}
