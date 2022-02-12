using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Library
{
    public partial class add_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");
        int i;
        string wandet_path;
        public add_student_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = Class1.GetRandomPassword(20);
            wandet_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //pictureBox1.ImageLocation = @"..\..\student_images\" + pwd + ".jpg";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            i = i + 8;
            if (textBox7.Text != "" &&
                textBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                textBox4.Text != "" &&
                textBox5.Text != "" &&
                textBox6.Text != "" &&
                pictureBox1.Image != null)
            {
                try
                {
                    string img_path;
                    File.Copy(openFileDialog1.FileName, wandet_path + "\\student_images\\" + textBox7.Text + ".jpg");

                    img_path = "student_images\\" + textBox7.Text + ".jpg";


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into student_info values ('" + textBox1.Text + "','" + img_path + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("record inserted successfully", "Message");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    pictureBox1.Image = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    con.Close();
                }
            }
            else MessageBox.Show("Input all fields", "Message");
        }

        private void add_student_info_Load(object sender, EventArgs e)
        {

        }
    }
}
