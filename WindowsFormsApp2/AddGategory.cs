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
    public partial class AddCategory : Form
    {
        Controller Control;
        public AddCategory()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int result = Control.AddCategory(textBox1.Text);
            if (result > 0)
                this.Close();
            AllProduct.AllProductInstance.Close();
            AllProduct F = new AllProduct();
            F.Show();
        }

        private void AddGategory_Load(object sender, EventArgs e)
        {

        }
    }
}
