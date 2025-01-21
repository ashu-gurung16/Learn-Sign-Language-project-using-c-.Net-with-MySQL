using MySql.Data.MySqlClient;
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
    public partial class Save_vid : Form
    {
        public static string ind_path, int_path;
        public Save_vid()
        {
            InitializeComponent();
            ind_path = @"(Put your path of india folder on here)";
            int_path = @"(Put your path of international folder on here)";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 210);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            axWindowsMediaPlayer1.URL = upload_vid.video_url;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Modify mod = new Modify();
            mod.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (string.Compare(crud.mod_choice_table, "india_words_sign") == 0)
            {

                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");

                DialogResult result = MessageBox.Show("Are you sure you want to change this video?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand("update " + crud.mod_choice_table + " set words_video = '" + ind_path + upload_vid.video_name + "' where title = '" + crud.mod_check_word + "';", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Changed successful.", "Alert!");
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand("select words_video from " + crud.mod_choice_table + " where title = '" + crud.mod_check_word + "';", con);

                        using (var reader = cmd1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                crud.mod_path_word = reader.GetString(0);
                            }
                        }
                        con.Close();
                        Modify mod = new Modify();
                        mod.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (string.Compare(crud.mod_choice_table, "international_words_sign") == 0)
            {
                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");

                DialogResult result = MessageBox.Show("Are you sure you want to change this video?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand cmd = new MySqlCommand("update " + crud.mod_choice_table + " set words_video = '" + int_path + upload_vid.video_name + "' where title = '" + crud.mod_check_word + "';", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Changed successful.", "Alert!");
                    try
                    {
                        MySqlCommand cmd1 = new MySqlCommand("select words_video from " + crud.mod_choice_table + " where title = '" + crud.mod_check_word + "';", con);

                        using (var reader = cmd1.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                crud.mod_path_word = reader.GetString(0);
                            }
                        }
                        con.Close();
                        Modify mod = new Modify();
                        mod.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
