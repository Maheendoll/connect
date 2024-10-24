using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connString = "Data Source=DESKTOP-M561BCP\\;Initial Catalog=Product;Integrated Security=True";
          
            string fname = textBox1.Text;
            string pass = textBox2.Text;

            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();


                    string query = "INSERT INTO logins (name, email) VALUES (@name, @email)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", fname);
                        cmd.Parameters.AddWithValue("@email", pass);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-M561BCP\\;Initial Catalog=Product;Integrated Security=True";

            string emailToDelete = textBox3.Text;

            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM logins WHERE email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", emailToDelete);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Deleted");
                        }
                        else
                        {
                            MessageBox.Show("No record found with that email.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
   
