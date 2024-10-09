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
using System;
using System.Data.SqlClient;


namespace Film
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


       private void button5_Click(object sender, EventArgs e)
{
    try
    {
        string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
        string commandString = "INSERT INTO Client (Client_ID, First_Name, Last_Name, City, Street_Number, House_Number, Country, Gender, Date_of_Birth, Production_ID) " +
            "VALUES (@Client_ID, @First_Name, @Last_Name, @City, @Street_Number, @House_Number, @Country, @Gender, @Date_of_Birth, @Production_ID)";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(commandString, cnn))
            {
                int clientID;
                if (int.TryParse(textBox3.Text, out clientID))
                {
                    cmd.Parameters.AddWithValue("@Client_ID", clientID);
                }
                else
                {
                    MessageBox.Show("No records were added. ClientID not found");
                    return; // Don't proceed if input is not valid.
                }
                
                cmd.Parameters.AddWithValue("@First_Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@Last_Name", textBox7.Text);
                cmd.Parameters.AddWithValue("@City", textBox14.Text);
                cmd.Parameters.AddWithValue("@Street_Number", textBox16.Text);
                cmd.Parameters.AddWithValue("@House_Number", textBox1.Text);
                cmd.Parameters.AddWithValue("@Country", textBox12.Text);

                SqlParameter genderParam = new SqlParameter("@Gender", SqlDbType.NVarChar, 10);
                if (rdoMale.Checked)
                {
                    genderParam.Value = "Male";
                }
                else if (rdoFemale.Checked)
                {
                    genderParam.Value = "Female";
                }
                else
                {
                    genderParam.Value = "Unknown";
                }
                cmd.Parameters.Add(genderParam);

                cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);
                
                int productionID;
                if (int.TryParse(textBox6.Text, out productionID))
                {
                    cmd.Parameters.AddWithValue("@Production_ID", productionID);
                }
                else
                {
                    MessageBox.Show("Invalid Production_ID. Please enter a valid integer.");
                    return; // Don't proceed if input is not valid.
                }
                
                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record Added Successfully");
                }
                else
                {
                    MessageBox.Show("No records were added. An error occurred.");
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}

       private void button6_Click(object sender, EventArgs e)
       {
           try
           {
               string connectionstring = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
               string commandString = "UPDATE Client SET First_Name = @First_Name, Last_Name = @Last_Name, City = @City, Street_Number = @Street_Number, House_Number = @House_Number, Country = @Country, Gender = @Gender, Date_of_Birth = @Date_of_Birth, Production_ID = @Production_ID WHERE Client_ID = @Client_ID";

               using (SqlConnection cnn = new SqlConnection(connectionstring))
               {
                   using (SqlCommand cmd = new SqlCommand(commandString, cnn))
                   {
                       int clientID;
                       if (int.TryParse(textBox3.Text, out clientID))
                       {
                           cmd.Parameters.AddWithValue("@Client_ID", clientID);
                       }
                       else
                       {
                           MessageBox.Show("Invalid Client ID. Please enter a valid integer.");
                           return; // Don't proceed if input is not valid.
                       }

                       cmd.Parameters.AddWithValue("@First_Name", textBox5.Text);
                       cmd.Parameters.AddWithValue("@Last_Name", textBox7.Text);
                       cmd.Parameters.AddWithValue("@City", textBox14.Text);
                       cmd.Parameters.AddWithValue("@Street_Number", textBox16.Text);
                       cmd.Parameters.AddWithValue("@House_Number", textBox1.Text);
                       cmd.Parameters.AddWithValue("@Country", textBox12.Text);

                       SqlParameter genderParam = new SqlParameter("@Gender", SqlDbType.NVarChar, 10);
                       if (rdoMale.Checked)
                       {
                           genderParam.Value = "Male";
                       }
                       else if (rdoFemale.Checked)
                       {
                           genderParam.Value = "Female";
                       }
                       else
                       {
                           genderParam.Value = "Unknown";
                       }
                       cmd.Parameters.Add(genderParam);

                       cmd.Parameters.AddWithValue("@Date_of_Birth", textBox8.Text);

                       int productionID;
                       if (int.TryParse(textBox6.Text, out productionID))
                       {
                           cmd.Parameters.AddWithValue("@Production_ID", productionID);
                       }
                       else
                       {
                           MessageBox.Show("Invalid Production ID. Please enter a valid integer.");
                           return; // Don't proceed if input is not valid.
                       }

                       cnn.Open();
                       int rowsAffected = cmd.ExecuteNonQuery();

                       if (rowsAffected > 0)
                       {
                           MessageBox.Show("Record Updated Successfully");
                       }
                       else
                       {
                           MessageBox.Show("No records were updated. Client ID not found.");
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       }

private void button7_Click(object sender, EventArgs e)
{
    try
    {
        string connectionString = "Data Source=DESKTOP-GBBRP0U\\SQLEXPRESS;Initial Catalog=QUIET_ATTIC_FILMS;Integrated Security=True";
        string commandString = "DELETE FROM Client WHERE Client_ID = @Client_ID";

        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(commandString, cnn))
            {
                int clientID;
                if (int.TryParse(textBox3.Text, out clientID))
                {
                    cmd.Parameters.AddWithValue("@Client_ID", clientID);
                }
                else
                {
                    MessageBox.Show("No records were deleted. ClientID not found.");
                    return; // Don't proceed if input is not valid.
                }

                cnn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("No records were deleted. Client_ID not found.");
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("An error occurred: " + ex.Message);
    }
}

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 previousForm = new Form3();
            previousForm.Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        
        }
    }
}

