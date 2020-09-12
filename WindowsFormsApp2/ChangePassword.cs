using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    
    public partial class ChangePassword : Form
    {
        bool Flag1, Flag2, Flag3;
        
        int ID;
        Controller Control;
        public ChangePassword()
        {
            Flag1 = Flag2 = Flag3 = true;
            Control = new Controller();
            InitializeComponent();
            Message.Visible = false;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
        public void TakaParamaters(int rID)
        {
            ID = rID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            if (textBox2.Text == textBox3.Text && textBox2.TextLength > 3 && textBox1.TextLength < 32)
            {
                result = Control.ChangePasswordCustomer(textBox1.Text, textBox2.Text, ID);
                if (result == 0)
                {
                    Message.Text = "The Old password isn't correct";
                    Message.Visible = true;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (textBox2.Text != textBox3.Text)
                {
                    Message.Text = "The Passwords aren't identical";
                    Message.Visible = true;
                }
                else
                {
                    Message.Text = "The number of characters must be between 8~32";
                    Message.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Flag1)
            {
                textBox1.PasswordChar = '\0';
                button2.Text = "Hide";
                Flag1 = false;
            }
            else
            {
                textBox1.PasswordChar = '*';
                button2.Text = "Show";
                Flag1 = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Flag1)
            {
                textBox2.PasswordChar = '\0';
                button3.Text = "Hide";
                Flag1 = false;
            }
            else
            {
                textBox2.PasswordChar = '*';
                button3.Text = "Show";
                Flag1 = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Flag1)
            {
                textBox3.PasswordChar = '\0';
                button4.Text = "Hide";
                Flag1 = false;
            }
            else
            {
                textBox3.PasswordChar = '*';
                button4.Text = "Show";
                Flag1 = true;
            }
        }
    }
}
