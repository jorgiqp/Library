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
using System.IO;

namespace Library
{
    public partial class view_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Heorhii\source\repos\Library\Library\library_management.mdf;Integrated Security=True");
        string wandet_path;
        string pwd = Class1.GetRandomPassword(20);
        DialogResult result;
        public view_student_info()
        {
            InitializeComponent();
        }

        private void view_student_info_Load(object sender, EventArgs e)
        {
                   

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                disp_students();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
                con.Close();
            }

        }
        public void disp_students()
        {
            try
            {

                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                int i = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Width = 500;
                imageCol.HeaderText = "student image";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 80;
                dataGridView1.Columns.Add(imageCol);

                foreach (DataRow dr in dt.Rows)
                {
                    img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;
                    dataGridView1.Rows[i].Height = 80;
                    i = i + 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_name like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_enrollment_no like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_department like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
                if (comboBox1.SelectedIndex == 4)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_sem like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
                if (comboBox1.SelectedIndex == 5)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_contact like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
                if (comboBox1.SelectedIndex == 6)
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    int i = 0;
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from student_info where student_email like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    Bitmap img;
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Width = 500;
                    imageCol.HeaderText = "student image";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    dataGridView1.Columns.Add(imageCol);

                    foreach (DataRow dr in dt.Rows)
                    {
                        img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 80;
                        i = i + 1;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (comboBox1.SelectedIndex != -1 && comboBox1.SelectedIndex != 0)
            {
                textBox1.Enabled = true;
            }
            else textBox1.Enabled = false;
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            panel1.Visible = true;

            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where id = " + i + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    student_name.Text = dr["student_name"].ToString();
                    student_enroll.Text = dr["student_enrollment_no"].ToString();
                    student_dept.Text = dr["student_department"].ToString();
                    student_sem.Text = dr["student_sem"].ToString();
                    student_contact.Text = dr["student_contact"].ToString();
                    student_email.Text = dr["student_email"].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wandet_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
           
            //pictureBox1.ImageLocation = @"..\..\student_images\" + pwd + ".jpg";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pwd = Class1.GetRandomPassword(20);
            try
            {
                if (result == DialogResult.OK)
                {
                    int i;
                    i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    string img_path;
                    File.Copy(openFileDialog1.FileName, wandet_path + "\\student_images\\" + pwd + ".jpg");

                    img_path = "student_images\\" + pwd + ".jpg";

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update student_info set student_name = '" + student_name.Text + "', student_image = '" + img_path.ToString() + "', student_enrollment_no = '" + student_enroll.Text + "', student_department = '" + student_dept.Text + "', student_sem = '" + student_sem.Text + "', student_contact = '" + student_contact.Text + "', student_email = '" + student_email.Text + "' where Id = '" + i + "'";
                    cmd.ExecuteNonQuery();

                    disp_students();
                    MessageBox.Show("record updated sccessfully", "Message");
                    panel1.Visible = false;
                    student_name.Clear();
                    student_enroll.Clear();
                    student_dept.Clear();
                    student_sem.Clear();
                    student_contact.Clear();
                    student_email.Clear();
                }
                else
                {
                    int i;
                    i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update student_info set student_name = '" + student_name.Text + "', student_enrollment_no = '" + student_enroll.Text + "', student_department = '" + student_dept.Text + "', student_sem = '" + student_sem.Text + "', student_contact = '" + student_contact.Text + "', student_email = '" + student_email.Text + "' where Id = '" + i + "'";
                    cmd.ExecuteNonQuery();

                    disp_students();
                    MessageBox.Show("record updated sccessfully", "Message");
                    panel1.Visible = false;
                    student_name.Clear();
                    student_enroll.Clear();
                    student_dept.Clear();
                    student_sem.Clear();
                    student_contact.Clear();
                    student_email.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from student_info where id = " + i + "";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;


                    

                    disp_students();
                    panel1.Visible = false;
                    MessageBox.Show("Record successfully deleted!", "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                return;
            }
        }
    }
}
