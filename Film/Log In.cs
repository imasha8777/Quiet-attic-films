using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "imasha" && password == "stark")
            {
                MessageBox.Show("Hi Welcome!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Create and show the new form
                Form3 newForm = new Form3();
                newForm.ShowDialog();

                this.Hide(); // Optionally, hide the current form after the new form is closed
            }
            else
            {
                MessageBox.Show("Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome previousForm = new Welcome();
            previousForm.Show();
            this.Close();
        }
    }
}

