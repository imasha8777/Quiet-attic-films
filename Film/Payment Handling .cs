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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
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
                string commandString = "INSERT INTO Payment (Payment_ID, Payment_Date, Payment_Amount, First_Name, Last_Name, Payment_Description, Currency, Production_ID) " +
                    "VALUES (@Payment_ID, @Payment_Date, @Payment_Amount, @First_Name, @Last_Name, @Payment_Description, @Currency, @Production_ID)";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        cnn.Open();

                        int paymentID;
                        if (int.TryParse(textBox3.Text, out paymentID))
                        {
                            cmd.Parameters.AddWithValue("@Payment_ID", paymentID);
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Payment_ID not found.");
                            return; // Exit the method
                        }

                        // Assuming textBox22.Text contains the payment date
                        cmd.Parameters.AddWithValue("@Payment_Date", textBox22.Text);

                        // Assuming textBox1.Text contains the payment amount
                        cmd.Parameters.AddWithValue("@Payment_Amount", textBox1.Text);

                        // Assuming textBox7.Text contains the first name
                        cmd.Parameters.AddWithValue("@First_Name", textBox7.Text);

                        // Assuming textBox8.Text contains the last name
                        cmd.Parameters.AddWithValue("@Last_Name", textBox8.Text);

                        // Assuming textBox12.Text contains the payment description
                        cmd.Parameters.AddWithValue("@Payment_Description", textBox12.Text);

                        // Assuming textBox14.Text contains the currency
                        cmd.Parameters.AddWithValue("@Currency", textBox14.Text);

                        // Assuming textbox2.Text contains the production ID
                        // Assuming textbox2 is your TextBox control for Production_ID
                        cmd.Parameters.AddWithValue("@Production_ID", textBox2.Text);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Added Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were added. Payment_ID not found.");
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
                string commandString = "UPDATE Payment SET Payment_Date = @Payment_Date, Payment_Amount = @Payment_Amount, " +
                    "First_Name = @First_Name, Last_Name = @Last_Name, Payment_Description = @Payment_Description, " +
                    "Currency = @Currency, Production_ID = @Production_ID WHERE Payment_ID = @Payment_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        cnn.Open();

                        int paymentID;
                        if (int.TryParse(textBox3.Text, out paymentID))
                        {
                            cmd.Parameters.AddWithValue("@Payment_ID", paymentID);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Payment_ID not found.");
                            return; // Exit the method
                        }

                        // Assuming textBox22.Text contains the updated payment date
                        cmd.Parameters.AddWithValue("@Payment_Date", textBox22.Text);

                        // Assuming textBox1.Text contains the updated payment amount
                        cmd.Parameters.AddWithValue("@Payment_Amount", textBox1.Text);

                        // Assuming textBox7.Text contains the updated first name
                        cmd.Parameters.AddWithValue("@First_Name", textBox7.Text);

                        // Assuming textBox8.Text contains the updated last name
                        cmd.Parameters.AddWithValue("@Last_Name", textBox8.Text);

                        // Assuming textBox12.Text contains the updated payment description
                        cmd.Parameters.AddWithValue("@Payment_Description", textBox12.Text);

                        // Assuming textBox14.Text contains the updated currency
                        cmd.Parameters.AddWithValue("@Currency", textBox14.Text);

                        // Assuming textBox2.Text contains the updated production ID
                        cmd.Parameters.AddWithValue("@Production_ID", textBox2.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Updated Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Payment_ID not found.");
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
                string commandString = "DELETE FROM Payment WHERE Payment_ID = @Payment_ID";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                    {
                        cnn.Open();

                        int paymentID;
                        if (int.TryParse(textBox3.Text, out paymentID))
                        {
                            cmd.Parameters.AddWithValue("@Payment_ID", paymentID);
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Payment_ID not found.");
                            return; // Exit the method
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record Deleted Successfully");
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Payment_ID not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
