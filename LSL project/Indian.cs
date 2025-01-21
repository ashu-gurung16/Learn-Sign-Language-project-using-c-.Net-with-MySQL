using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_ISL
{
    public partial class Indian : Form
    {
        MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
        MySqlCommand cmd;
        MySqlDataReader dr;

        public static string choice_words, choice_path;

        public Indian()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            DataTable dt = datatable_manage();
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.ForeColor = System.Drawing.SystemColors.Highlight;
                btn.Name = "button" + row["title"].ToString();
                btn.Size = new System.Drawing.Size(140, 140);
                btn.TabIndex = 28;
                btn.Text = row["title"].ToString();
                btn.UseVisualStyleBackColor = true;
                btn.Click += new EventHandler(this.btn_click);
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select title, words_video from india_words_sign where title like '" + btn.Text + "%' order by title;", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    choice_words = dr.GetString("title");
                    choice_path = dr.GetString("words_video");
                    Ind_video_sign vs = new Ind_video_sign();
                    vs.Show();
                    this.Hide();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                con.Close(); 
            }
        }

        private DataTable datatable_manage()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("Select title, words_video from india_words_sign;", con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        private void search(string search_word = "")
        {
            DataTable dt = new DataTable();
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select title, words_video from india_words_sign where title like '" + search_word + "%' order by title;", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    Button btn = new Button();
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.ForeColor = System.Drawing.SystemColors.Highlight;
                    btn.Name = "button" + row["title"].ToString();
                    btn.Size = new System.Drawing.Size(140, 140);
                    btn.TabIndex = 28;
                    btn.Text = row["title"].ToString();
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += new EventHandler(this.btn_click);

                    choice_words = row["title"].ToString();
                    choice_path = row["words_video"].ToString();

                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void find_word_TextChanged(object sender, EventArgs e)
        {
            search(find_word.Text);
        }

        private void Indian_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2; 
            GetData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User_choice uc = new User_choice();
            uc.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            User_choice uc = new User_choice();
            uc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
