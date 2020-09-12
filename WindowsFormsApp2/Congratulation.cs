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
    public partial class Congratulation : Form
    {
        public Congratulation(int Type,Form1 main)
        {
            InitializeComponent();
            //System.Threading.Thread.Sleep(3000);
            if (Type == 0)
            {
                Form4 F = new Form4();
                F.Show();
                this.Close();
            }
            else
            {
                logincustomer F = new logincustomer();
                F.Show();
                this.Close();
            }
        }

        private void Congratulation_Load(object sender, EventArgs e)
        {

        }
    }
}
