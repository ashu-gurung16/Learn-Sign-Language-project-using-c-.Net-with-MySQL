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
    public partial class save_vid_txt : Form
    {
        public static string ind_path, int_path;
        public save_vid_txt()
        {
            InitializeComponent();
            ind_path = @"(Put your path of india folder on here)";
            int_path = @"(Put your path of international folder on here)";
            Player1.uiMode = "none";
            Player1.Size = new Size(this.ClientSize.Width - 220, this.ClientSize.Height - 230);
        }

        private void save_vid_txt_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            Player1.URL = Upload_vid_txt.up_video_url;
            Player1.Ctlcontrols.play();
            Player1.settings.autoStart = true;
            Player1.settings.setMode("loop", true);
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
            Modify mod = new Modify();
            mod.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.Compare(crud.mod_choice_table, "india_words_sign") == 0)
            {
                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to add this new record?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into " + crud.mod_choice_table + " values ('" + ind_path + Upload_vid_txt.up_video_name + "', '" + textBox1.Text + "');", con);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Added successful.", "Alert!");

                            MySqlCommand cmd1 = new MySqlCommand("select words_video from " + crud.mod_choice_table + " where title = '" + textBox1.Text + "';", con);

                            using (var reader = cmd1.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    crud.mod_path_word = reader.GetString(0);
                                    crud.mod_check_word = textBox1.Text;
                                }
                            }
                            Modify mod = new Modify();
                            mod.Show();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The title already same please another tilte.");
                        }
                        finally
                        { 
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter title here.", "Alert!");
                }
            }
            else if (string.Compare(crud.mod_choice_table, "international_words_sign") == 0)
            {
                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to add this new record?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into " + crud.mod_choice_table + " values ('" + int_path + Upload_vid_txt.up_video_name + "', '" + textBox1.Text + "');", con);
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Added successful.", "Alert!");
                            MySqlCommand cmd1 = new MySqlCommand("select words_video from " + crud.mod_choice_table + " where title = '" + textBox1.Text + "';", con);
                            using (var reader = cmd1.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    crud.mod_path_word = reader.GetString(0);
                                    crud.mod_check_word = textBox1.Text;
                                }
                            }
                            Modify mod = new Modify();
                            mod.Show();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The title already same please another tilte.");
                        }
                        finally
                        { 
                            con.Close() ;
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Please enter title here.", "Alert!");
                }
            }
        }
    }
}
