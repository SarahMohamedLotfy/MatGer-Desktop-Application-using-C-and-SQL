using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static Form1 Form1Instance;
        private bool Flag;
        bool Logged_in;
        private Controller Control;
        public Form1()
        {
            Form1Instance = this;
            Control = new Controller();
            InitializeComponent();
            Message.Visible = false;
            Logged_in = false;
            Flag = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            result = (int)Control.GetCustomer(textBox1.Text, textBox2.Text);
            if (result > 0)
            {
                if ((int)Control.CheckAdmin(result) > 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Logged_in = true;
                    AdminProfile F = new AdminProfile();
                    F.TakeParamaters(result);

                    F.Show();
                    Message.Visible = false;
                    Message.Text = "";
                    //this.Hide();
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Logged_in = true;
                    logincustomer F = new logincustomer();

                    F.TakeParamaters(result);
                    F.GetNameSecond();
                    F.Show();
                    Message.Visible = false;
                    Message.Text = "";
                    this.Hide();
                }

            }
            else
            {
                result = (int)Control.GetSeller(textBox1.Text, textBox2.Text);
                if (result > 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Logged_in = true;
                    Form4 F = new Form4();
                    F.TakeParamaters(result);
                    F.GetNameSecond();
                    F.Show();
                    Message.Visible = false;
                    Message.Text = "";
                    this.Hide();
                }
                else
                {
                    Message.Text = "The username or password are wrong";
                    Message.Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 F = new Form3();
            F.Show();
            //this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Flag)
            {
                textBox2.PasswordChar = '\0';
                button3.Text = "Hide";
                Flag = false;
            }
            else
            {
                textBox2.PasswordChar = '*';
                button3.Text = "Show";
                Flag = true;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}