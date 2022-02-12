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
    public partial class return_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");
        int i = 0;
        public return_books()
        {
            InitializeComponent();
        }

        private void return_books_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MM.dd.yyyy";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_grid(textBox1.Text);
            
        }
        public void fill_grid(string enrollment)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where student_enrollment = '" + enrollment.ToString() + "' and books_return_date = '' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                if (i == 0)
                {
                    panel2.Visible = false;
                    MessageBox.Show("No books under this enrollment", "Error");             
                }
                else
                {
                    panel2.Visible = true;                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;

            int j;
            j = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where Id = " + j + " ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lbl_booksName.Text = dr["books_name"].ToString();
                lbl_issuedate.Text = dr["books_issue_date"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j;
            j = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issue_books set books_return_date = '" + dateTimePicker1.Text + "' where Id = "+ j +" ";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update books_info set available_qty = available_qty + 1 where books_name = '" + lbl_booksName.Text + "' ";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Books return successfully","Message");
                       
            panel3.Visible = false;

            fill_grid(textBox1.Text);
            textBox1.Clear();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
