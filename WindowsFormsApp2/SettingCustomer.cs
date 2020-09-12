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
    public partial class SettingCustomer : Form
    {
        Controller Control;
        int ID;
        public SettingCustomer()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void SettingCustomer_Load(object sender, EventArgs e)
        {

        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = Control.DeleteCustomer(ID);
            logincustomer.Customer.Close();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword F = new ChangePassword();
            F.TakaParamaters(ID);
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeUserName F = new ChangeUserName();
            F.TakeParamaters(ID);
            F.Show();
        }
    }
}
