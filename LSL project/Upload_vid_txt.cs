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
    public partial class Upload_vid_txt : Form
    {
        public static string up_video_name, up_video_url;
        public Upload_vid_txt()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            crud.mod_choice_table = "";
            crud c = new crud();
            c.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            crud.mod_choice_table = "";
            crud c = new crud();
            c.Show();
            this.Hide();
        }

        private void Upload_vid_txt_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                up_video_name = Path.GetFileName(openFileDialog1.FileName);
                up_video_url = Path.GetFullPath(openFileDialog1.FileName);
                save_vid_txt save = new save_vid_txt();
                save.Show();
                this.Hide();
            }
        }
    }
}
