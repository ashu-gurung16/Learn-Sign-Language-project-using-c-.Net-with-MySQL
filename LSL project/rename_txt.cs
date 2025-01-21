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
    public partial class rename_txt : Form
    {
        public rename_txt()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to change this record?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("update " + crud.mod_choice_table + " set title ='" + textBox1.Text + "' where title = '" + crud.mod_check_word + "';", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Changed successful.", "Alert!");
                        crud.mod_check_word = textBox1.Text;
                        con.Close();
                        Modify mod = new Modify();
                        mod.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter title here.", "Alert!");
                }
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
        private void rename_txt_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;

            textBox1.Text = crud.mod_check_word;
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
    }
}
