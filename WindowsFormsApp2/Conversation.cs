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
    public partial class Conversation : Form
    {
        Controller c = new Controller();
        int userid;
        int type;
        public Conversation(int id,int type)
        {
            InitializeComponent();
            userid = id;
            this.type = type;
            
        }

        private void Conversation_Load(object sender, EventArgs e)
        {
            if (type==1)
            {
               dataGridView1.DataSource= c.GetConversationsForSeller(userid);



            }
            else
            {
                dataGridView1.DataSource = c.GetConversationsForCustomer(userid);

            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           object  x=  dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Form7 m;
            if (type == 1)
            {
                 m = new Form7((int)x, userid, 1);



            }
            else
            {
                 m = new Form7(userid, (int)x, 0);

            }
            m.Show();
            

        }
    }
}
