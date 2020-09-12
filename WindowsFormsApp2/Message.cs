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

    public partial class Form7 : Form
    {
        Controller c;
        int customer;
        int seller;
        int type;
        string sellername;
        string customername;

        public Form7(int customerID, int sellerID, int type)
        {
            InitializeComponent();
            c = new Controller();
            customer = customerID;
            seller = sellerID;
            this.type = type;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DataRow r = c.GetNameSeller(seller).Rows[0];

            sellername = r[0].ToString();
            customername = c.GetNameCustomer(customer).Rows[0][0].ToString();
            textBox2.ScrollBars = ScrollBars.Horizontal;
            textBox2.ReadOnly = true;

            if (type == 0)
            {
                this.Text = sellername;

            }
            else
            {
                this.Text = customername;

            }
            displayMessages();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;

            }

            int d = c.sendMessage(customer, seller, type, textBox1.Text.ToString());
            displayMessages();
            textBox1.Text = "";





        }
        private void displayMessages()
        {
            DataTable r = c.GetMessages(customer, seller);
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            textBox2.Clear();

            if (r == null)
            {
                return;

            }



            foreach (DataRow i in r.Rows)
            {





                if (i[3].ToString() == "0")
                {
                    //row.Cells[0].Value =  customername;
                    textBox2.AppendText(customername);
                    textBox2.AppendText(Environment.NewLine);

                }
                else
                {
                    //row.Cells[0].Value = sellername;
                    textBox2.AppendText(sellername);
                    textBox2.AppendText(Environment.NewLine);

                }
                textBox2.AppendText("   ");
                textBox2.AppendText(i[5].ToString());
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(i[6].ToString());
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(Environment.NewLine);

                //dataGridView1.Rows.Add(row);



            }



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
