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
    public partial class SettingSeller : Form
    {
        int ID;
        Controller Control;
        public SettingSeller()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void SettingSeller_Load(object sender, EventArgs e)
        {

        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePasswordSeller F = new ChangePasswordSeller();
            F.TakaParamaters(ID);
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeUserNameSeller F = new ChangeUserNameSeller();
            F.TakeParamaters(ID);
            F.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = Control.DeleteSeller(ID);
            Form4.Seller.Close();
            this.Close();
        }
    }
}
