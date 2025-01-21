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
    public partial class Internation : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public static string int_choice_words, int_choice_path;

        private Button btn1;
        public Internation()
        {
            InitializeComponent();
            con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
        }

        private void IntGetData()
        {
            con.Open();
            cmd = new MySqlCommand("Select title,words_video from international_words_sign;", con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    btn1 = new Button();
                    btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn1.ForeColor = System.Drawing.SystemColors.Highlight;
                    btn1.Location = new System.Drawing.Point(96, 233);
                    btn1.Name = "button1";
                    btn1.Size = new System.Drawing.Size(155, 151);
                    btn1.TabIndex = 28;
                    btn1.Text = dr["title"].ToString();
                    btn1.UseVisualStyleBackColor = true;
                    btn1.Click += new EventHandler(this.int_btn_click);
                    flowLayoutPanel1.Controls.Add(btn1);
                }
                dr.Close();
                con.Close();
            }
        }

        void int_btn_click(object sender, EventArgs e)
        {
            Button btn1 = sender as Button;
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select title, words_video from international_words_sign where title like '" + btn1.Text + "%' order by title;", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int_choice_words = dr.GetString("title");
                    int_choice_path = dr.GetString("words_video");
                    int_video_sign vs = new int_video_sign();
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

        private void find_word_TextChanged(object sender, EventArgs e)
        {
            Intsearch();
        }

        private void Internation_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            IntGetData();
        }

        private void Intsearch()
        {
            flowLayoutPanel1.Controls.Clear();
            con.Open();
            cmd = new MySqlCommand("Select title,words_video from international_words_sign where title like '" + find_word.Text + "%' order by title;", con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                btn1 = new Button();
                btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn1.ForeColor = System.Drawing.SystemColors.Highlight;
                btn1.Location = new System.Drawing.Point(96, 233);
                btn1.Name = "button1";
                btn1.Size = new System.Drawing.Size(140, 140);
                btn1.TabIndex = 28;
                btn1.Text = dr["title"].ToString();
                int_choice_words = dr["title"].ToString();
                int_choice_path = dr["words_video"].ToString();
                btn1.UseVisualStyleBackColor = true;
                btn1.Click += new EventHandler(this.int_btn_click);
                flowLayoutPanel1.Controls.Add(btn1);
            }
            dr.Close();
            con.Close();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            User_choice uc = new User_choice();
            uc.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            User_choice uc = new User_choice();
            uc.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
