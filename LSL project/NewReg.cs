using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_ISL
{
    public partial class NewReg : Form
    {
        public static string f_name,m_name,l_name,phone,gender,dob,r_state,r_country;
        public static int check_count = 0;
        public NewReg()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login op = new Login();
            op.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    f_name = textBox1.Text;
                    m_name = textBox2.Text;
                    if (f_name.All(Char.IsLetter) == true && m_name.All(Char.IsLetter))
                    {
                        if (!string.IsNullOrEmpty(textBox3.Text))
                        {
                            l_name = textBox3.Text;
                            if (l_name.All(Char.IsLetter) == true)
                            {
                                if (!string.IsNullOrEmpty(textBox4.Text))
                                {
                                    phone = textBox4.Text;
                                    var check_phone = int.TryParse(phone, out int n);
                                    if (check_phone == true)
                                    {
                                        if (phone.Length == 10)
                                        {
                                            if (!string.IsNullOrEmpty(gender))
                                            {
                                                check_count++;
                                                if (!string.IsNullOrEmpty(dateTimePicker1.Text))
                                                {
                                                    dob = dateTimePicker1.Text;
                                                    if (!string.IsNullOrEmpty(Country.Text))
                                                    {
                                                        r_country = Country.Text;
                                                        if (!string.IsNullOrEmpty(State.Text))
                                                        {
                                                            r_state = State.Text;
                                                            new_email new_mail = new new_email();
                                                            new_mail.Show();
                                                            this.Hide();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Please choice state.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Please choice country.");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Please choice date.");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please choice gender.");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid phone please enter only 10 digit in phone no.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invilid phone please only number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter phone no.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invilad last name please only letter.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter last name.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invilad first or middle name please only letter.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter first name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewReg_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Country.Text == "India")
            {
                State.Items.Clear();
                State.Items.AddRange(new[] { "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka", "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Telangana", "Tripura", "Uttar Pradesh" });
            }
            else if (Country.Text == "USA")
            {
                State.Items.Clear();
                State.Items.AddRange(new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", " Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "entucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" });
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "M";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "F";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
