using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Full_ISL
{
    public partial class crud : Form
    {
        public static string mod_choice_table, mod_check_word, mod_path_word;
        MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
        public crud()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            find_word.Clear();
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT title FROM " + mod_choice_table + ";", con);
                DataTable dt = new DataTable();
                MySqlDataAdapter adpt = new MySqlDataAdapter(cmd);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            mod_choice_table = "india_words_sign";
            MySqlDataAdapter adt = new MySqlDataAdapter("Select title from india_words_sign;", con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mod_choice_table = "international_words_sign";
            MySqlDataAdapter adt = new MySqlDataAdapter("Select title from international_words_sign;", con);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void crud_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mod_choice_table))
            {
                MessageBox.Show("Please press any sign language", "Alert");
            }
            else
            {
                Upload_vid_txt up = new Upload_vid_txt();
                up.Show();
                this.Hide();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login open = new Login();
            open.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login open = new Login();
            open.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mod_choice_table))
            {
                MessageBox.Show("Please press any sign language", "Alert!");
                find_word.Clear();
            }
            else
            {
                MySqlDataAdapter adpt = new MySqlDataAdapter("Select title from " + mod_choice_table + " where title like '" + find_word.Text + "%';", con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Title")
            {
                con.Open();
                try
                {
                    int index = e.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[index];
                    mod_check_word = selectedRow.Cells[1].Value.ToString();

                    MySqlCommand cmd = new MySqlCommand("select words_video from " + mod_choice_table + " where title = '" + mod_check_word + "';", con);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mod_path_word = reader.GetString(0);
                        }
                    }
                    Modify mod = new Modify();
                    mod.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                mod_check_word = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("delete from " + mod_choice_table + " where title = '" + mod_check_word + "';", con);
                        int check_result = cmd.ExecuteNonQuery();
                        if (check_result > 0)
                        {
                            MessageBox.Show("Deleted successful.", "Alert!");
                            RefreshData();
                        }
                        else
                        {
                            MessageBox.Show("There is no records.", "Alert!");
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
            }
        }
    }
}
