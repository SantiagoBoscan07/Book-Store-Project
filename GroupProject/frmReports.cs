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
            DateTime startDate = dtStartDate.Value.Date;
            DateTime endDate = dtEndDate.Value.Date;

            // Step 4: Call the SalesDB to get real data
            List<Sales> reportData = SalesDB.GetSalesReport(storeID, startDate, endDate);

            // Step 5: Fill DataGridView with results
            decimal totalSales = 0;

            foreach (Sales s in reportData)
            {
                dgvReport.Rows.Add(
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