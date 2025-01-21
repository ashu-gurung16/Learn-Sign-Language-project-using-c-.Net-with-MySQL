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
    public partial class choice_vid_text : Form
    {
        public choice_vid_text()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modify.cancel_button = "false";
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            upload_vid uvd = new upload_vid();
            uvd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rename_txt retext = new rename_txt();
            retext.Show();
            this.Hide();
        }
    }
}
