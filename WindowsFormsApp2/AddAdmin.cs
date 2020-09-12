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
    public partial class AddAdmin : Form
    {
        bool Flag1;
        bool Flag2;
        public Controller Control;
        public AddAdmin()
        {
            Control = new Controller();
            InitializeComponent();
            Flag1 = true;
            Flag2 = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            if (UserName.TextLength > 3 && UserName.TextLength < 32)
            {
                 if (FirstName.TextLength > 3 && FirstName.TextLength < 32 && LastName.TextLength > 3 && LastName.TextLength < 32)
                {
                    if (Password.Text == Password_2.Text && Password.TextLength > 3 && Password.TextLength < 32)
                    {                     
                            if (Control.CheckNameCustomer(UserName.Text) == null && Control.CheckNameSeller(UserName.Text) == null)
                            {

                                result = Control.InsertAdmin(UserName.Text, Password.Text, FirstName.Text, LastName.Text);                                                                                                                                                                          
                                    Password.Text = "";
                                    Password_2.Text = "";                                  
                                    UserName.Text = "";

                                    Message.Visible = false;
                                    Message.Text = "";                                  
                                    this.Close();                                                            
                            }
                            else
                            {
                                Message.Visible = true;
                                Message.Text = "This username is alredy taken";
                            }                       
                    }
                    else
                    {
                        if (Password.Text == Password_2.Text)
                        {
                            Message.Visible = true;
                            Message.Text = "The password must be between 5~32 characters";
                        }
                        else
                        {
                            Message.Visible = true;
                            Message.Text = "The passwords aren't identical";
                        }
                    }
                }
                 else
                 {
                     Message.Visible = true;
                     Message.Text = "The FirstName and LastName must be between 4~32 characters";
                 }
            }
            else
            {
                Message.Visible = true;
                Message.Text = "The user name must be between 4~32 characters";
            }
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Flag1)
            {
                Password.PasswordChar = '\0';
                button2.Text = "Hide";
                Flag1 = false;
            }
            else
            {
                Password.PasswordChar = '*';
                button2.Text = "Show";
                Flag1 = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Flag2)
            {
                
                Password_2.PasswordChar = '\0';
                button2.Text = "Hide";
                Flag2 = false;
            }
            else
            {
                Password_2.PasswordChar = '*';
                button2.Text = "Show";
                Flag2 = true;
            }
        }
    }
}
