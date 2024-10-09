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
using System.Data.SqlClient; // Added the required using directive for SqlConnection and SqlCommand
using System.Windows.Forms;


namespace Film
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

      private void button1_Click(object sender, EventArgs e)
{
    try
    {
        string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
        string commandString = "INSERT INTO Production (Production_ID, Main_Title, SubTitle, Submit_Date, End_Date) " +
            "VALUES (@Production_ID, @Main_Title, @SubTitle, @Submit_Date, @End_Date)";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(commandString, cnn))
            {
                int productionID;
                if (int.TryParse(textBox5.Text, out productionID))
                {
                    cmd.Parameters.AddWithValue("@Production_ID", productionID);
                }
                else
                {
                    MessageBox.Show("No records were Added. Production_ID not found.");
                    return; // Exit the method
                }

                cmd.Parameters.AddWithValue("@Main_Title", textBox8.Text);
                cmd.Parameters.AddWithValue("@SubTitle", textBox11.Text);
                cmd.Parameters.AddWithValue("@Submit_Date", textBox22.Text);
                cmd.Parameters.AddWithValue("@End_Date", textBox7.Text);

                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record Added Successfully");
                }
                else
                {
                    MessageBox.Show("No records were Added. Production_ID not found.");
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
              string commandString = "UPDATE Production SET Main_Title = @Main_Title, SubTitle = @SubTitle, Submit_Date = @Submit_Date, End_Date = @End_Date WHERE Production_ID = @Production_ID";

              using (SqlConnection cnn = new SqlConnection(connectionString))
              {
                  using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                  {
                      int productionID;
                      if (int.TryParse(textBox5.Text, out productionID))
                      {
                          cmd.Parameters.AddWithValue("@Production_ID", productionID);
                      }
                      else
                      {
                          MessageBox.Show("No records were updated. Production_ID not found");
                          return; // Exit the method
                      }

                      cmd.Parameters.AddWithValue("@Main_Title", textBox8.Text);
                      cmd.Parameters.AddWithValue("@SubTitle", textBox11.Text);
                      cmd.Parameters.AddWithValue("@Submit_Date", textBox22.Text);
                      cmd.Parameters.AddWithValue("@End_Date", textBox7.Text);

                      cnn.Open();
                      int rowsAffected = cmd.ExecuteNonQuery();

                      if (rowsAffected > 0)
                      {
                          MessageBox.Show("Record Updated Successfully");
                      }
                      else
                      {
                          MessageBox.Show("No records were updated. Production_ID not found.");
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
              string commandString = "DELETE FROM Production WHERE Production_ID = @Production_ID";

              using (SqlConnection cnn = new SqlConnection(connectionString))
              {
                  using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                  {
                      int productionID;
                      if (int.TryParse(textBox5.Text, out productionID))
                      {
                          cmd.Parameters.AddWithValue("@Production_ID", productionID);
                      }
                      else
                      {
                          MessageBox.Show("No records were deleted. Production_ID not found.");
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
                          MessageBox.Show("No records were deleted. Production_ID not found.");
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
            this.Hide(); // Changed to hide the current form instead of closing it.
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // ... (code for textBox8_TextChanged, if applicable)
        }

        private void Form5_Load(object sender, System.EventArgs e)
        {

        }
    }
}
