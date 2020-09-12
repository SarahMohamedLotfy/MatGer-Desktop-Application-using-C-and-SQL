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
    public partial class AdminProfile : Form
    {
        int ID;
        Controller Control;
        public AdminProfile()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {

        }

        public void TakeParamaters(int rID)
        {
            ID = rID;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AllGategory F = new AllGategory();
            F.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllSeller F = new AllSeller();
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllCustomers F = new AllCustomers();
            F.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllProduct F = new AllProduct();
            F.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            

            ChangeUserName F = new ChangeUserName();
            F.TakeParamaters(ID);
            F.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangePassword F = new ChangePassword();
            F.TakaParamaters(ID);
            F.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.Form1Instance.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            AddAdmin F = new AddAdmin();
            F.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AllAdmins F = new AllAdmins();
            F.TakeParamaters(ID);
            F.Show();
        }
    }
}
