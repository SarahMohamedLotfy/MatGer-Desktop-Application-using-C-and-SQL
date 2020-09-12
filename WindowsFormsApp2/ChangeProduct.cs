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
    public partial class ChangeProduct : Form
    {
        int ID;
        Controller Control;
        public ChangeProduct()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void ChangeProduct_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                numericUpDown1.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                numericUpDown1.Visible = false;
            }
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
               int result =  Control.ChangePrice((int)numericUpDown1.Value , ID);
            }
            if (checkBox2.Checked == true)
            {
                int result = Control.ChangeDescreption(textBox2.Text , ID);              
            }
            this.Close();
        }
    }
}
