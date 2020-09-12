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
    public partial class AllSeller : Form
    {
        int ID;
        Controller Control;
        public AllSeller()
        {
            Control = new Controller();
            InitializeComponent();
            Message.Visible = false;
            button1.Visible = false;
        }

        private void AllSeller_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            DataTable Table = Control.GetAllSeller();
            if (Table != null)
            {
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;               
            }
            else
            {
                dataGridView1.Visible = false;
                Message.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button1.Visible = true;
            DataGridViewRow R = this.dataGridView1.Rows[e.RowIndex];
            ID = Convert.ToInt16(R.Cells[0].Value);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int result = Control.DeleteSeller(ID);
            if (result > 0)
            {
                this.Close();
            }
        }        
    }
}
