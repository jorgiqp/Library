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
    public partial class view_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");
        public view_books()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void view_books_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button4, "choose books at the table, to delete");
            dateTimePicker1.CustomFormat = "MM.dd.yyyy";
            disp_books();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp_books();
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0 && textBox1.Text != "")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where books_name like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    con.Close();
                }
                else MessageBox.Show("Enter books name", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedIndex != 0) textBox1.Enabled = true;
            else textBox1.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books_info set books_name = '" + booksname.Text + "', books_author_name = '" + booksauthor.Text + "', books_publication_name = '" + bookspublic.Text + "', books_purchase_date = '" + dateTimePicker1.Text + "', books_price = " + booksprice.Text + ", books_quantity = " + booksqty.Text + " where id = " + i + "";
                cmd.ExecuteNonQuery();
                con.Close();

                disp_books();
                panel2.Visible = false;
                MessageBox.Show("record updated", "Message");
                
                booksname.Text = "";
                booksauthor.Text = "";
                bookspublic.Text = "";
                booksprice.Text = "";
                booksqty.Text = "";
                dateTimePicker1.Value = Convert.ToDateTime(System.DateTime.Now.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                con.Close();
            }
        }

        private void booksname_TextChanged(object sender, EventArgs e)
        {
            if (booksname.Text != "")
            {
                button3.Enabled = true;
            }
            else button3.Enabled = false;
        }

        private void booksauthor_TextChanged(object sender, EventArgs e)
        {
            if (booksauthor.Text != "")
            {
                button3.Enabled = true;
            }
            else button3.Enabled = false;
        }

        private void bookspublic_TextChanged(object sender, EventArgs e)
        {
            if (bookspublic.Text != "")
            {
                button3.Enabled = true;
            }
            else button3.Enabled = false;
        }

        private void booksprice_TextChanged(object sender, EventArgs e)
        {
            if (booksprice.Text != "")
            {
                button3.Enabled = true;
            }
            else button3.Enabled = false;
        }

        private void booksqty_TextChanged(object sender, EventArgs e)
        {
            if (booksqty.Text != "")
            {
                button3.Enabled = true;
            }
            else button3.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            //MessageBox.Show(i.ToString(), "Message");
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info where id = " + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    booksname.Text = dr["books_name"].ToString();
                    booksauthor.Text = dr["books_author_name"].ToString();
                    bookspublic.Text = dr["books_publication_name"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr["books_purchase_date"].ToString());
                    booksprice.Text = dr["books_price"].ToString();
                    booksqty.Text = dr["books_quantity"].ToString();
                }

                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Do you really want to delete this book?",
                                             "Books deleting",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from books_info where id = "+ i +"";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    
                    con.Close();

                    disp_books();
                    panel2.Visible = false;
                    MessageBox.Show("Record successfully deleted!", "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    con.Close();
                }
            }
            else
            { 
                return;
            }

        }
        public void disp_books()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from books_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                con.Close();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            try
            {
                
                    if (comboBox1.SelectedIndex == 1)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from books_info where books_name like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        dataGridView1.DataSource = dt;

                        con.Close();

                        
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from books_info where books_author_name like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        dataGridView1.DataSource = dt;

                        con.Close();

                       
                    }

                    if (comboBox1.SelectedIndex == 3)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from books_info where books_publication_name like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        dataGridView1.DataSource = dt;

                        con.Close();

                    }

                    if (comboBox1.SelectedIndex == 4)
                    {
                        
                    con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from books_info where books_price like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        dataGridView1.DataSource = dt;

                        con.Close();

                        
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from books_info where books_quantity like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        i = Convert.ToInt32(dt.Rows.Count.ToString());

                        dataGridView1.DataSource = dt;

                        con.Close();

                    }
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                con.Close();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
            }
            
        }
    }
}
