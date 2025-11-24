using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmInvoice : Form
    {
        // Connection string to the BookStoreDB database
        string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;

        // PrintDocument for handling print operations
        private PrintDocument printDocument1 = new PrintDocument();

        // Constructor
        public frmInvoice()
        {
            InitializeComponent();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
        }

        // Event handler for Search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Validate Order ID input
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Please enter an Order ID.");
                return;
            }

            // Load invoice data
            LoadInvoice();
        }

        // Load invoice data from the database
        private void LoadInvoice()
        {
            // Clear previous data
            DataTable dt = new DataTable();

            // SQL query to retrieve invoice details
            string query = @"
            SELECT 
                T.Title,
                OI.Quantity,
                T.Price,
                (OI.Quantity * T.Price) AS ExtendedPrice
            FROM OrderItems OI
            JOIN Titles T ON OI.TitleID = T.TitleID
            WHERE OI.OrderID = @OrderID";

            // Try to execute the query and handle potential validation errors
            try
            {
                // Execute the query and fill the DataTable
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // This line will throw the "Invalid object name" error if tables don't exist
                    da.Fill(dt);
                }
            }
            // Handle SQL exceptions
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Invalid object name"))
                {
                    MessageBox.Show(
                        "A required table or view does not exist in the database.\n" + "Please verify your database structure.\n\nDetails: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );

                    dgvInvoiceItems.DataSource = null;
                    ClearTotals();
                    return;
                }
                else
                {
                    MessageBox.Show(
                        "An error occurred while loading the invoice.\n\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dgvInvoiceItems.DataSource = null;
                    ClearTotals();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\nDetails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvInvoiceItems.DataSource = null;
                ClearTotals();
                return;
            }

            // Check if any data was returned
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No invoice found for this Order ID.");
                dgvInvoiceItems.DataSource = null;
                ClearTotals();
                return;
            }

            // Load the data into the grid if successful
            dgvInvoiceItems.DataSource = dt;
            CalculateTotals(dt);
        }


        // Calculate subtotal, tax, and total
        private void CalculateTotals(DataTable dt)
        {
            // Initialize subtotal
            decimal subtotal = 0;

            // Sum up ExtendedPrice for each row
            foreach (DataRow row in dt.Rows)
            {
                subtotal += Convert.ToDecimal(row["ExtendedPrice"]);
            }

            // Calculate tax and total
            decimal tax = subtotal * 0.06m;
            decimal total = subtotal + tax;

            // Display totals in text boxes
            txtSubtotal.Text = subtotal.ToString("C");
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }

        // Clear totals text boxes
        private void ClearTotals()
        {
            txtSubtotal.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
        }

        // Event handler for Print button click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            preview.Width = 1200;
            preview.Height = 800;
            preview.ShowDialog();
        }

        // PrintPage event handler to format the invoice for printing
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define fonts and starting position
            Font headerFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 11);
            int y = 40;
            // Print header
            e.Graphics.DrawString("Bookstore Invoice", headerFont, Brushes.Black, 260, y);
            y += 50;
            // Print Order ID
            e.Graphics.DrawString($"Order ID: {txtOrderID.Text}", textFont, Brushes.Black, 50, y);
            y += 35;
            // Print table headers
            e.Graphics.DrawString("Title", textFont, Brushes.Black, 50, y);
            e.Graphics.DrawString("Qty", textFont, Brushes.Black, 300, y);
            e.Graphics.DrawString("Price", textFont, Brushes.Black, 380, y);
            e.Graphics.DrawString("Extended", textFont, Brushes.Black, 470, y);
            y += 25;
            // Draw line under headers
            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 10;
            // Print each invoice item
            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
            {
                if (row.Cells[0].Value == null) continue;

                e.Graphics.DrawString(row.Cells[0].Value.ToString(), textFont, Brushes.Black, 50, y);
                e.Graphics.DrawString(row.Cells[1].Value.ToString(), textFont, Brushes.Black, 300, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells[2].Value).ToString("C"), textFont, Brushes.Black, 380, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells[3].Value).ToString("C"), textFont, Brushes.Black, 470, y);
                y += 25;
            }
            // Draw line before totals
            y += 20;
            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 20;
            // Print totals
            e.Graphics.DrawString($"Subtotal: {txtSubtotal.Text}", textFont, Brushes.Black, 500, y);
            y += 25;
            e.Graphics.DrawString($"Tax: {txtTax.Text}", textFont, Brushes.Black, 500, y);
            y += 25;
            e.Graphics.DrawString($"Total: {txtTotal.Text}", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, 500, y);
        }
        // Event handler for Close button click, closes the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


