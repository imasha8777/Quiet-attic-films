using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Added the required using directive for SqlConnection and SqlCommand
using System.Windows.Forms;


namespace Film
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 previousForm = new Form3();
            previousForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
                string commandString = "INSERT INTO Property (Property_ID, Property_Type, Property_Cost, Property_Name) " +
                                       "VALUES (@Property_ID, @Property_Type, @Property_Cost, @Property_Name)";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        int propertyID;
                        if (int.TryParse(textBox3.Text, out propertyID))
                        {
                            cmd.Parameters.AddWithValue("@Property_ID", propertyID);
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Property_ID not found.");
                            return; // Exit the method
                        }

                        cmd.Parameters.AddWithValue("@Property_Type", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Property_Cost", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Property_Name", textBox8.Text);

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Added Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Property_ID not found.");
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
                string commandString = "UPDATE Property SET Property_Type = @Property_Type, Property_Cost = @Property_Cost, Property_Name = @Property_Name WHERE Property_ID = @Property_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        int propertyID;
                        if (int.TryParse(textBox3.Text, out propertyID))
                        {
                            cmd.Parameters.AddWithValue("@Property_ID", propertyID);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Property_ID not found.");
                            return; // Exit the method
                        }

                        cmd.Parameters.AddWithValue("@Property_Type", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Property_Cost", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Property_Name", textBox8.Text);

                        cnn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Updated Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Property_ID not found.");
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
                string commandString = "DELETE FROM Property WHERE Property_ID = @Property_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        int propertyID;
                        if (int.TryParse(textBox3.Text, out propertyID))
                        {
                            cmd.Parameters.AddWithValue("@Property_ID", propertyID);
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Property_ID not found.");
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
                            MessageBox.Show("No records were deleted. Property_ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
