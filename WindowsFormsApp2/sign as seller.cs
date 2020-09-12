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
    public partial class Form3 : Form
    {
        bool Logged_in;
        Controller Control;
        bool Flag1;
        
        bool Flag2;
        public Form3()
        {
            Control =new Controller();
            
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Logged_in = false;
            Type.Items.Add("Seller");
            Type.Items.Add("Customer");
            Phone.Visible = false;
            label6.Visible = false;
            Message.Visible = false;
            Password.PasswordChar = '*';
            Password_2.PasswordChar = '*';
            Flag1 = true;
            Flag2 = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                        if (Type.Text == "Seller" || Type.Text == "Customer" )
                        {
            
                            if (Control.CheckNameCustomer(UserName.Text) == null && Control.CheckNameSeller(UserName.Text) == null)
                            {

                                if (Type.Text == "Customer")
                                {
                                    result = Control.InsertCustomer(UserName.Text, FirstName.Text, LastName.Text, Password.Text);

                                    Logged_in = true;
                                    
                                    int ID = (int)Control.GetIDCustomer();
                                    logincustomer F = new logincustomer();
                                    F.TakeParamaters(ID);
                                    F.GetName(FirstName.Text, LastName.Text);

                                    Password.Text = "";
                                    Password_2.Text = "";
                                    FirstName.Text = "";
                                    LastName.Text = "";
                                    Type.Text = "";
                                    Phone.Text = "";
                                    UserName.Text = "";

                                    Message.Visible = false;
                                    Message.Text = "";

                                    F.Show();
                                    this.Close();
                                }
                                else if (Type.Text == "Seller")
                                {
                                    result = Control.InsertSeller(UserName.Text, FirstName.Text, LastName.Text, Password.Text, Phone.Text);

                                    Logged_in = true;
                                    
                                    //f.Show();
                                   
                                    int ID = (int)Control.GetID();
                                    Form4 F = new Form4();
                                    F.GetName(FirstName.Text, LastName.Text);
                                    F.TakeParamaters(ID);

                                    Password.Text = "";
                                    Password_2.Text = "";
                                    FirstName.Text = "";
                                    LastName.Text = "";
                                    Type.Text = "";
                                    Phone.Text = "";
                                    UserName.Text = "";

                                    Message.Visible = false;
                                    Message.Text = "";

                                    F.Show();
                                    this.Close();
                                }
                            }
                            else
                            {
                                Message.Visible = true;
                                Message.Text = "This username is alredy taken";
                            }
                        }
                        else
                        {
                            Message.Visible = true;
                            Message.Text = "Select your type";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Type.Text == "Seller")
            {
                Phone.Visible = true;
                label6.Visible = true;
            }
            else if (Type.Text == "Customer")
            {
                Phone.Visible = false;
                label6.Visible = false;
            }
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
                button3.Text = "Hide";
                Flag2 = false;
            }
            else
            {
                Password_2.PasswordChar = '*';
                button3.Text = "Show";
                Flag2 = true;
            }
        }
    }
}
