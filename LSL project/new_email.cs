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
    public partial class new_email : Form
    {
        int check_email_count = 0;
        public new_email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
            con.Open();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                check_email_count++;
            }
            else
            {
                MessageBox.Show("Please enter password.");
            }

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                check_email_count++;
            }
            else
            {
                MessageBox.Show("Please enter confirm password.");
            }

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                check_email_count++;
                if (string.Compare(textBox2.Text, textBox3.Text) == 0)
                {
                    check_email_count++;
                }
                else
                {
                    MessageBox.Show("They're not match.");
                }
            }
            else
            {
                MessageBox.Show("Please enter email ID.");
            }

            if (check_email_count == 4)
            {
                if (textBox1.Text.Contains("@gmail.com") || textBox1.Text.Contains("@nish.ac.in"))
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into register values('" + NewReg.f_name + "', '" + NewReg.m_name + "', '" + NewReg.l_name + "', '" + NewReg.phone + "', '" + NewReg.gender + "', '" + NewReg.dob + "', '" + NewReg.r_state + "', '" + NewReg.r_country + "'); insert into new_account values('" + NewReg.phone + "', '" + textBox1.Text + "', '" + textBox2.Text + "');", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registered successful.");
                        con.Close();
                        check_email_count = 0;
                        Login op = new Login();
                        op.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        check_email_count = 0;
                        MessageBox.Show("Who has already registered.", "Alert!");
                        Login op = new Login();
                        op.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invilad email please only @gmail.com or @nish.ac.in", "Alert!");
                    check_email_count = 0;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NewReg nr = new NewReg();
            nr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            NewReg nr = new NewReg();
            nr.Show();
            this.Hide();
        }

        private void new_email_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }
    }
}
