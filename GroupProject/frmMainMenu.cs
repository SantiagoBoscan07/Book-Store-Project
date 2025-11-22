using System.Configuration;
using Microsoft.Data.SqlClient;

namespace GroupProject
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();

            // Testing database connection and retrieving table names
            // this.Load += frmMainMenu_Load;
        }

        // Test method to connect to the database and list table names
        public void frmMainMenu_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"]
                .ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // ADO.NET command to query system tables for all user tables
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string output = "Tables:\n";

                        while (reader.Read())
                        {
                            output += reader.GetString(0) + "\n";
                        }

                        lblInfo.Text = output;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error: " + ex.Message;
            }
        }

        // Event handler for exit button click, closes the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
