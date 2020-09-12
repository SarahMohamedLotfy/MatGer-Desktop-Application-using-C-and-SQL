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
    public partial class MyProducts : Form
    {
        int ID;
        int IDProduct;
        Controller Control = new Controller();
        public MyProducts()
        {
            Control = new Controller();
            InitializeComponent();
            textBox2.ReadOnly = true;

            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label8.Visible = false;
            label9.Visible = false;          
            label2.Visible = false;          
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            label6.Visible = false;
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void MyProducts_Load(object sender, EventArgs e)
        {
            DataTable Table = Control.GetMyProducts(ID);
            textBox1.ReadOnly = true;

            DataTable Table_2 = Control.GetAllCategory();
            Type.DataSource = Control.GetAllCategory();
            Type.DisplayMember = "Name";
            Type.ValueMember = "IDCategory";

            if (Table != null)
            {
                label4.Visible = false;
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Refresh();
            }
            else
            {
                label4.Visible = true;

                dataGridView1.Visible = false;
                Message.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = Control.DeleteProduct(IDProduct);
            if (result > 0)
            {
                int result_2 = Control.decreaseNumOfProduct((int)Type.SelectedValue);
                result_2++;
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                label1.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label2.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                pictureBox1.Visible = true;
                Message.Visible = false;
                textBox1.Visible = true;
                label6.Visible = true;


                DataGridViewRow R = this.dataGridView1.Rows[e.RowIndex];
                pictureBox1.Image = Image.FromFile((string)R.Cells[7].Value);
                label1.Text = (string)R.Cells[2].Value;
                label8.Text = R.Cells[1].Value.ToString();
                label9.Text = (string)R.Cells[4].Value.ToString();
                textBox2.Text = (string)R.Cells[3].Value;
                IDProduct = Convert.ToInt16(R.Cells[0].Value);


                DataTable Comments = Control.GetCommentsForProduct(IDProduct);
                if (Comments != null)
                {
                    foreach (DataRow i in Comments.Rows)
                    {

                        textBox1.AppendText(i[1].ToString());
                        textBox1.AppendText(Environment.NewLine);
                        textBox1.AppendText("   ");
                        textBox1.AppendText(i[0].ToString());
                        textBox1.AppendText(Environment.NewLine);
                        textBox1.AppendText(i[2].ToString());
                        textBox1.AppendText(Environment.NewLine);
                        textBox1.AppendText(Environment.NewLine);
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeProduct F = new ChangeProduct();
            F.TakeParamaters(IDProduct);
            F.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Table = Control.GetProductByName((int)Type.SelectedValue);
            textBox1.ReadOnly = true;

           
            if (Table != null)
            {
                label4.Visible = false;
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Refresh();
            }
            else
            {
                label4.Visible = true;

                dataGridView1.Visible = false;
                Message.Visible = false;
            }
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable Table = Control.GetProductByName((int)Type.SelectedValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label2.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Visible = false;
            label6.Visible = false;
            DataTable Table = Control.GetProductByNameSeller((int)Type.SelectedValue , ID);
            if (Table != null)
            {
                label4.Visible = false;
                dataGridView1.DataSource = Table;
                dataGridView1.RowTemplate.Height = 60;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Refresh();
                Message.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                label4.Visible = true;

                dataGridView1.Visible = false;
                Message.Visible = false;
            }
            
        }
    }
}
