using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class logincustomer : Form
    {
   
        public static logincustomer Customer ;
        int ID;
        Controller Control;
        string FirstName;
        string SecondName;
        public logincustomer()
        {
            
            Customer = this;

            Control = new Controller();
            InitializeComponent();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logincustomer_Load(object sender, EventArgs e)
        {
            label1.Text = FirstName+ " " + SecondName;
           

            DataTable r = Control.getNotificationC(ID);
            textBox2.Clear();
            if (r == null)
            {
                return;
            }
            foreach (DataRow i in r.Rows)
            {
                textBox2.AppendText("  ");
                textBox2.AppendText(i[1].ToString());
                textBox2.AppendText(" sent you message ");
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText("  ");
                textBox2.AppendText(i[0].ToString());
                textBox2.AppendText(Environment.NewLine);
                textBox2.AppendText(" _______________________________________");
                textBox2.AppendText(Environment.NewLine);

                //dataGridView1.Rows.Add(row);

            }
        }
        public void GetName(string rFirst, string rSecond)
        {
            FirstName = rFirst;
            SecondName = rSecond;
        }
        public void GetNameSecond()
        {
            DataRow FullName = Control.GetNameCustomer(ID).Rows[0];
            FirstName = FullName[0].ToString();
            SecondName = FullName[1].ToString();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Form1Instance.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingCustomer F = new SettingCustomer();
            F.TakeParamaters(ID);
            F.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 F = new Form6(ID);
            F.TakeParamaters(ID);
            F.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Conversation c = new Conversation(ID, 0);
            c.Show();

        }
        private void logincustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Form1Instance.Show();
        }
    }
}
