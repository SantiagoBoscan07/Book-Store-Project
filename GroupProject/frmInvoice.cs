using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmInvoice : Form
    {
        // Database connection string
        private string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;
        // Print document for printing invoices
        private PrintDocument printDocument1 = new PrintDocument();

        // List of all invoices
        private List<Invoice> allInvoices = new List<Invoice>();
        // Current displayed invoices
        private List<Invoice> displayedInvoices = new List<Invoice>();

        public frmInvoice()
        {
            InitializeComponent();
            // Set up print document event
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            // Load all invoices on form load
            LoadAllInvoices();
            // Calculate totals for all invoices
            CalculateTotals();
            // Set up grid cell click event
            grdInvoiceItems.CellClick += GrdInvoiceItems_CellClick;
        }

        // Load all invoices from the database
        private void LoadAllInvoices()
        {
            // Clear existing invoices
            allInvoices.Clear();

            // SQL query to get invoice data
            string query = @"
                SELECT S.stor_id, S.ord_num, S.ord_date, S.qty, S.title_id, T.title, T.price
                FROM sales S
                JOIN titles T ON S.title_id = T.title_id
                ORDER BY S.ord_num";

            // Execute query and populate allInvoices list
            try
            {
                // Connect to database and execute query
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Open connection and read data
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Create Invoice object and add to list
                        allInvoices.Add(new Invoice
                        {
                            // Populate properties from database fields
                            StoreID = reader["stor_id"].ToString(),
                            OrderID = reader["ord_num"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["ord_date"]),
                            Quantity = Convert.ToInt16(reader["qty"]),
                            TitleID = reader["title_id"].ToString(),
                            Title = reader["title"].ToString(),
                            Price = Convert.ToDecimal(reader["price"])
                        });
                    }
                }
            }
            // Handle any errors during database access
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoices: " + ex.Message);
            }

            // Show all by default
            displayedInvoices = allInvoices.ToList();
            BindGrid(displayedInvoices);
        }

        // Bind list of invoices to grid
        private void BindGrid(List<Invoice> invoices)
        {
            // Prepare data for display
            var displayList = invoices.Select(inv => new
            {
                // Select relevant fields for display
                OrderID = inv.OrderID,
                Title = inv.Title,
                Qty = inv.Quantity,
                Price = inv.Price,
                ExtendedPrice = inv.ExtendedPrice
            }).ToList();

            // Bind to DataGridView
            grdInvoiceItems.DataSource = displayList;

            // Clear totals if no invoices
            ClearTotals();
        }

        // Calculate totals for currently displayed invoices
        private void CalculateTotals()
        {
            // Calculate subtotal, tax, and total
            decimal subtotal = displayedInvoices.Sum(inv => inv.ExtendedPrice);
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

        // Event handler for search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get Order ID from textbox
            string orderID = txtOrderID.Text.Trim();
            
            // Validate input
            if (string.IsNullOrEmpty(orderID))
            {
                MessageBox.Show("Please enter an Order ID to search.");
                return;
            }

            // Filter invoices by Order ID
            displayedInvoices = allInvoices
                .Where(inv => inv.OrderID.Equals(orderID, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Notify if no invoices found
            if (displayedInvoices.Count == 0)
            {
                MessageBox.Show("No invoice found for this Order ID.");
                return;
            }

            // Update grid and totals
            BindGrid(displayedInvoices);
            CalculateTotals();
        }

        // Event handler for clear search button click
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            // Clear search box and show all invoices
            txtOrderID.Text = "";
            displayedInvoices = allInvoices.ToList();
            // Display all invoices again
            BindGrid(displayedInvoices);
            // Clear previous calculations and performs new totals
            ClearTotals();
            CalculateTotals();
        }

        // Event handler for print button click
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Show print preview dialog
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDocument1,
                Width = 1200,
                Height = 800
            };
            // Show the dialog
            preview.ShowDialog();
        }

        // Print page event handler
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up fonts and starting position
            Font headerFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 11);
            int y = 40;

            // Print header
            e.Graphics.DrawString("Bookstore Invoice", headerFont, Brushes.Black, 260, y);
            y += 50;

            // Print Order IDs
            e.Graphics.DrawString("Order ID(s):", textFont, Brushes.Black, 50, y);
            y += 20; 

            // Wrap Order IDs if too long
            string allOrderIDs = string.Join(", ", displayedInvoices.Select(i => i.OrderID).Distinct());
            int maxWidth = 600; 
            int xStart = 150;
            string[] ids = allOrderIDs.Split(new[] { ", " }, StringSplitOptions.None);
            string line = "";
            // Print each Order ID, wrapping as needed
            foreach (var id in ids)
            {
                string testLine = string.IsNullOrEmpty(line) ? id : line + ", " + id;
                SizeF size = e.Graphics.MeasureString(testLine, textFont);
                if (size.Width > maxWidth)
                {
                    e.Graphics.DrawString(line, textFont, Brushes.Black, xStart, y);
                    y += (int)size.Height + 2;
                    line = id;
                }
                else
                {
                    line = testLine;
                }
            }
            if (!string.IsNullOrEmpty(line))
            {
                e.Graphics.DrawString(line, textFont, Brushes.Black, xStart, y);
                y += (int)e.Graphics.MeasureString(line, textFont).Height + 10;
            }

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
            foreach (DataGridViewRow row in grdInvoiceItems.Rows)
            {
                if (row.Cells[0].Value == null) continue;

                // Truncate title if too long
                string title = row.Cells["Title"].Value.ToString();
                if (title.Length > 25)
                    title = title.Substring(0, 25) + "...";

                // Print item details
                e.Graphics.DrawString(title, textFont, Brushes.Black, 50, y);
                e.Graphics.DrawString(row.Cells["Qty"].Value.ToString(), textFont, Brushes.Black, 300, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells["Price"].Value).ToString("C"), textFont, Brushes.Black, 380, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells["ExtendedPrice"].Value).ToString("C"), textFont, Brushes.Black, 470, y);
                y += 25;
            }

            // Draw line after items
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

        // Event handler for clicking a row in the grid
        private void GrdInvoiceItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0) return;

            // Get the Order ID of the clicked row
            string selectedOrderID = grdInvoiceItems.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();

            // Set the Order ID in the search box
            txtOrderID.Text = selectedOrderID;

            // Trigger search for that Order ID
            btnSearch_Click(sender, EventArgs.Empty);
        }

        // Event handler for close button click
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
