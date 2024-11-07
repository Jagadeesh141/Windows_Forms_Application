using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsForfs
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("password and confirmpassword not matched");
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
                this.Close();
                return;
            }

            try
            {
                string connectingString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PatientForm;Integrated Security=True;Connect Timeout=30;Encrypt=False";
                using (SqlConnection conn = new SqlConnection(connectingString))
                {


                    string query = "INSERT INTO Register (username, email, password) VALUES (@username, @email, @password)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show(" Registation Success");
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






            }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox3.UseSystemPasswordChar = checkBox1.Checked;
            }
            else
            {
                textBox3.UseSystemPasswordChar = !checkBox1.Checked;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = checkBox2.Checked;
            }
            else
            {
                textBox4.UseSystemPasswordChar = !checkBox2.Checked;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            textBox3.UseSystemPasswordChar = !checkBox1.Checked; 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = !checkBox2.Checked;
        }
    }
    }

