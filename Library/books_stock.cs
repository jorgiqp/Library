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
using System.Net.Mail;
using System.Net;

namespace Library
{
    public partial class books_stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");

        public books_stock()
        {
            InitializeComponent();
        }

        private void books_stock_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_books_info();
        }
        public void fill_books_info()
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select books_name, books_author_name, books_quantity, available_qty from books_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where books_name = '" + i + "' and books_return_date = '' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {            
           if (comboBox1.SelectedIndex == 1)
            {                
                search_info("books_name");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                search_info("books_author_name");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                search_info("books_quantity");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                search_info("available_qty");
            }
        }
        public void search_info(string zxc)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select books_name, books_author_name, books_quantity, available_qty from books_info where "+ zxc.ToString() +" like ('%" + textBox1.Text + "%') ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_books_info();
            textBox1.Clear();
            if (comboBox1.SelectedIndex == -1 && comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
            }
            else textBox1.Enabled = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            textBox2.Text = i.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("georgiy.y.pitsyk@gmail.com", "42visifa");
                    MailMessage mail = new MailMessage("georgiy.y.pitsyk@gmail.com", textBox2.Text, "this is for book return notice", textBox3.Text);
                    mail.Priority = MailPriority.High;
                    smtp.Send(mail);
                    MessageBox.Show("Mail send", "Message");
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else MessageBox.Show("Input all fields", "Message");
        }
    }
}
