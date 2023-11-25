using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Registration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Replace "your_connection_string_here" with your actual database connection string
            string connectionString = "Server=tcp:sqlappregtest.database.windows.net,1433;Initial Catalog=registration;Persist Security Info=False;User ID=sqluser;Password=Azure@12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                    using (SqlConnection regcon = new SqlConnection(connectionString))
                {
                    regcon.Open();

                    using (SqlCommand insert = new SqlCommand("InsertEmployee", regcon))
                    {
                        insert.CommandType = CommandType.StoredProcedure;

                        // Assuming you have variables for the values you want to insert
                        insert.Parameters.AddWithValue("@emp_id", Eid.Text);
                        insert.Parameters.AddWithValue("@full_name", FullName.Text);
                        insert.Parameters.AddWithValue("@department", Dept.Text);
                        insert.Parameters.AddWithValue("@email", mail.Text);


                        insert.ExecuteNonQuery();
                        Response.Write("Employee inserted successfully!");
                        ClearInputFields();
                        regcon.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Check if the exception is due to a primary key violation
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Handle the primary key violation error here
                    // You can display a user-friendly message or log the error
                    Response.Write("Employee ID already exists. Please choose a different ID.");
                }
                else
                {
                    // Handle other SQL exceptions
                    // You can display a user-friendly message or log the error
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions (not SQL-related)
                // You can display a user-friendly message or log the error
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        private void ClearInputFields()
        {
            // Assuming you have TextBox controls for input fields
            Eid.Text = "";
            FullName.Text = "";
            Dept.Text = "";
            mail.Text = "";
        }

    }
}