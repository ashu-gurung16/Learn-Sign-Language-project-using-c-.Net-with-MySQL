using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Full_ISL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(e_id.Text) && !string.IsNullOrEmpty(pw.Text))
            {
                MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
                if (e_id.ToString().Contains("@gmail.com") || e_id.ToString().Contains("@nish.ac.in"))
                {
                    MySqlDataAdapter adt = new MySqlDataAdapter("Select * from new_account where email_id = '" + e_id.Text + "' and pw = '" + pw.Text + "';", con);
                    DataTable dt = new DataTable();
                    adt.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        e_id.Clear();
                        pw.Clear();
                        User_choice user_Choice = new User_choice();
                        user_Choice.Show();
                        this.Hide();
                    }
                    else
                    {
                        pw.Clear();
                        MessageBox.Show("Invalid email id or password / You may not register.", "Alert!");
                    }
                }
                else 
                {
                    MessageBox.Show("Invilad email please only @gmail.com or @nish.ac.in", "Alert!");
                }
            }
            else
            {
                pw.Clear();
                MessageBox.Show("Please enter mail ID or password.", "Alert!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Forget_pw fpw = new Forget_pw();
            fpw.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            NewReg reg = new NewReg();
            reg.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin login_admin = new Admin();
            login_admin.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }
    }
}
