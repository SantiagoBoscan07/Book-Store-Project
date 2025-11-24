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
        string connectionString = ConfigurationManager.ConnectionStrings["GroupProject.Properties.Settings.BookStoreDBConnectionString"].ConnectionString;


        private PrintDocument printDocument1 = new PrintDocument();

        public frmInvoice()
        {
            InitializeComponent();
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            btnSearch.Click += btnSearch_Click;
            btnPrint.Click += btnPrint_Click;
            btnClose.Click += btnClose_Click;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text))
            {
                MessageBox.Show("Please enter an Order ID.");
                return;
            }

            LoadInvoice();
        }

        private void LoadInvoice()
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT 
                    T.Title,
                    OI.Quantity,
                    T.Price,
                    (OI.Quantity * T.Price) AS ExtendedPrice
                FROM OrderItems OI
                JOIN Titles T ON OI.TitleID = T.TitleID
                WHERE OI.OrderID = @OrderID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No invoice found for this Order ID.");
                dgvInvoiceItems.DataSource = null;
                ClearTotals();
                return;
            }

            dgvInvoiceItems.DataSource = dt;
            CalculateTotals(dt);
        }

        private void CalculateTotals(DataTable dt)
        {
            decimal subtotal = 0;

            foreach (DataRow row in dt.Rows)
            {
                subtotal += Convert.ToDecimal(row["ExtendedPrice"]);
            }

            decimal tax = subtotal * 0.06m;
            decimal total = subtotal + tax;

            txtSubtotal.Text = subtotal.ToString("C");
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }

        private void ClearTotals()
        {
            txtSubtotal.Text = "";
            txtTax.Text = "";
            txtTotal.Text = "";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument1;
            preview.Width = 1200;
            preview.Height = 800;
            preview.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Segoe UI", 18, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 11);
            int y = 40;

            e.Graphics.DrawString("Bookstore Invoice", headerFont, Brushes.Black, 260, y);
            y += 50;

            e.Graphics.DrawString($"Order ID: {txtOrderID.Text}", textFont, Brushes.Black, 50, y);
            y += 35;

            e.Graphics.DrawString("Title", textFont, Brushes.Black, 50, y);
            e.Graphics.DrawString("Qty", textFont, Brushes.Black, 300, y);
            e.Graphics.DrawString("Price", textFont, Brushes.Black, 380, y);
            e.Graphics.DrawString("Extended", textFont, Brushes.Black, 470, y);
            y += 25;

            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 10;

            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
            {
                if (row.Cells[0].Value == null) continue;

                e.Graphics.DrawString(row.Cells[0].Value.ToString(), textFont, Brushes.Black, 50, y);
                e.Graphics.DrawString(row.Cells[1].Value.ToString(), textFont, Brushes.Black, 300, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells[2].Value).ToString("C"), textFont, Brushes.Black, 380, y);
                e.Graphics.DrawString(Convert.ToDecimal(row.Cells[3].Value).ToString("C"), textFont, Brushes.Black, 470, y);
                y += 25;
            }

            y += 20;
            e.Graphics.DrawLine(Pens.Black, 50, y, 750, y);
            y += 20;

            e.Graphics.DrawString($"Subtotal: {txtSubtotal.Text}", textFont, Brushes.Black, 500, y);
            y += 25;
            e.Graphics.DrawString($"Tax: {txtTax.Text}", textFont, Brushes.Black, 500, y);
            y += 25;
            e.Graphics.DrawString($"Total: {txtTotal.Text}", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, 500, y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


