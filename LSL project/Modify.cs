using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_ISL
{
    public partial class Modify : Form
    {
        public static string cancel_button = "true";
        public Modify()
        {
            InitializeComponent();
            player.uiMode = "none";
            player.Size = new Size(this.ClientSize.Width - 250, this.ClientSize.Height - 210);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
                MySqlCommand cmd = new MySqlCommand("delete from " + crud.mod_choice_table + " where title = '" + crud.mod_check_word + "';", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successful.", "Alert!");
                con.Close();
                crud cd = new crud();
                cd.Show();
                this.Hide();
            }
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            label1.Text = crud.mod_check_word;
            player.URL = crud.mod_path_word;
            player.Ctlcontrols.play();
            player.settings.autoStart = true;
            player.settings.setMode("loop", true);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            choice_vid_text vid_or_txt = new choice_vid_text();
            vid_or_txt.ShowDialog();
            if (string.Compare(cancel_button, "true") == 0)
            {
                this.Hide();
            }
            else
            {
                cancel_button = "true";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            crud.mod_choice_table = "";
            crud back = new crud();
            back.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            crud.mod_choice_table = "";
            crud back = new crud();
            back.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
