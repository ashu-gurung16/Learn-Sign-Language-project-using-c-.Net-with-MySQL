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
    public partial class change_pw : Form
    {
        public change_pw()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pw.Text))
            {
                MessageBox.Show("Please enter new password.");
            }
            else
            {
                if (String.IsNullOrEmpty(cf_pw.Text))
                {
                    MessageBox.Show("Please enter new confirm password.");
                }
                else
                {
                    string check_email = Forget_pw.email_id;
                    MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
                    if (String.Compare(pw.Text, cf_pw.Text) == 0)
                    {
                        MySqlCommand cmd = new MySqlCommand("Update new_account set pw = '" + pw.Text + "' where email_id = '" + check_email + "' ;", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Your password is successful.");
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("They not match.");
                    }
                }
            }
        }

        private void change_pw_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }
    }
}
