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
    public partial class AllAdmins : Form
    {
        int ID;
        int IDAdmin;
        Controller Control;
        public AllAdmins()
        {
            Control = new Controller();
            InitializeComponent();
            Message.Visible = false;
            button1.Visible = false;
        }

        private void AllAdmins_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            DataTable Table = Control.GetAllAdmins();
            if (Table != null)
            {
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                
            }
            else
            {
                dataGridView1.Visible = false;
                Message.Visible = true;
            }
        }
        public void TakeParamaters(int rID)
        {
            IDAdmin = rID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow R = this.dataGridView1.Rows[e.RowIndex];
            int ID = Convert.ToInt16(R.Cells[0].Value);
            if(IDAdmin == ID)
            {
                button1.Visible = false;
            }
            else
                button1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = Control.DeleteCustomer(ID);
            if (result > 0)
            {
                this.Close();
            }
        }

        
    }
}
