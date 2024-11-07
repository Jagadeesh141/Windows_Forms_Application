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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsForfs
{
    public partial class Form2 : Form
    {
        string connectingString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PatientForm;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
              
           


        }


        private bool ValidateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                string query = "SELECT COUNT(1) FROM Register WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            if (ValidateUser(username, password))
            {
                MessageBox.Show("Login Successful!");

                // Open the main form and close the login form
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            }
            else
            {
                textBox2.UseSystemPasswordChar = checkBox1.Checked;

            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3 mainForm = new Form3();
            mainForm.ShowDialog();
            this.Close();


        }
    }
}
