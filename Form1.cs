using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForfs
{
    public partial class Form1 : Form
    {
        string connectingString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PatientForm;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
            DisplayData(); // Show data on form load
        }
        private void DisplayData()
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PatientData", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                PatientsDataGrid.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectingString))
            {
                string query = "INSERT INTO PatientData (Patient_id, First_name, Last_name, Date_of_birth, Marital_status, Email, Contact_Number," +
                    "Street_Address, Street_Address_Line_2, City, State, Pincode, Sex) VALUES (@id,@First_name, @Last_name, @Date_of_birth, @Marital_status, @Email, @Contact_Number,@Street_Address, @Street_Address_Line_2, @City, @State, @Pincode, @Sex)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@First_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Last_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date_of_birth",DateTime.Parse( dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@Marital_status", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Email",textBox4.Text );
                cmd.Parameters.AddWithValue("@Contact_Number",long.Parse( textBox3.Text));
                cmd.Parameters.AddWithValue("@Street_Address",textBox5.Text );
                cmd.Parameters.AddWithValue("@Street_Address_Line_2", textBox6.Text);
                cmd.Parameters.AddWithValue("@City", textBox7.Text);
                cmd.Parameters.AddWithValue("@State",textBox8.Text );
                cmd.Parameters.AddWithValue("@Pincode",long.Parse( textBox9.Text));
                cmd.Parameters.AddWithValue("@Sex", comboBox2.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Record Added Successfully");
                DisplayData();
                ClearFields();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PatientsDataGrid.SelectedRows.Count > 0)
            {
                Guid id = (Guid)(PatientsDataGrid.SelectedRows[0].Cells["Patient_id"].Value);

                using (SqlConnection conn = new SqlConnection(connectingString))
                {
                    string query = "UPDATE PatientData SET  First_name = @First_name, Last_name = @Last_name, Date_of_birth = @Date_of_birth, Marital_status = @Marital_status, Email = @Email, Contact_Number = @Contact_Number," +
                        "Street_Address = @Street_Address, Street_Address_Line_2 = @Street_Address_Line_2 , City = @City, State = @State, Pincode = @Pincode, Sex = @Sex WHERE Patient_id=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                   
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@First_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Last_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Date_of_birth", DateTime.Parse(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@Marital_status", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contact_Number", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Street_Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Street_Address_Line_2", textBox6.Text);
                    cmd.Parameters.AddWithValue("@City", textBox7.Text);
                    cmd.Parameters.AddWithValue("@State", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Pincode", textBox9.Text);
                    cmd.Parameters.AddWithValue("@Sex", comboBox2.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PatientsDataGrid.SelectedRows.Count > 0)
            {
                Guid id = (Guid)(PatientsDataGrid.SelectedRows[0].Cells["Patient_id"].Value);

                using (SqlConnection conn = new SqlConnection(connectingString))
                {
                    string query = "DELETE FROM PatientData WHERE Patient_id=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Record Deleted Successfully");
                    DisplayData();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Helper method to clear TextBoxes
        private void ClearFields()
        {


            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            

        }


        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PatientsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = PatientsDataGrid.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
               
                textBox2.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
                textBox3.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox6.Text = row.Cells[8].Value.ToString();
                textBox7.Text = row.Cells[9].Value.ToString();
                textBox8.Text = row.Cells[10].Value.ToString();
                textBox9.Text = row.Cells[11].Value.ToString();
                comboBox2.Text = row.Cells[12].Value.ToString();
                
            }
        }
    }
}
