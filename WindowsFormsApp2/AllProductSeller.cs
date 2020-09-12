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
    public partial class AllProductSeller : Form
    {
        int ID;
        Controller Control;
        public AllProductSeller()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void AllProductSeller_Load(object sender, EventArgs e)
        {
            //DataGridViewImageColumn Columns = new DataGridViewImageColumn();
            //Columns.HeaderText = "Image";
            //Columns.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //dataGridView1.Columns.Add(Columns);



            Control.GetMyProducts(ID);
            DataTable Table = Control.GetMyProducts(ID);
            DataColumn Image = Table.Columns[4];
            dataGridView1.DataSource =Table;
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Refresh();
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }
    }
}
