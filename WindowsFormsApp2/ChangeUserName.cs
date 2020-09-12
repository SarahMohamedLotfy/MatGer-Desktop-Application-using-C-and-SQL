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
    public partial class ChangeUserName : Form
    {
        bool Flag1;
        int ID;
        Controller Control;
        public ChangeUserName()
        {
            Flag1 = true;
            Control = new Controller();
            InitializeComponent();
            Message.Visible = false;
        }

        private void ChangeUserName_Load(object sender, EventArgs e)
        {

        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            if (textBox2.TextLength > 3 && textBox2.TextLength < 32)
            {
                if (Control.CheckNameCustomer(textBox2.Text) == null && Control.CheckNameSeller(textBox2.Text) == null)
                {
                    result = Control.ChangeUserNameCustomer(textBox1.Text, textBox2.Text, ID);
                    if (result == 0)
                    {
                        Message.Text = "This password is not correct :) ";
                        Message.Visible = true;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    Message.Text = "This name is already taken:) ";
                    Message.Visible = true;
                }
                
            }
            else
            {
                Message.Text = "The number of the characters must be between 8 ~ 32";
                Message.Visible = true;
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
    }
}
