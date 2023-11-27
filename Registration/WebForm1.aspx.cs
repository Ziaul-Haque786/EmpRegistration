using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

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
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            
            //string connectionString = "Server=tcp:empreg.database.windows.net,1433;Initial Catalog=Employee_Registration;Persist Security Info=False;User ID=sqluser;Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                    using (SqlConnection regcon = new SqlConnection(connectionString))
                {
                    regcon.Open();

                    using (SqlCommand insert = new SqlCommand("InsertEmployee", regcon))
                    {
                        if (string.IsNullOrWhiteSpace(FullName.Text) || string.IsNullOrWhiteSpace(Eid.Text) || string.IsNullOrWhiteSpace(Dept.Text) || string.IsNullOrWhiteSpace(mail.Text))
                        {
                            // Display an error message using JavaScript
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "showError", "showToast('error', 'Please fill in all the fields.');", true);
                            return;
                        }
                        if (IsEmailInUse(mail.Text, regcon))
                        {
                            // Display an error message using JavaScript
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "showError", "showToast('error', 'Email address is already in use. Please choose a different email.');", true);
                            return;
                        }
                        insert.CommandType = CommandType.StoredProcedure;

                        // Assuming you have variables for the values you want to insert
                        insert.Parameters.AddWithValue("@EmployeeID", Eid.Text)
                        insert.Parameters.AddWithValue("@FullName", FullName.Text);
                        insert.Parameters.AddWithValue("@Department", Dept.Text);
                        insert.Parameters.AddWithValue("@Email", mail.Text);


                        insert.ExecuteNonQuery();
                        string successScript = "showToast('success', 'Employee inserted successfully!');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "successScript", successScript, true);
                        ClearInputFields();
                        regcon.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Your existing code

                // Display error toast message
                string errorScript = "showToast('error', '" + GetMessageBasedOnErrorCode(ex.Number) + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorScript", errorScript, true);
            }
            catch (Exception ex)
            {
                // Your existing code

                // Display error toast message
                string errorScript = "showToast('error', 'An error occurred: " + ex.Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorScript", errorScript, true);
            }
        }

        private bool IsEmailInUse(string email, SqlConnection regcon)
        {
            if (regcon.State != ConnectionState.Open)
            {
                regcon.Open();
            }

            using (SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Employee WHERE Email = @Email", regcon))
            {
                checkEmailCmd.Parameters.AddWithValue("@Email", email);
                int count = (int)checkEmailCmd.ExecuteScalar();
                return count > 0;
            }
        }
        private string GetMessageBasedOnErrorCode(int errorCode)
        {
            // Handle specific SQL error codes and return corresponding messages
            if (errorCode == 2627 || errorCode == 2601)
            {
                return "Employee ID already exists. Please choose a different ID.";
            }

            // Add more cases as needed

            // Default message
            return "An error occurred.";
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