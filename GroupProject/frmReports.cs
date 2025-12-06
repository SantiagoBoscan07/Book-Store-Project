using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using BookStoreDO;



namespace GroupProject
{
    public partial class frmReports : Form
    {

        // Retrieve connection string from App.config
        private readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings[
                "GroupProject.Properties.Settings.BookStoreDBConnectionString"
            ].ConnectionString;

        public frmReports()
        {
            InitializeComponent();
            // Event handler for store selection change
            cboStores.SelectedIndexChanged += CboStores_SelectedIndexChanged;
        }

        private void CboStores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Return if no stores is selected in combox box
            if (cboStores.SelectedItem == null)
                return;

            // Gets store ID from selection
            string storeID = cboStores.SelectedItem.ToString();

            // Searches for last and first date in the sales table
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = @"
            SELECT 
                MIN(ord_date) AS FirstDate,
                MAX(ord_date) AS LastDate
            FROM sales
            WHERE stor_id = @stor_id";

                // Connects and execute sql query
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stor_id", storeID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Handle the case where there are no sales
                    DateTime? firstDate = reader["FirstDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FirstDate"]);
                    DateTime? lastDate = reader["LastDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LastDate"]);

                    // Gets first date value
                    if (firstDate.HasValue)
                    {
                        dtStartDate.Value = firstDate.Value;
                        txtFirstEntry.Text = firstDate.Value.ToShortDateString();
                    }
                    // Gets current date
                    else
                    {
                        dtStartDate.Value = DateTime.Today;
                        txtFirstEntry.Clear();
                    }

                    // Gets last value
                    if (lastDate.HasValue)
                    {
                        dtEndDate.Value = lastDate.Value;
                        txtLastEntry.Text = lastDate.Value.ToShortDateString();
                    }
                    // Gets current date
                    else
                    {
                        dtEndDate.Value = DateTime.Today;
                        txtLastEntry.Clear();
                    }
                }
            }
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            cboStores.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string sql = "SELECT stor_id FROM stores";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboStores.Items.Add(reader["stor_id"].ToString());
                }
            }

            if (cboStores.Items.Count > 0)
                cboStores.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Step 1: Validate dates
            if (dtStartDate.Value.Date > dtEndDate.Value.Date)
            {
                MessageBox.Show("Start date must be before end date.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Step 2: Clear old results
            dgvReport.Rows.Clear();

            // Step 3: Get criteria
            string storeID = cboStores.SelectedItem.ToString();

            // Set Start Date at 12:00 AM
            DateTime startDate = dtStartDate.Value.Date;

            // Set End Date at 11:59:59 PM
            DateTime endDate = dtEndDate.Value.Date.AddDays(1).AddTicks(-1);

            // Step 4: Call the SalesDB to get real data
            List<Sales> reportData = SalesDB.GetSalesReport(storeID, startDate, endDate);

            // Step 5: Fill DataGridView with results
            decimal totalSales = 0;

            foreach (Sales s in reportData)
            {
                dgvReport.Rows.Add(
                    s.OrderID,       
                    s.TitleID,      
                    s.TitleName,
                    s.Quantity,
                    s.Price.ToString("C"),
                    s.Subtotal.ToString("C"),
                    s.OrderDate.ToShortDateString()
                );

                totalSales += s.Subtotal;
            }

            // Step 6: Display total
            txtTotalSales.Text = totalSales.ToString("C");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}