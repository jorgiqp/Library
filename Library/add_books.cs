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

namespace Library
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");
        public add_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                textBox5.Text != "" &&
                textBox6.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into books_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "'," + textBox5.Text + "," + textBox6.Text + ", "+ textBox6.Text +")";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    MessageBox.Show("Books added successfully", "Error");
                }
                else MessageBox.Show("input all values", "Error");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                con.Close();
            }
        }

        private void add_books_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MM.dd.yyyy";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
