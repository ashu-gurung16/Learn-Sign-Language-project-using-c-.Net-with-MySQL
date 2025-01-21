using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_ISL
{
    public partial class Ind_video_sign : Form
    {
        public Ind_video_sign()
        {
            InitializeComponent();
            player.uiMode = "none";
            player.Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 210);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Indian ind = new Indian();
            ind.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Indian ind = new Indian();
            ind.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            User_choice user_Choice = new User_choice();
            user_Choice.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            User_choice user_Choice = new User_choice();
            user_Choice.Show();
            this.Hide();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void video_sign_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            label1.Text = Indian.choice_words;
            player.URL = Indian.choice_path;
            player.Ctlcontrols.play();
            player.settings.autoStart = true;
            player.settings.setMode("loop", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                player.Ctlcontrols.play();
            }
            else if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.Ctlcontrols.pause();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            User_choice user = new User_choice();
            user.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            User_choice user = new User_choice();
            user.Show();
            this.Hide();
        }
    }
}
