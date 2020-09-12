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
    public partial class Form4 : Form
    {
        
        public static Form4 Seller;
        

        int ID;
        Controller Control;
        string FirstName;
        string SecondName;
        public Form4()
        {
            
            Seller = this;

            Control = new Controller();
            InitializeComponent();
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = FirstName + " " + SecondName;
            textBox2.ScrollBars = ScrollBars.Horizontal;
            textBox2.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Horizontal;
            textBox1.ReadOnly = true;
            DataTable r = Control.getNotificationSM(ID);
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
            }

            DataTable r2 = Control.getNotificationSC(ID);
            textBox1.Clear();
            if (r2 == null)
            {
                return;
            }
            foreach (DataRow i in r2.Rows)
            {
                textBox1.AppendText("  ");
                textBox1.AppendText(i[1].ToString());
                textBox1.AppendText(" commented on your product '");
                textBox1.AppendText(i[2].ToString());
                textBox1.AppendText("'");
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("  ");
                textBox1.AppendText(i[0].ToString());
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(" _______________________________________");
                textBox1.AppendText(Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.TakeParamaters(ID);
            f.Show();
        }
        public void GetName(string rFirst, string rSecond)
        {
            FirstName = rFirst;
            SecondName = rSecond;
        }
        public void GetNameSecond()
        {
            DataRow FullName = Control.GetNameSeller(ID).Rows[0];
            FirstName = FullName[0].ToString();
            SecondName = FullName[1].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Form1Instance.Show();
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SettingSeller F = new SettingSeller();
            F.TakeParamaters(ID);
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyProducts F = new MyProducts();
            F.TakeParamaters(ID);
            F.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Conversation c = new Conversation(ID,1);
            c.Show();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Form1Instance.Show();
        }
    }
}
