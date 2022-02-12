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
    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");

        public issue_books()
        {
            InitializeComponent();
        }

        private void issue_books_Load(object sender, EventArgs e)
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
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_enrollment_no = '" + txt_enrollment.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 0)
                {
                    MessageBox.Show("Enrollment not found", "Error");
                    txt_enrollment.Clear();
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txt_studentname.Text = dr["student_name"].ToString();
                        txt_studentdept.Text = dr["student_department"].ToString();
                        txt_studentsem.Text = dr["student_sem"].ToString();
                        txt_studentcontact.Text = dr["student_contact"].ToString();
                        txt_studentemail.Text = dr["student_email"].ToString();
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txt_enrollment_TextChanged(object sender, EventArgs e)
        {
            if (txt_enrollment.Text != "")
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;
        }

        private void txt_booksname_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;

            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    listBox1.Items.Clear();


                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where books_name like('%" + txt_booksname.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    count = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (count > 0)
                    {
                        listBox1.Visible = true;
                        foreach (DataRow dr in dt.Rows)
                        {
                            listBox1.Items.Add(dr["books_name"].ToString());
                        }
                    }
                }

                if (txt_booksname.Text == "")
                {
                    listBox1.Items.Clear();
                    listBox1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txt_booksname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_booksname.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_booksname.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int books_qty = 0;
            if (txt_enrollment.Text != "" &&
                txt_studentdept.Text != "" &&
                txt_studentemail.Text != "" &&
                txt_studentname.Text != "" &&
                txt_studentsem.Text != "" &&
                txt_studentcontact.Text != "" &&
                txt_booksname.Text != "")
            {
                try
                {
                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select * from books_info where books_name = '" + txt_booksname.Text + "' ";
                    cmd2.ExecuteNonQuery();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    da2.Fill(dt2);

                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        books_qty = Convert.ToInt32(dr2["available_qty"].ToString());
                    }

                    if (books_qty > 0)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into issue_books values('" + txt_enrollment.Text + "', '" + txt_studentname.Text + "', '" + txt_studentdept.Text + "', '" + txt_studentsem.Text + "', '" + txt_studentcontact.Text + "', '" + txt_studentemail.Text + "', '" + txt_booksname.Text + "','" + dateTimePicker1.Text + "', '')";
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "update books_info set available_qty = available_qty - 1 where books_name = '" + txt_booksname.Text + "' ";
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("Issue added successfully", "Message");
                        txt_enrollment.Clear();
                        txt_booksname.Clear();
                        txt_studentcontact.Clear();
                        txt_studentemail.Clear();
                        txt_studentsem.Clear();
                        txt_studentdept.Clear();
                    }
                    else MessageBox.Show("book is not available", "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Input all fields","Error");
            }
        }
    }
}
