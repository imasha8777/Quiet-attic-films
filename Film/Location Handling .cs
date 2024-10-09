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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
                string commandString = "INSERT INTO Location (Location_ID, Location_Type, Name, Email, Mobile_Number, Date_of_Birth, Location_Description, City, Street_Name, House_Number, Property_ID) " +
                    "VALUES (@Location_ID, @Location_Type, @Name, @Email, @Mobile_Number, @Date_of_Birth, @Location_Description, @City, @Street_Name, @House_Number, @Property_ID)";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        cnn.Open();
                        int locationID;
                        if (int.TryParse(textBox3.Text, out locationID))
                        {
                            cmd.Parameters.AddWithValue("@Location_ID", locationID);
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Location_ID not found.");
                            return; // Exit the method
                        }

                        cmd.Parameters.AddWithValue("@Location_Type", textBox20.Text);
                        cmd.Parameters.AddWithValue("@Name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox16.Text);
                        cmd.Parameters.AddWithValue("@Mobile_Number", textBox22.Text);
                        cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);
                        cmd.Parameters.AddWithValue("@Location_Description", textBox21.Text);
                        cmd.Parameters.AddWithValue("@City", textBox9.Text);
                        cmd.Parameters.AddWithValue("@Street_Name", textBox4.Text);
                        cmd.Parameters.AddWithValue("@House_Number", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Property_ID", textBox11.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Added Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Location_ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
                string commandString = "UPDATE Location SET Location_Type = @Location_Type, Name = @Name, Email = @Email, Mobile_Number = @Mobile_Number, Date_of_Birth = @Date_of_Birth, Location_Description = @Location_Description, City = @City, Street_Name = @Street_Name, House_Number = @House_Number, Property_ID = @Property_ID WHERE Location_ID = @Location_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        int locationID;
                        if (int.TryParse(textBox3.Text, out locationID))
                        {
                            cmd.Parameters.AddWithValue("@Location_ID", locationID);
                        }
                        else
                        {
                            MessageBox.Show("Location_ID not found. Cannot update the record.");
                            return; // Exit the method
                        }

                        cmd.Parameters.AddWithValue("@Location_Type", textBox20.Text);
                        cmd.Parameters.AddWithValue("@Name", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox16.Text);
                        cmd.Parameters.AddWithValue("@Mobile_Number", textBox22.Text);
                        cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);
                        cmd.Parameters.AddWithValue("@Location_Description", textBox21.Text);
                        cmd.Parameters.AddWithValue("@City", textBox9.Text);
                        cmd.Parameters.AddWithValue("@Street_Name", textBox4.Text);
                        cmd.Parameters.AddWithValue("@House_Number", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Property_ID", textBox11.Text);

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Updated Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Location_ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
                string commandString = "DELETE FROM Location WHERE Location_ID = @Location_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        int locationID;
                        if (int.TryParse(textBox3.Text, out locationID))
                        {
                            cmd.Parameters.AddWithValue("@Location_ID", locationID);
                        }
                        else
                        {
                            MessageBox.Show("Location_ID not found. Cannot delete the record.");
                            return; // Exit the method
                        }

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Deleted Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Location_ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 previousForm = new Form3();
            previousForm.Show();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, System.EventArgs e)
        {
        
        }
    }
}
