using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.Design;
using System.IO;
using System.Drawing;


namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        string ImagePath;
        private int ID;
        Controller Control;
        public Form5()
        {
            Control = new Controller();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "*.Jpg | *.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImagePath = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ImagePath);
                   
                }
            }

        }
         
        byte[] ConvertImageToBinary(Image Img)                                 // Convert the image to data
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }


        Image ConvertBinaryToImage(byte[] bytes)                                 // Convert the image to data
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int result = Control.AddProduct((int)Price.Value, NameP.Text ,Descreption.Text, (int)Type.SelectedValue, ID, ImagePath);
            if (result > 0)
            {
                int result_2 = Control.IncreaseNumOfProduct((int)Type.SelectedValue);
                result_2++;
                this.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable Table_2 = Control.GetAllCategory();
            Type.DataSource = Control.GetAllCategory();
            Type.DisplayMember = "Name";
            Type.ValueMember = "IDCategory";
        }
        public void TakeParamaters(int rID)
        {
            ID = rID;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
