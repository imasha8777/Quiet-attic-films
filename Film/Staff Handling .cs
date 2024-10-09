using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;


namespace Film
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 previousForm = new Form3();
            previousForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Define your connection string
                string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";

                // Check if Staff_ID is not empty
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("No records were added.Staff Id not found");
                    return;
                }

                // Define your SQL command with parameters
                string commandString = "INSERT INTO Staff (Staff_ID, First_Name, Last_Name, City, Street_Name, House_Number, Country, Gender, Date_of_Birth) " +
                    "VALUES (@Staff_ID, @First_Name, @Last_Name, @City, @Street_Name, @House_Number, @Country, @Gender, @Date_of_Birth)";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        // Set parameter values
                        cmd.Parameters.AddWithValue("@Staff_ID", textBox3.Text);
                        cmd.Parameters.AddWithValue("@First_Name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", textBox7.Text);
                        cmd.Parameters.AddWithValue("@City", textBox14.Text);
                        cmd.Parameters.AddWithValue("@Street_Name", textBox16.Text);
                        cmd.Parameters.AddWithValue("@House_Number", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Country", textBox12.Text);

                        // Handle gender selection
                        if (rdoMale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else if (rdoFemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        else
                        {
                            MessageBox.Show("No records were added.Staff Id not found");
                            return;
                        }

                        cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were added.Staff Id not found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";

                // Updated the commandString to use parameters and placeholders
                string commandString = "UPDATE Staff SET First_Name = @First_Name, Last_Name = @Last_Name, City = @City, Street_Name = @Street_Name, House_Number = @House_Number, Country = @Country, Gender = @Gender, Date_of_Birth = @Date_of_Birth WHERE Staff_ID = @Staff_ID";

                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        // Check if Staff_ID is not empty
                        if (string.IsNullOrWhiteSpace(textBox3.Text))
                        {
                            MessageBox.Show("No records were added.Staff Id not found");
                            return;
                        }

                        cmd.Parameters.AddWithValue("@Staff_ID", textBox3.Text);
                        cmd.Parameters.AddWithValue("@First_Name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", textBox7.Text);
                        cmd.Parameters.AddWithValue("@City", textBox14.Text);
                        cmd.Parameters.AddWithValue("@Street_Name", textBox16.Text);
                        cmd.Parameters.AddWithValue("@House_Number", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Country", textBox12.Text);

                        // Handle gender selection
                        if (rdoMale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else if (rdoFemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        else
                        {
                            MessageBox.Show("Please select a gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Staff_ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";

                // Updated the commandString to use parameters and placeholders for the DELETE statement
                string commandString = "DELETE FROM Staff WHERE Staff_ID = @Staff_ID";

                // Check if Staff_ID is not empty
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("No records were added.Staff Id not found");
                    return;
                }

                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Staff_ID", textBox3.Text);
                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Staff_ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label9_Click(object sender, System.EventArgs e)
        {

        }
    }
}
