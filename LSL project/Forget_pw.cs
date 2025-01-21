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
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Full_ISL
{
    public partial class Forget_pw : Form
    {
        public static string email_id = "";
        MySqlConnection con = new MySqlConnection("server = /* input in using your MySQL hostname or localhost */; username = /* input it using your  MySQL */; password = /* input it using your MySQL */ ; database = / * input it using your MySQL */ ");
        public Forget_pw()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        static int code;
        private void button5_Click(object sender, EventArgs e)
        {
            // This send generate code, like OTP or verify code, mail.
            if (e_send.ToString().Contains("@gmail.com"))
            {
                MySqlDataAdapter adt = new MySqlDataAdapter("Select * from new_account where email_id = '" + e_send.Text + "';", con);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Your Mail is sended", "Alert!");

                    code = rnd.Next(1000, 9999);

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("(Your email here)"); //Your email on where " From " in mail.
                    msg.To.Add(e_send.Text);
                    msg.Subject = "Forgot password";
                    msg.Body = code + " is your Learn sign language verification code.";

                    /* How to get any app password in your google account. Here's below the link
                     * https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/ */
                    SmtpClient smt = new SmtpClient();
                    smt.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential ntcd = new NetworkCredential();
                    ntcd.UserName = "(Your email here)"; // Check your email match to google
                    ntcd.Password = "(Your app password in google account)";
                    smt.Credentials = ntcd;
                    smt.EnableSsl = true;
                    smt.Port = 587;
                    smt.Send(msg);
                }
                else
                {
                    MessageBox.Show("Invalid email id or create your new account.", "Alert!");
                }
            }
            else
            {
                MessageBox.Show("Invilad email please only @gmail.com or @yahoo.com", "Alert!");
                e_send.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string check_code = c_ver.Text;
            if (!string.IsNullOrEmpty(e_send.Text))
            {
                if (check_code.Length == 4)
                {
                    if (int.Parse(c_ver.Text) == code)
                    {
                        email_id = e_send.Text;
                        e_send.Clear();
                        c_ver.Clear();
                        change_pw change_new_pw = new change_pw();
                        change_new_pw.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("The code is wrong.", "Alert!");
                        c_ver.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Invilad digit please enter only 4 digit.");
                }
            }
            else
            {
                MessageBox.Show("Please enter email ID.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            code = 0;
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            code = 0;
            Login login = new Login();
            login.Show();
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

        private void Forget_pw_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Screen src = System.Windows.Forms.Screen.PrimaryScreen;
            int src_height = src.Bounds.Height;
            int src_width = src.Bounds.Width;

            this.Left = (src_width - this.Width) / 2;
            this.Top = (src_height - this.Height) / 2;
        }
    }
}
