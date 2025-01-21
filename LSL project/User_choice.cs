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
    public partial class User_choice : Form
    {
        public User_choice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Indian ind = new Indian();
            ind.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Internation inter = new Internation();
            inter.Show();
            this.Hide();
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

        private void User_choice_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }
    }
}
