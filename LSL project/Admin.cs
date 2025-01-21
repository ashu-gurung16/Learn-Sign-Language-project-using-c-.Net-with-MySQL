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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
            if (!string.IsNullOrEmpty(e_id.Text) && !string.IsNullOrEmpty(pw.Text))
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("Select * from admin where id = '" + e_id.Text + "' and pw = '" + pw.Text + "';", con);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    e_id.Clear();
                    pw.Clear();
                    crud modify = new crud();
                    modify.Show();
                    this.Hide();
                }
                else
                {
                    pw.Clear();
                    MessageBox.Show("Invalid email id or password.");
                }
            }
            else
            {
                pw.Clear();
                MessageBox.Show("Please enter mail ID or password.", "Alert!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            this.Hide();
        }
    }
}
