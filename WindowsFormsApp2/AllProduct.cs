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
    public partial class AllProduct : Form
    {
        public static AllProduct AllProductInstance;
        int ID;
        Controller Control;
        public AllProduct()
        {
            Control = new Controller();
            InitializeComponent();
            button2.Visible = false;
            AllProductInstance = this;
        }

        private void AllProduct_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            Num.Visible = false;
            DataTable Table = Control.GetAllCategory();
            if (Table != null)
            {
                Message.Visible = false;
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns[1].Visible = false;
            }
            else
            {
                Message.Visible = true;
                dataGridView1.Visible = false;
                button2.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            label1.Visible = true;
            Num.Visible = true;
            button2.Visible = true;
            DataGridViewRow R = this.dataGridView1.Rows[e.RowIndex];
            ID = Convert.ToInt16(R.Cells[1].Value);
            Num.Text = Control.GetNumOfProduct2(ID).ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Visible = false;
            Num.Visible = false;
            int result = Control.RemoveCategory(ID);
            if (result > 0)
            {
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button2.Visible = false;
            label1.Visible = false;
            Num.Visible = false;
            AddCategory F = new AddCategory();
            F.Show();
        }
    }
}
