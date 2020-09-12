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
    public partial class Form6 : Form
    {
        
        int ID;
        int IDSeller ;
        int IDProduct;
        Controller Control;
        DataTable Table;


        ///////////// sarah mohamed ////////////////////
        int idProduct;
        int Customerid;
        int count = 0;
        //  /////////////////     //////////

        public Form6(int customerid)
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
            label10.Visible = false;
            label2.Visible = false;
            
            textBox1.Visible = false;
            textBox2.Visible = false;
            

            label6.Visible = false;
            label7.Visible = false;
            comboBox1.Visible = false;
        

            button1.Visible = false;
            button2.Visible = false;
            label12.Visible = false;
            textBox3.Visible = false;

            pictureBox1.Visible = false;


            //sarah mohamed//
            button4.Visible = false;
            comboBox1.DataSource = new string[] { "1", "2", "3", "4", "5" };
            Customerid = customerid;

            // ///

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(ID,IDSeller,0);
            f.Show();
            this.Close();
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Table = Control.GetAllProducts();
            textBox3.ReadOnly = true;

            DataTable Table_2 = Control.GetAllCategory();
            Type.DataSource = Control.GetAllCategory();
            Type.DisplayMember = "Name";
            Type.ValueMember = "IDCategory";

            if(Table!= null)
            {
                label11.Visible = false;
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
                label11.Visible = true;
                dataGridView1.Visible = false;
                Message.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                label1.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                pictureBox1.Visible = true;
                Message.Visible = false;
                button2.Visible = true;
                label12.Visible = true;
                textBox3.Visible = true;

                button4.Visible = true;
                DataGridViewRow R = this.dataGridView1.Rows[e.RowIndex];
                string Phone = (string)Control.GetPhone((int)R.Cells[6].Value);
                pictureBox1.Image = Image.FromFile((string)R.Cells[7].Value);
                label1.Text = (string)R.Cells[2].Value;
                label8.Text = R.Cells[1].Value.ToString();
                label10.Text = Phone;
                label9.Text = (string)R.Cells[4].Value.ToString();
                textBox2.Text = (string)R.Cells[3].Value;
                IDSeller = (int)R.Cells[6].Value;
                IDProduct= (int)R.Cells[0].Value;

                DataTable Comments = Control.GetCommentsForProduct(IDProduct);
                if (Comments!=null)
                {
                    foreach (DataRow i in Comments.Rows)
                    {

                        textBox3.AppendText(i[1].ToString());
                        textBox3.AppendText(Environment.NewLine);
                        textBox3.AppendText("   ");
                        textBox3.AppendText(i[0].ToString());
                        textBox3.AppendText(Environment.NewLine);
                        textBox3.AppendText(i[2].ToString());
                        textBox3.AppendText(Environment.NewLine);
                        textBox3.AppendText(Environment.NewLine);
                    }

                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                return;

            }
            Control.addComment(ID, IDProduct, textBox1.Text.ToString());
            textBox1.Text = "";
            DataTable Comments = Control.GetCommentsForProduct(IDProduct);
            if (Comments != null)
            {
                foreach (DataRow i in Comments.Rows)
                {
                    textBox3.AppendText(i[1].ToString());
                    textBox3.AppendText(Environment.NewLine);
                    textBox3.AppendText("   ");
                    textBox3.AppendText(i[0].ToString());
                    textBox3.AppendText(Environment.NewLine);
                    textBox3.AppendText(i[2].ToString());
                    textBox3.AppendText(Environment.NewLine);
                    textBox3.AppendText(Environment.NewLine);
                }
            }
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
            button4.Visible = false;

            label10.Visible = false;
            label4.Visible = false;
            label12.Visible = false;
            label7.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;


            DataTable Table = Control.GetProductByNameAll((int)Type.SelectedValue);
            if (Table != null)
            {
                Message.Visible = true;
                label11.Visible = false;
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
                dataGridView1.Visible = true;
            }
            else
            {
               label11.Visible = true;

                dataGridView1.Visible = false;
                Message.Visible = false;
            }
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            object result = Control.GetCustomerID(Customerid, IDProduct);
            if (result == null)
            {
                Control.Addrate(IDProduct, Customerid, Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                float ss = Convert.ToSingle(Control.GetSumRate(IDProduct));
                float result_1 = ss / (int)Control.getNoOfRatesOfproduct(IDProduct);
                result_1=(float)(Math.Round((double)result_1, 2));
                Control.Updaterate(result_1, IDProduct);
                label9.Text = Control.GetTotalRate(IDProduct).ToString();
                MessageBox.Show("Thanks you for rating ! ");
            }
            else
            {
                Control.updaterateinRatetable(IDProduct, Customerid, Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                float ss = Convert.ToSingle(Control.GetSumRate(IDProduct));
                float result_2 = ss / (int)Control.getNoOfRatesOfproduct(IDProduct);
                result_2 = (float)(Math.Round((double)result_2, 2));
                Control.Updaterate(result_2, IDProduct);
                label9.Text = Control.GetTotalRate(IDProduct).ToString();
                MessageBox.Show("Thanks you for rating ! ");
            }

        }
    }
}
