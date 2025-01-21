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
    public partial class int_video_sign : Form
    {
        public int_video_sign()
        {
            InitializeComponent();
            player2.uiMode = "none";
            player2.Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 210);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            User_choice user = new User_choice();
            user.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            User_choice user = new User_choice();
            user.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player2.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                player2.Ctlcontrols.play();
            }
            else if (player2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player2.Ctlcontrols.pause();
            }
        }

        private void int_video_sign_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            label1.Text = Internation.int_choice_words;
            player2.URL = Internation.int_choice_path;
            player2.Ctlcontrols.play();
            player2.settings.autoStart = true;
            player2.settings.setMode("loop", true);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Internation op = new Internation();
            op.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Internation op = new Internation();
            op.Show();
            this.Hide();
        }
    }
}
